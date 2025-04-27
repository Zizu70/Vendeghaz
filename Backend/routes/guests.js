const express = require('express');
const  db  = require('../db');  // Az adatbázis kapcsolat
const multer = require('multer');
const path = require('path');
const fs = require('fs');

const router = express.Router();

// A képek tárolási helyének beállítása
const uploadDir = './uploads';

// Ha még nem létezik az 'uploads' mappa, létrehozzuk
if (!fs.existsSync(uploadDir)) fs.mkdirSync(uploadDir);

// Multer beállítása (képfeltöltéshez)
const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    cb(null, uploadDir); // A fájlokat az uploads mappába tesszük
  },
  filename: (req, file, cb) => {
    cb(null, Date.now() + path.extname(file.originalname)); // Egyedi fájlnév (timestamp + eredeti kiterjesztés)
  }
});

const upload = multer({ storage }); // Multer inicializálása

// Vendégek lekérdezése
router.get('/', (req, res) => {
  db.query('SELECT * FROM guests', (error, results) => {
    if (error) {
      console.error('Hiba a vendégek lekérdezésekor:', error);
      return res.status(500).send('Hiba történt a vendégek lekérdezésekor.');
    }
    res.json(results);
  });
});

// Vendég rögzítése (POST kérés képfeltöltéssel)
router.post('/', upload.single('g_image'), (req, res) => {
  const { g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other } = req.body;
  const imagePath = req.file ? req.file.filename : null;

  const sql = `
    INSERT INTO guests (g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, g_image)
    VALUES (?, ?, ?, ?, ?, ?, ?, ?)
  `;
  const values = [g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, imagePath];

  db.query(sql, values, (error, result) => {
    if (error) {
      console.error('Hiba az állat rögzítésekor:', error);
      return res.status(500).send('Hiba történt az állat rögzítésekor.');
    }
    res.status(201).send('Állat rögzítve.');
  });
});

// Statikus képek kiszolgálása (a feltöltött képeket az uploads mappából)
router.use('/images', express.static(uploadDir));

module.exports = router;
