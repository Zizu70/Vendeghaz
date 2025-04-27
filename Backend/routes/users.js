const express = require('express');
const { db } = require('../db');  // Az adatbázis kapcsolat
const router = express.Router();

// Felhasználók lekérdezése (GET kérés)
router.get('/', (req, res) => {
  db.query('SELECT * FROM users', (error, results) => {
    if (error) {
      console.error('Hiba a felhasználók lekérdezésekor:', error);
      return res.status(500).send('Hiba történt a felhasználók lekérdezésekor.');
    }
    res.json(results);  // Visszaküldjük a felhasználók adatait JSON formátumban
  });
});

// Felhasználó létrehozása (POST kérés)
router.post('/', (req, res) => {
  const { u_name, u_email, u_password } = req.body;

  if (!u_name || !u_email || !u_password) {
    return res.status(400).send('Minden mezőt ki kell tölteni!');
  }

  const sql = 'INSERT INTO users (u_name, u_email, u_password) VALUES (?, ?, ?)';
  const values = [u_name, u_email, u_password];

  db.query(sql, values, (error, result) => {
    if (error) {
      console.error('Hiba a felhasználó létrehozásakor:', error);
      return res.status(500).send('Hiba történt a felhasználó létrehozásakor.');
    }
    res.status(201).send('Felhasználó létrehozva.');
  });
});

module.exports = router;
