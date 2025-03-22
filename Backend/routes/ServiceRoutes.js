const express = require('express');
const bcrypt = require('bcrypt');
const db = require('../db');  // Az adatbázis kapcsolat importálása
const router = express.Router();

/*router.post('/login', async (req, res) => {
    console.log("Bejelentkezési kérés érkezett:", req.body);
});*/


// **Admin bejelentkezés ellenőrzése**
router.post('/login', async (req, res) => {  // /login
    //const { name, password } = req.body;
    console.log("Bejelentkezési kérés érkezett:", req.body);

    if (!name || !password) {  //később nem kelle
        return res.status(400).json({ success: false, message: "Név és jelszó megadása kötelező!" });
    }

    try {
        const [rows] = await db.query(
            "SELECT * FROM workers WHERE w_name = ? AND w_role = 'admin'",
            [name]
        );

        console.log("Lekérdezett admin:", results);  // Debug kiírás később nem kell

        if (!rows || rows.length === 0) { //(rows.length === 0)
            res.status(401).json({ success: false, message: "Hibás adatok vagy nincs admin jogosultság." });
        }
          
        const user = result[0];

        // Jelszó ellenőrzése
        const isMatch = await bcrypt.compare(password, user.w_password);

        if (!isMatch) {
            return res.status(401).json({ success: false, message: "Hibás jelszó!" });
        }

        res.json({ success: true, message: "Sikeres bejelentkezés!", user });
   
    } catch (error) {
        console.error("Adatbázis hiba:", error);
        res.status(500).json({ success: false, message: "Szerverhiba a bejelentkezés során." });
    }
});

module.exports = router;