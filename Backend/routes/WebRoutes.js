const express = require('express');
const bcrypt = require('bcrypt');
const db = require('../db'); 
const jwt = require('jsonwebtoken');
const router = express.Router();
const fs = require('fs');
const multer = require('multer');

const SECRET_KEY = process.env.JWT_SECRET || "your_secret_key"; // Biztonsági kulcs a JWT-hez

// Feltételezve, hogy az adatbázis kapcsolódás és lekérdezések külön fájlban vannak




//*SSSS************************************************* */
//***** Belépés User és Worker *****//
router.post('/auth/user-login', async (req, res) => {
    const { u_email, u_password } = req.body;
    const [rows] = await db.query('SELECT * FROM users WHERE u_email = ? AND u_password = ?', [u_email, u_password]);
    if (rows.length > 0) {
      res.json({ success: true, user: rows[0], role: 'user' });
    } else {
      res.status(401).json({ success: false, message: 'Hibás belépési adatok.' });
    }
  });
  
router.post('/auth/worker-login', async (req, res) => {
    const { w_name, w_password } = req.body;
    const [rows] = await db.query('SELECT * FROM workers WHERE w_name = ? AND w_password = ?', [w_name, w_password]);
    if (rows.length > 0) {
      res.json({ success: true, user: rows[0], role: rows[0].w_role });
    } else {
      res.status(401).json({ success: false, message: 'Hibás dolgozói adatok.' });
    }
  });  //auth ????

//***** Belépés User és Worker *****//

//***** Guests *****//
const uploadDir = '../uploads';
if (!fs.existsSync(uploadDir)) fs.mkdirSync(uploadDir);

// Multer beállítása
const storage = multer.diskStorage({
  destination: (req, file, cb) => cb(null, uploadDir),
  filename: (req, file, cb) => cb(null, Date.now() + path.extname(file.originalname)),
});

const upload = multer({ storage });

router.get('/guests', async (req, res) => {
  const [rows] = await db.query('SELECT g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, g_image FROM guests');
  res.json(rows);
});

router.post('/guests', upload.single('g_image'), async (req, res) => {
  const {
    g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other,
  } = req.body;

  const imagePath = req.file ? req.file.filename : null;

  await db.query(
    'INSERT INTO guests (g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, g_image) VALUES (?, ?, ?, ?, ?, ?, ?, ?)',
    [g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, imagePath]
  );
  res.status(201).send('Állat rögzítve.');
});

// Statikus képek kiszolgálása
router.use('/guests/images', express.static(uploadDir));

//***** Guests *****//

//***** Tickets *****//
router.get('/tickets', async (req, res) => {
    const [rows] = await db.query('SELECT t_date, t_time, t_piece FROM tickets WHERE 1');
    res.json(rows);
  });
  
  router.post('/tickets', async (req, res) => {
    const { u_id, t_date, t_time, t_piece, t_amount } = req.body;
    await db.query('INSERT INTO tickets (u_id, t_date, t_time, t_piece, t_amount) VALUES (?, ?, ?, ?, ?)', [u_id, t_date, t_time, t_piece, t_amount]);
    res.status(201).send('Jegy rögzítve.');
  });

//***** Tickets *****//

//***** Users *****//
router.get('/users', async (req, res) => {
    const [rows] = await db.query('SELECT * FROM users');
    res.json(rows);
  });
  
  router.post('/users', async (req, res) => {
    const { u_name, u_email, u_password } = req.body;
    await db.query('INSERT INTO users (u_name, u_email, u_password) VALUES (?, ?, ?)', [u_name, u_email, u_password]);
    res.status(201).send('Felhasználó létrehozva.');
  });

//***** Users *****//

//***** Workers *****//
router.get('/workers', async (req, res) => {
    const [rows] = await db.query('SELECT * FROM workers');
    res.json(rows);
  });
  
  router.post('/workers', async (req, res) => {
    const { w_name, w_password, w_role } = req.body;
    await db.query('INSERT INTO workers (w_name, w_password, w_role) VALUES (?, ?, ?)', [w_name, w_password, w_role]);
    res.status(201).send('Dolgozó létrehozva.');
  });

//***** Workers *****//

//***** WorkersGuests *****//
router.get('/workersGuests', async (req, res) => {
    const [rows] = await db.query(
      `SELECT wg.w_id, w.w_name, wg.g_id, g.g_name FROM workers_guests wg
       JOIN workers w ON wg.w_id = w.w_id
       JOIN guests g ON wg.g_id = g.g_id`
    );
    res.json(rows);
  });
  
  router.post('/workersGuests', async (req, res) => {
    const { w_id, g_id } = req.body;
    await db.query('INSERT INTO workers_guests (w_id, g_id) VALUES (?, ?)', [w_id, g_id]);
    res.status(201).send('Kapcsolat rögzítve.');
  });

//***** WorkersGuests *****//



















router.get('/adoption', async (req, res) => {
    const [rows] = await db.query('SELECT * FROM adoption_view');
    res.json(rows);
  });


router.get('/adoption/check', async (req, res) => {
    const { u_id, g_id } = req.query;
    const [rows] = await db.query(
      'SELECT * FROM adoption WHERE u_id = ? AND g_id = ?',
      [u_id, g_id]
    );
    res.json({ adopted: rows.length > 0 });
  });
  
  router.post('/adoption', async (req, res) => {
    const { g_id, u_id } = req.body;
    await db.query('INSERT INTO adoption (g_id, u_id) VALUES (?, ?)', [g_id, u_id]);
    res.status(201).send('Örökbefogadás rögzítve.');
  });
  
  router.delete('/adoption', async (req, res) => {
    const { g_id, u_id } = req.body;
    await db.query('DELETE FROM adoption WHERE g_id = ? AND u_id = ?', [g_id, u_id]);
    res.send('Örökbefogadás törölve.');
  });
  










module.exports = router;