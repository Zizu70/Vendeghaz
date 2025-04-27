const express = require('express');
const { db } = require('../db');  // Sima mysql2 connection
const router = express.Router();

// GET kérés: Kapcsolatok lekérdezése
router.get('/', (req, res) => {
  const sql = `
    SELECT wg.w_id, w.w_name, wg.g_id, g.g_name 
    FROM workers_guests wg
    JOIN workers w ON wg.w_id = w.w_id
    JOIN guests g ON wg.g_id = g.g_id
  `;

  db.query(sql, (error, results) => {
    if (error) {
      console.error('Hiba a lekérdezés során:', error);
      return res.status(500).send('Hiba történt a szerveren.');
    }
    res.json(results);
  });
});

// POST kérés: Új kapcsolat rögzítése
router.post('/', (req, res) => {
  const { w_id, g_id } = req.body;

  if (!w_id || !g_id) {
    return res.status(400).send('Minden mezőt ki kell tölteni!');
  }

  const sql = 'INSERT INTO workers_guests (w_id, g_id) VALUES (?, ?)';
  const values = [w_id, g_id];

  db.query(sql, values, (error, result) => {
    if (error) {
      console.error('Hiba az adatbevitel során:', error);
      return res.status(500).send('Hiba történt a szerveren.');
    }
    res.status(201).send('Kapcsolat rögzítve.');
  });
});

module.exports = router;
