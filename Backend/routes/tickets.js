const express = require('express');
const db  = require('../db');  // Ez sima mysql2 kapcsolat
const router = express.Router();

// Jegyek lekérdezése (GET kérés)
router.get('/', (req, res) => {
  db.query('SELECT * FROM tickets', (error, results) => {
    if (error) {
      console.error('Hiba a jegyek lekérdezésekor:', error);
      return res.status(500).send('Hiba történt a jegyek lekérdezésekor.');
    }
    res.json(results);
  });
});

// Jegy rögzítése (POST kérés)
router.post('/', (req, res) => {
  const { u_id, t_date, t_time, t_piece, t_amount } = req.body;

  if (!u_id || !t_date || !t_time || !t_piece || !t_amount) {
    return res.status(400).send('Minden mezőt ki kell tölteni!');
  }

  const sql = 'INSERT INTO tickets (u_id, t_date, t_time, t_piece, t_amount) VALUES (?, ?, ?, ?, ?)';
  const values = [u_id, t_date, t_time, t_piece, t_amount];

  db.query(sql, values, (error, result) => {
    if (error) {
      console.error('Hiba a jegy rögzítésekor:', error);
      return res.status(500).send('Hiba történt a jegy rögzítésekor.');
    }
    res.status(201).send('Jegy rögzítve.');
  });
});

module.exports = router;
