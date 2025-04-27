const express = require('express');
const  db  = require('../db');
const router = express.Router();

// Örökbefogadási nézet lekérdezése
router.get('/', (req, res) => {
  db.query('SELECT * FROM adoption_view', (error, results) => {
    if (error) {
      console.error('Hiba az örökbefogadások lekérdezésekor:', error);
      return res.status(500).send('Hiba történt az örökbefogadások lekérdezésekor.');
    }
    res.json(results);
  });
});

// Egy adott felhasználó és vendég örökbefogadásának ellenőrzése
router.get('/check', (req, res) => {
  const { u_id, g_id } = req.query;
  db.query(
    'SELECT * FROM adoption WHERE u_id = ? AND g_id = ?',
    [u_id, g_id],
    (error, results) => {
      if (error) {
        console.error('Hiba az örökbefogadás ellenőrzésekor:', error);
        return res.status(500).send('Hiba történt az örökbefogadás ellenőrzésekor.');
      }
      res.json({ adopted: results.length > 0 });
    }
  );
});

// Új örökbefogadás rögzítése
router.post('/', (req, res) => {
  const { g_id, u_id } = req.body;
  db.query(
    'INSERT INTO adoption (g_id, u_id) VALUES (?, ?)',
    [g_id, u_id],
    (error) => {
      if (error) {
        console.error('Hiba az örökbefogadás rögzítésekor:', error);
        return res.status(500).send('Hiba történt az örökbefogadás rögzítésekor.');
      }
      res.status(201).send('Örökbefogadás rögzítve.');
    }
  );
});

// Örökbefogadás törlése
router.delete('/', (req, res) => {
  const { g_id, u_id } = req.body;
  db.query(
    'DELETE FROM adoption WHERE g_id = ? AND u_id = ?',
    [g_id, u_id],
    (error) => {
      if (error) {
        console.error('Hiba az örökbefogadás törlésekor:', error);
        return res.status(500).send('Hiba történt az örökbefogadás törlésekor.');
      }
      res.send('Örökbefogadás törölve.');
    }
  );
});

module.exports = router;
