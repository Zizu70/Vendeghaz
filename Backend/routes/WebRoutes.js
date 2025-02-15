const express = require('express');
const bcrypt = require('bcrypt');
const db = require('../db'); 
const jwt = require('jsonwebtoken');
const router = express.Router();

const SECRET_KEY = process.env.JWT_SECRET || "your_secret_key"; // Biztonsági kulcs a JWT-hez

// Feltételezve, hogy az adatbázis kapcsolódás és lekérdezések külön fájlban vannak

//***** Felhasználó regisztráció, bejelentkezás, módosítás, törlés***** */
router.post('/register', async (req, res) => {
    const { username, email, password } = req.body;

    try {
        // Ellenőrizzük, hogy létezik-e már a felhasználó
        const [existingUser] = await db.query('SELECT * FROM users WHERE email = ?', [email]);
        if (existingUser.length > 0) {
            return res.status(400).json({ message: 'Ez az e-mail már regisztrálva van!' });
        }

        // Jelszó hashelése
        const hashedPassword = await bcrypt.hash(password, 10);

        // Felhasználó hozzáadása
        const result = await db.query('INSERT INTO users (username, email, password) VALUES (?, ?, ?)', 
            [username, email, hashedPassword]);

        res.status(201).json({ message: 'Sikeres regisztráció!', userId: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a regisztráció során!', error });
    }
});

// **2. Bejelentkezés**
router.post('/login', async (req, res) => {
    const { email, password } = req.body;

    try {
        // Felhasználó keresése
        const [users] = await db.query('SELECT * FROM users WHERE email = ?', [email]);
        if (users.length === 0) {
            return res.status(400).json({ message: 'Érvénytelen e-mail vagy jelszó!' });
        }

        const user = users[0];

        // Jelszó ellenőrzése
        const isMatch = await bcrypt.compare(password, user.password);
        if (!isMatch) {
            return res.status(400).json({ message: 'Érvénytelen e-mail vagy jelszó!' });
        }

        // JWT token generálás
        const token = jwt.sign({ id: user.id, email: user.email }, SECRET_KEY, { expiresIn: '1h' });

        res.status(200).json({ message: 'Sikeres bejelentkezés!', token, userId: user.id });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a bejelentkezés során!', error });
    }
});

// **3. Felhasználó módosítása**
router.put('/update/:id', async (req, res) => {
    const { id } = req.params;
    const { username, email, password } = req.body;

    try {
        let query = 'UPDATE users SET ';
        const params = [];

        if (username) {
            query += 'username = ?, ';
            params.push(username);
        }

        if (email) {
            query += 'email = ?, ';
            params.push(email);
        }

        if (password) {
            const hashedPassword = await bcrypt.hash(password, 10);
            query += 'password = ?, ';
            params.push(hashedPassword);
        }

        query = query.slice(0, -2); // Az utolsó vessző eltávolítása
        query += ' WHERE id = ?';
        params.push(id);

        await db.query(query, params);

        res.status(200).json({ message: 'Felhasználói adatok frissítve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a módosítás során!', error });
    }
});

// **4. Felhasználó törlése**
router.delete('/delete/:id', async (req, res) => {
    const { id } = req.params;

    try {
        await db.query('DELETE FROM users WHERE id = ?', [id]);
        res.status(200).json({ message: 'Felhasználó törölve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a törlés során!', error });
    }
});

//***** Felhasználó regisztráció, bejelentkezás, módosítás, törlés vége***** */

// Vendégek (összes) listázása
router.get('/guests', async (req, res) => {
    try {
        let guests = await db.query(
            `SELECT g_name, g_species, g_gender, g_other
             FROM guests`
        );
        res.status(200).json(events);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a vendégek listázáskor!', error });
    }
});

// Egy adott vendég részletes lekérdezése
router.get('/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.eventId;
    try {
        let guest = await db.query(
            `SELECT g_name, g_species, g_gender, g_other
             FROM guests
             WHERE g_id = ?`, [g_Id]
        );
        if (guest.length > 0) {
            res.status(200).json(guest[0]);
        } else {
            res.status(404).json({ message: 'Vendég nem található!' });
        }
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég adatainak lekérésekor!', error });
    }
});






//**************************************** */
//**************************************** */
// Jelentkezés egy eseményre
router.post('/events/:eventId/register', async (req, res) => {
    const eventId = req.params.eventId;
    const customerId = req.body.customer_id;  // A felhasználó ID-ja, amit a bejelentkezés során kaptunk

    try {
        // Először ellenőrizzük, hogy van-e még hely az eseményen
        let event = await db.query(
            `SELECT current_participants, max_participants
             FROM events
             WHERE event_id = ?`, [eventId]
        );
        
        if (event.length === 0) {
            return res.status(404).json({ message: 'Esemény nem található' });
        }
        
        let { current_participants, max_participants } = event[0];

        if (current_participants >= max_participants) {
            return res.status(400).json({ message: 'Nincs több hely ezen az eseményen' });
        }

        // Hozzáadjuk a felhasználót a jelentkezési táblához
        await db.query(
            `INSERT INTO registrations (event_id, customer_id)
             VALUES (?, ?)`, [eventId, customerId]
        );

        // Frissítjük az események résztvevőinek számát
        await db.query(
            `UPDATE events
             SET current_participants = current_participants + 1
             WHERE event_id = ?`, [eventId]
        );

        res.status(201).json({ message: 'Sikeresen jelentkezett az eseményre' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a jelentkezés során', error });
    }
});

// A felhasználó által jelentkezett események listázása
router.get('/events/my-events', async (req, res) => {
    const customerId = req.user.id;  // Feltételezve, hogy a felhasználó ID-ja a bejelentkezés után elérhető

    try {
        let registrations = await db.query(
            `SELECT e.event_name, e.event_date, e.event_description
             FROM registrations r
             JOIN events e ON r.event_id = e.event_id
             WHERE r.customer_id = ?`, [customerId]
        );
        res.status(200).json(registrations);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a jelentkezett események lekérése közben', error });
    }
});

module.exports = router;