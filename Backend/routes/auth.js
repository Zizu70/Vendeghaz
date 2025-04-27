const express = require('express');
const db = require('../db');
const router = express.Router();

const app = express();
//***ok**//
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
//***ok***//
// Dolgozói bejelentkezés
router.post('/worker-login', (req, res) => {
  console.log('Bejövő adatok:', req.body); 

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

// Regisztrációs route
app.post('/auth/register', async (req, res) => {
  const { username, email, password } = req.body;
  console.log('Kapott adat:', req.body);  // Logoljunk ki mindent, amit kapunk

  if (!username || !email || !password) {
    return res.status(400).json({ message: 'Minden mezőt ki kell tölteni!' });
  }

// Regisztrációs route


  console.log(req.body);  // Ellenőrizd, hogy mit kap a szerver

  // Ellenőrizzük, hogy minden mező ki van-e töltve
  if (!username || !email || !password) {
    return res.status(400).json({ message: 'Minden mezőt ki kell tölteni!' });
  }

  // Ellenőrizzük, hogy az email már regisztrálva van-e
  db.query('SELECT * FROM users WHERE email = ?', [email], (err, results) => {
    if (err) return res.status(500).json({ message: 'Hiba történt a lekérdezés során!' });

    if (results.length > 0) {
      return res.status(400).json({ message: 'Ez az email már regisztrálva van!' });
    }

    // Felhasználó adatainak beszúrása az adatbázisba
    db.query(
      'INSERT INTO users (username, email, password) VALUES (?, ?, ?)',
      [username, email, password],  // Jelszó titkosítás nélkül
      (err, results) => {
        if (err) return res.status(500).json({ message: 'Hiba történt a felhasználó létrehozása során!' });

        // Válasz
        res.status(201).json({ message: 'Sikeres regisztráció!' });
      }
    );
  });
});

module.exports = router;
