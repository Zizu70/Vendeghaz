const express = require('express');
const router = express.Router();
const db = require('../db');  // Feltételezve, hogy az adatbázis lekérdezések külön fájlban vannak

//*****Be és kijelentkezés*****//

// Adminisztrátor bejelentkezés           //ÁTGONDOLNI!!!!!!!
// gomb:belépés                        
router.post('/worker/auth/login', async (req, res) => {
    const { w_name, w_password } = req.body;
    try {
        // Ellenőrizzük a bejelentkezési adatokat (pl. jelszó ellenőrzése)
        const admin = await db.query(
            `SELECT * FROM workers WHERE w_name = ? AND w_password = ?`, [w_name, w_password]
        );
        if (admin.length > 0) {
            // Bejelentkezés sikeres
            res.status(200).json({ message: 'Dolgozó bejelentkezve' });
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
            res.status(200).json({ message: 'Admin bejelentkezve' });
        } else {
            res.status(401).json({ message: 'Hibás felhasználónév vagy jelszó' });
        }
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a bejelentkezés során', error });
    }
});
//X gomb kijelentkezés ???
// Adminisztrátor kijelentkezés
router.post('/admin/auth/logout', async (req, res) => {
    // A kijelentkezést itt az alkalmazás logikájának megfelelően kell kezelni (pl. token törlés)
    res.status(200).json({ message: 'Admin kijelentkeztetve!' });
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
        res.status(500).json({ message: 'Hiba történt adolgozó hozzáadásakor!', error });
    }
});

