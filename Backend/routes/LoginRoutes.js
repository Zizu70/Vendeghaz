const express = require('express');
const bcrypt = require('bcrypt');
const db = require('../db');  // Az adatbázis kapcsolat importálása
const router = express.Router();

// Bejelentkezési route
router.post('/login', async (req, res) => {
    const { name, password } = req.body;

    if (!name || !password) {
        return res.status(400).json({ message: 'Name and password are required.' });
    }

    try {
        // Felhasználó lekérdezése az adatbázisból
        const results = await db.query('SELECT * FROM workers WHERE name = ?', [name]);
        
        if (results.length === 0) {
            return res.status(404).json({ message: 'User not found.' });
        }

        const user = results[0];

        // Jelszó ellenőrzése bcrypt-tel
        const isMatch = await bcrypt.compare(password, user.password);
        
        if (isMatch) {
            return res.status(200).json({ message: 'Login successful!' });
        } else {
            return res.status(401).json({ message: 'Invalid credentials.' });
        }
    } catch (err) {
        console.error("Database query error:", err);
        return res.status(500).json({ message: 'Internal server error.' });
    }
});

module.exports = router;