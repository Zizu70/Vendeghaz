const express = require('express');
const { db } = require('../db');

const router = express.Router();

// Felhasználói bejelentkezés
router.post('/user-login', (req, res) => {
  const { u_email, u_password } = req.body;

  const sql = 'SELECT * FROM users WHERE u_email = ? AND u_password = ?';
  db.query(sql, [u_email, u_password], (error, results) => {
    if (error) {
      console.error('Hiba a felhasználói bejelentkezés során:', error);
      return res.status(500).send('Hiba történt a bejelentkezés során.');
    }

    if (results.length > 0) {
      res.json({ success: true, user: results[0], role: 'user' });
    } else {
      res.status(401).json({ success: false, message: 'Hibás belépési adatok.' });
    }
  });
});

// Dolgozói bejelentkezés
router.post('/worker-login', (req, res) => {
  const { w_name, w_password } = req.body;

  const sql = 'SELECT * FROM workers WHERE w_name = ? AND w_password = ?';
  db.query(sql, [w_name, w_password], (error, results) => {
    if (error) {
      console.error('Hiba a dolgozói bejelentkezés során:', error);
      return res.status(500).send('Hiba történt a bejelentkezés során.');
    }

    if (results.length > 0) {
      res.json({ success: true, user: results[0], role: results[0].w_role });
    } else {
      res.status(401).json({ success: false, message: 'Hibás dolgozói adatok.' });
    }
  });
});

module.exports = router;