// worker frissítése
router.put('/workes/:w_id', async (req, res) => {
    const w_id = req.params.w_id;
    const { w_name, w_password, w_permission, updated_at } = req.body;
    try {
        const result = await db.query(
            `UPDATE workers
             SET w_name = ?, w_password = ?, w_permission = ?, update_at = ?
             WHERE w_id = ?`, [w_name, w_password, w_permission, updated_at, w_id]
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
        await db.query(`DELETE FROM workers WHERE w_id = ?`, [w_id, delete_at]);
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
        res.status(500).json({ message: 'Hiba történt a Vendégek listázásakor!', error });
    }
});

router.get('/admin/guests/all/cats', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT g_id, g_name, g_spacies FROM guests WHERE g_species="macska"`    // ell.!!!!  
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a Vendégek listázáskor!', error });
    }
});

//*****Choice end*****//

//*****Guest start*****//

// Új vendég hozzáadása
router.post('/admin/guests', async (req, res) => {
    const { g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at } = req.body;
    try {
        const result = await db.query(
            `INSERT INTO guests (g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at )
             VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 0)`, [g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at] //value(created_at) ???
        );
        res.status(201).json({ message: 'Vendég hozzáadva!', g_Id: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég hozzáadáskor!', error });
    }
});

// Vendég frissítése
router.put('/admin/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.g_Id;
    const { g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at } = req.body;
    try {
        const result = await db.query(
            `UPDATE guests
             SET g_name = ?, g_chip = ?, g_species = ?, g_gender = ?, g_in_date = ?, g_in_place = ?, g_out_date = ?, g_adoption = ?, g_other = ?, g_image = ?, created_at = ? 
             WHERE g_id = ?`, [g_name, g_chip, g_species, g_gender, g_in_date, g_in_place, g_out_date, g_adoption, g_other, g_image, created_at, g_Id]
        );
        res.status(200).json({ message: 'Vendég adatai frissítve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég frissítése közben!', error });
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
    const { g_name, g_spacies, g_other } = req.body;
    try {
        const result = await db.query(
            `UPDATE guests
             SET g_name = ?, g_spacies = ?, g_other = ?  
             WHERE g_chip = ?`, [g_name, g_spacies, g_other, g_chip] // kell-e g_name, g_spacies, g_chip/id
        );
        res.status(200).json({ message: 'Megjegyzés frissítve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a megjegyzés frissítéskor!', error });
    }
});

//*****Chip end*****//


//************************* */
//************************* */
// Új esemény hozzáadása
router.post('/admin/events', async (req, res) => {
    const { event_name, event_date, event_description, max_participants } = req.body;
    try {
        const result = await db.query(
            `INSERT INTO events (event_name, event_date, event_description, max_participants, current_participants)
             VALUES (?, ?, ?, ?, 0)`, [event_name, event_date, event_description, max_participants]
        );
        res.status(201).json({ message: 'Esemény hozzáadva', eventId: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az esemény hozzáadása közben', error });
    }
});

// Esemény frissítése
router.put('/admin/events/:eventId', async (req, res) => {
    const eventId = req.params.eventId;
    const { event_name, event_date, event_description, max_participants } = req.body;
    try {
        const result = await db.query(
            `UPDATE events
             SET event_name = ?, event_date = ?, event_description = ?, max_participants = ?
             WHERE event_id = ?`, [event_name, event_date, event_description, max_participants, eventId]
        );
        res.status(200).json({ message: 'Esemény frissítve' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az esemény frissítése közben', error });
    }
});

// Esemény törlése
router.delete('/admin/events/:eventId', async (req, res) => {
    const eventId = req.params.eventId;
    try {
        await db.query(`DELETE FROM events WHERE event_id = ?`, [eventId]);
        res.status(200).json({ message: 'Esemény törölve' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az esemény törlése közben', error });
    }
});


//*****Choice*****//


// Adminisztrátor bejelentkezés
router.post('/admin/auth/login', async (req, res) => {
    const { username, password } = req.body;
    try {
        // Ellenőrizzük a bejelentkezési adatokat (pl. jelszó ellenőrzése)
        const admin = await db.query(
            `SELECT * FROM admins WHERE username = ? AND password = ?`, [username, password]
        );
        if (admin.length > 0) {
            // Bejelentkezés sikeres
            res.status(200).json({ message: 'Admin bejelentkezve' });
        } else {
            res.status(401).json({ message: 'Hibás felhasználónév vagy jelszó' });
        }
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a bejelentkezés során', error });
    }
});

// Adminisztrátor kijelentkezés
router.post('/admin/auth/logout', async (req, res) => {
    // A kijelentkezést itt az alkalmazás logikájának megfelelően kell kezelni (pl. token törlés)
    res.status(200).json({ message: 'Admin kijelentkezve' });
});

// Események kezelése

// Események listázása
router.get('/admin/events', async (req, res) => {
    try {
        const events = await db.query(
            `SELECT event_id, event_name, event_date, max_participants, current_participants
             FROM events`
        );
        res.status(200).json(events);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az események listázása közben', error });
    }
});

// Események kezelése

// Események listázása
router.get('/admin/events', async (req, res) => {
    try {
        const events = await db.query(
            `SELECT event_id, event_name, event_date, max_participants, current_participants
             FROM events`
        );
        res.status(200).json(events);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az események listázása közben', error });
    }
});

// Új esemény hozzáadása
router.post('/admin/events', async (req, res) => {
    const { event_name, event_date, event_description, max_participants } = req.body;
    try {
        const result = await db.query(
            `INSERT INTO events (event_name, event_date, event_description, max_participants, current_participants)
             VALUES (?, ?, ?, ?, 0)`, [event_name, event_date, event_description, max_participants]
        );
        res.status(201).json({ message: 'Esemény hozzáadva', eventId: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az esemény hozzáadása közben', error });
    }
});

// Esemény frissítése
router.put('/admin/events/:eventId', async (req, res) => {
    const eventId = req.params.eventId;
    const { event_name, event_date, event_description, max_participants } = req.body;
    try {
        const result = await db.query(
            `UPDATE events
             SET event_name = ?, event_date = ?, event_description = ?, max_participants = ?
             WHERE event_id = ?`, [event_name, event_date, event_description, max_participants, eventId]
        );
        res.status(200).json({ message: 'Esemény frissítve' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az esemény frissítése közben', error });
    }
});

// Esemény törlése
router.delete('/admin/events/:eventId', async (req, res) => {
    const eventId = req.params.eventId;
    try {
        await db.query(`DELETE FROM events WHERE event_id = ?`, [eventId]);
        res.status(200).json({ message: 'Esemény törölve' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt az esemény törlése közben', error });
    }
});

// Felhasználók kezelése

// Felhasználók listázása
router.get('/admin/customers', async (req, res) => {
    try {
        const customers = await db.query(
            `SELECT customer_id, name, email FROM customers`
        );
        res.status(200).json(customers);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a felhasználók listázása közben', error });
    }
});

// Felhasználói adatok frissítése
router.put('/admin/customers/:customerId', async (req, res) => {
    const customerId = req.params.customerId;
    const { name, email } = req.body;
    try {
        await db.query(
            `UPDATE customers
             SET name = ?, email = ?
             WHERE customer_id = ?`, [name, email, customerId]
        );
        res.status(200).json({ message: 'Felhasználói adatok frissítve' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a felhasználói adatok frissítése közben', error });
    }
});

// Felhasználó törlése
router.delete('/admin/customers/:customerId', async (req, res) => {
    const customerId = req.params.customerId;
    try {
        await db.query(`DELETE FROM customers WHERE customer_id = ?`, [customerId]);
        res.status(200).json({ message: 'Felhasználó törölve' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a felhasználó törlése közben', error });
    }
});

// Jelentkezések kezelése

// Eseményekhez tartozó jelentkezések listázása
router.get('/admin/registrations', async (req, res) => {
    try {
        const registrations = await db.query(
            `SELECT r.registration_id, r.event_id, r.customer_id, r.registration_date, e.event_name, c.name AS customer_name
             FROM registrations r
             JOIN events e ON r.event_id = e.event_id
             JOIN customers c ON r.customer_id = c.customer_id`
        );
        res.status(200).json(registrations);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a jelentkezések listázása közben', error });
    }
});

// Jelentkezés törlése
router.delete('/admin/registrations/:registrationId', async (req, res) => {
    const registrationId = req.params.registrationId;
    try {
        const registration = await db.query(`SELECT * FROM registrations WHERE registration_id = ?`, [registrationId]);
        
        if (registration.length === 0) {
            return res.status(404).json({ message: 'Jelentkezés nem található' });
        }

        // Az esemény résztvevőinek számát csökkentjük
        const eventId = registration[0].event_id;
        await db.query(
            `UPDATE events
             SET current_participants = current_participants - 1
             WHERE event_id = ?`, [eventId]
        );

        // Jelentkezés törlése
        await db.query(`DELETE FROM registrations WHERE registration_id = ?`, [registrationId]);
        
        res.status(200).json({ message: 'Jelentkezés törölve' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a jelentkezés törlése közben', error });
    }
});

module.exports = router;