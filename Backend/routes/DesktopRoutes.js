const express = require('express');
const router = express.Router();
const db = require('../db');  // Feltételezve, hogy az adatbázis lekérdezések külön fájlban vannak

//*****Be és kijelentkezés*****//

// Adminisztrátor bejelentkezés           //ÁTGONDOLNI!!!!!!!
// gomb:belépés                        
router.post('/worker/auth/login', async (req, res) => {
    const { w_name, w_password } = req.body;
    try {
        // Ellenőrizzük a bejelentkezési adatokat (név-jelszó ellenőrzése)
        const admin = await db.query(
            `SELECT * FROM workers WHERE w_name = ? AND w_password = ?`, [w_name, w_password]
        );
        if (admin.length > 0) {
            // Bejelentkezés sikeres
            res.status(200).json({ message: 'Dolgozó bejelentkezve!' });
        } else {
            res.status(401).json({ message: 'Hibás felhasználónév vagy jelszó! Kérjük próbálja újra!' });
        }
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a bejelentkezéskor!', error });
    }
});
// gomb szervíz
router.post('/admin/auth/login', async (req, res) => {
    const { w_name, w_password, w_permission } = req.body;
    try {
        // Ellenőrizzük a bejelentkezési adatokat (pl. jelszó ellenőrzése)
        const admin = await db.query(
            `SELECT * FROM workers WHERE w_name = ? AND w_password = ? `, [w_name, w_password]
        );
        if (admin.length > 0 || w_permission == "admin") {
            // Bejelentkezés sikeres
            res.status(200).json({ message: 'Sikeres bejelentkezés a szervíz ágba!' });
        } else {
            res.status(401).json({ message: 'Hibás felhasználónév vagy jelszó!' });
        }
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a bejelentkezés során!', error });
    }
});
//X gomb kijelentkezés ???
// Adminisztrátor kijelentkezés
router.post('/admin/auth/logout', async (req, res) => {
    // A kijelentkezést itt az alkalmazás logikájának megfelelően kell kezelni (pl. token törlés)
    res.status(200).json({ message: 'Ön kijelentkezet!' });
});
//*****Be és kijelentkezés*****//

//*****workers*****//

// worker felvitel  created_at
router.post('/workers', async (req, res) => {
    const { w_name, w_password, w_permission } = req.body;
    try {
        const result = await db.query(
            `INSERT INTO workers (w_name, w_password, w_permission)
             VALUES (?, ?, ?)`, [w_name, w_password, w_permission]
        );
        res.status(201).json({ message: 'Dolgozó hozzáadva!', eventId: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a dolgozó hozzáadásakor!', error });
    }
});

// worker frissítése
router.put('/workes/:w_id', async (req, res) => {
    const w_id = req.params.w_id;
    const { w_name, w_password, w_permission} = req.body;
    try {
        const result = await db.query(
            `UPDATE workers
             SET w_name = ?, w_password = ?, w_permission = ?
             WHERE w_id = ?`, [w_name, w_password, w_permission, w_id]
        );
        res.status(200).json({ message: 'Dolgozó adatai frissítve lettek!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt dolgozó frissítésekor!', error });
    }
});


// worker törlés
router.delete('/worker/:w_id', async (req, res) => {
    const {w_id, delete_at} = req.params.w_id;
    try {
        await db.query(`DELETE FROM workers WHERE w_id = ?`, [w_id]);
        res.status(200).json({ message: 'Dolgozó törölve lett!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt dolgozó törlése közben!', error });
    }
});

//*****Choice start*****//



// Faj választás kezelése

// Faj választás listázása /guests/all/dogs
router.get('/admin/guests/all/dogs', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT g_id, g_name, g_spacies FROM guests WHERE g_species="kutya"`   // ell.!!!!
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a Kutyák listázásakor!', error });
    }
});

router.get('/admin/guests/all/cats', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT g_id, g_name, g_spacies FROM guests WHERE g_species="macska"`    // ell.!!!!  
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a Cicák listázáskor!', error });
    }
});

//*****Choice end*****//

//*****Guest start*****//

// Új vendég hozzáadása
router.post('/admin/guests', async (req, res) => {
    const { g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image} = req.body;
    
    try {
        const result = await db.query(
            `INSERT INTO guests (g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image)
             VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`, [g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image] 
        );
        res.status(201).json({ message: 'Vendég hozzáadva!', g_Id: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég hozzáadáskor!', error });
    }
});

// Vendég frissítése
router.put('/admin/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.g_Id;
    const { g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image} = req.body;
    try {
        const result = await db.query(
            `UPDATE guests
             SET g_name = ?, g_chip = ?, g_species = ?, g_gender = ?, g_in_date = ?, g_in_place = ?, g_out_date = ?, g_adoption = ?, g_other = ?, g_image = ?
             WHERE g_id = ?`, [g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, g_Id]
        );
        res.status(200).json({ message: 'Vendég adatai frissítve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég adatainak frissítése közben!', error });
    }
});

// Vendég törlése
router.delete('/admin/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.eventId;
    try {
        await db.query(`DELETE FROM guests WHERE g_id = ?`, [g_Id]);
        res.status(200).json({ message: 'Vendég törölve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég törlése közben', error });
    }
});

//*****Guest end*****//

//*****Chip start*****//

// Chip listázása 
router.get('/admin/guests/:g_chip', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT g_name, g_spacies, g_other FROM guests WHERE g_chip = ?` 
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a chip olvasás listázása közben!', error });
    }
});

// Chip szám alapján megjegyzés frissítése
router.put('/admin/guests/:g_chip', async (req, res) => {
    const g_chip = req.params.g_chip;
    const { g_other } = req.body;
    try {
        const result = await db.query(
            `UPDATE guests
             SET g_other = ?  
             WHERE g_chip = ?`, [g_other] 
        );
        res.status(200).json({ message: 'Megjegyzés frissítve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a megjegyzés frissítéskor!', error });
    }
});

//*****Chip end*****//

module.exports = router;