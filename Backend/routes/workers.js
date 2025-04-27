const express = require('express');
const { db } = require('../db');  // Az adatbázis kapcsolat
const router = express.Router();

// Dolgozók lekérdezése (GET kérés)
router.get('/', (req, res) => {
  db.query('SELECT * FROM workers', (error, results) => {
    if (error) {
      console.error('Hiba a dolgozók lekérdezésekor:', error);
      return res.status(500).send('Hiba történt a dolgozók lekérdezésekor.');
    }
    res.json(results);  // Visszaküldjük a dolgozók adatait JSON formátumban
  });
});

// Dolgozó létrehozása (POST kérés)
router.post('/', (req, res) => {
  const { w_name, w_password, w_role } = req.body;

  if (!w_name || !w_password || !w_role) {
    return res.status(400).send('Minden mezőt ki kell tölteni!');
  }

  const sql = 'INSERT INTO workers (w_name, w_password, w_role) VALUES (?, ?, ?)';
  const values = [w_name, w_password, w_role];

  db.query(sql, values, (error, result) => {
    if (error) {
      console.error('Hiba a dolgozó létrehozásakor:', error);
      return res.status(500).send('Hiba történt a dolgozó létrehozásakor.');
    }
    res.status(201).send('Dolgozó létrehozva.');
  });
});

module.exports = router;
