const express = require('express');
const router = express.Router();
const db = require('../db');  // Feltételezve, hogy az adatbázis lekérdezések külön fájlban vannak




//***** Bejelentkezés *****//
/** jó **/        //belépés gomb
router.post('/login', async (req, res) => {
    const { name, password } = req.body;

    if (!name || !password) {
        return res.status(400).json({ error: "Név és jelszó megadása kötelező!" });
    }

    try {
        const query = 'SELECT * FROM workers WHERE w_name = ? AND w_password = ? LIMIT 1';
        const result = await db.query(query, [name, password]);

        if (result.length > 0) {
            const user = result[0];
            const userRole = user.w_role; // A szerepkör lekérése

            // Ha a felhasználó szerepe "admin", akkor visszaküldjük a választ a megfelelő jogosultságokkal
            res.json({
                success: true,
                message: 'Sikeres bejelentkezés!',
                userRole: userRole,  // Szerepkör hozzáadása
                user: user
            });
        } else {
            res.status(401).json({ success: false, message: 'Hibás felhasználónév vagy jelszó!' });
        }
    } catch (err) {
        console.error('Hiba a bejelentkezés során:', err);
        res.status(500).json({ success: false, message: 'Szerverhiba!' });
    }
});

//***** Workers *****// servízbe került
/** jó **/     
router.get('/workers', async (req, res) => {  
    const w_name = req.params.w_name;
    const w_password = req.params.w_password;
    try {
        const workers = await db.query(
            `SELECT * FROM workers`, 
            [w_name,w_password]
        );
        res.status(200).json(workers);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a dolgozó lekérésekor!', error });
    }
});


/*M ez jó így*/
/*
router.post('/login', async (req, res) => {  
    
        const { name, password } = req.body;

        if (!name || !password) {
            return res.status(400).json({ error: "Név és jelszó megadása kötelező!" });
        }

        try {
            const query = 'SELECT * FROM workers WHERE w_name = ? AND w_password = ? LIMIT 1';
            const result = await db.query(query, [name, password]);
    
            if (result.length > 0) {
                res.json({ success: true, message: 'Sikeres bejelentkezés!', user: result[0] });
            } else {
                res.status(401).json({ success: false, message: 'DeskRoutHibás felhasználónév vagy jelszó!' });
            }
        } catch (err) {
            console.error('Hiba a bejelentkezés során:', err);
            res.status(500).json({ success: false, message: 'Szerverhiba!' });
        }
    });
    */




    // Jelszó titkosítása új dolgozó hozzáadásakor
router.post("/register", async (req, res) => {
    const { name, password, role } = req.body;

    if (!name || !password || !role) {
        return res.status(400).json({ message: "Minden mező kitöltése kötelező!" });
    }

    try {
        const salt = await bcrypt.genSalt(10);
        const hashedPassword = await bcrypt.hash(password, salt);

        await db.query("INSERT INTO workers (w_name, w_password, w_role) VALUES (?, ?, ?)", [name, hashedPassword, role]);
        
        res.status(201).json({ message: "Felhasználó sikeresen létrehozva!" });
    } catch (error) {
        res.status(500).json({ message: "Szerverhiba", error: error.message });
    }
    
       // Ellenőrizzük a bejelentkezési adatokat (név-jelszó ellenőrzése)
      /*
       try {
            const [admin] = await db.query(
            /*`SELECT * FROM workers WHERE w_name = ? AND w_password = ?`, [w_name, w_password]
            ;
        );
        if (admin.length > 0) {
            // Bejelentkezés sikeres
            res.status(200).json({ message: 'Dolgozó bejelentkezve!' });
        } else {
            res.status(401).json({ message: 'Hibás felhasználónév vagy jelszó! Kérjük próbálja újra!' });
        } 
        */
    /*} catch (error) {
        res.status(500).json({ message: 'Hiba történt a bejelentkezéskor!', error });
        
    }*/
});


// gomb szervíz
router.post('/admin/auth/login', async (req, res) => {
    const { w_name, w_password, w_role } = req.body;
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
/*
router.get('/workers', async (req, res) => {
    
    try {
        const workers = await db.query(
            `SELECT * FROM workers `
        );
        res.status(200).json(workers);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a dolgozó lekérésekor!', error });
    }
});
*/

// worker felvitel  created_at 
/*
router.post('/workers', async (req, res) => {
    const { w_name, w_password, w_permission } = req.body;
    try {
        const result = await db.query(
            `INSERT INTO workers (w_name, w_password, w_permission)
             VALUES (?, ?, ?)`, [w_name, w_password, w_permission]
        );
        res.status(201).json({ message: 'Dolgozó hozzáadva!', w_id: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a dolgozó hozzáadásakor!', error });
    }
});
*/
// worker frissítése
router.put('/workers/:w_id', async (req, res) => {
    const w_id = req.params.w_id;
    const { w_name, w_password, w_role} = req.body;
    try {
        const result = await db.query(
            `UPDATE workers
             SET w_name = ?, w_password = ?, w_role = ?
             WHERE w_id = ?`, [w_name, w_password, w_permission, w_id]
        );
        res.status(200).json({ message: 'Dolgozó adatai frissítve lettek!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt dolgozó frissítésekor!', error });
    }
});


// worker törlés
router.delete('/worker/:w_id', async (req, res) => {
    const {w_id, deleted_at} = req.params.w_id;
    try {
        await db.query(`DELETE FROM workers WHERE w_id = ?`, [w_id, deleted_at]);
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

//*****Adaption top*****//
   //**ok**//
   // Összes örökbefogadás lekérése
router.get('/adoption', async (req, res) => {
    
    try {
        const adoption = await db.query(
            `SELECT * FROM adoption `
        );
        res.status(200).json(adoption);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a dolgozó lekérésekor!', error });
    }
});
   //**ok**//
   // Összes vendég nevének lekérése
router.get('/allGuests', async (req, res) => {
    try {
        const results = await db.query(
            `SELECT g_name FROM guests`   // ell.!!!!
        );
        res.status(200).json(results);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a vendégek listázásakor!', error });
    }
});
   //**ok**//
   // Összes felhasználó nevének lekérése
router.get('/allUsers', async (req, res) => {
    try {
        const result = await db.query(
            `SELECT u_name FROM users`   
        );
        res.status(200).json(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a felhasználók listázásakor!', error });
    }
});

// Vendég adatainak lekérése név alapján
router.get('/guest/:guestname', async (req, res) => {  
    const { guestname } = req.params;

    try {
        const guestName  = req.params.name;
        const result = await db.query(
            'SELECT g_name, g_species, g_gender, g_image FROM guests WHERE g_name = ?',
            [guestname]
        );

        if (result.length > 0) {
            res.json(result[0]); // Az első találatot küldi vissza
        } else {
            res.status(404).json({ message: "Vendég nem található" });
        }
    } catch (err) {
        console.error('Hiba a vendég lekérdezés során:', err);
        res.status(500).json({ message: "Szerverhiba" });
    }
});

// Felhasználó adatainak lekérése név alapján
router.get('/user/:username', async (req, res) => {
    const { username } = req.params;

    try {
        const userName  = req.params.name;
        const result = await db.query(
            'SELECT u_name, u_email FROM users WHERE u_name = ?',
            [username]
        );

        if (result.length > 0) {
            res.json(result[0]); // Az első találatot küldi vissza
        } else {
            res.status(404).json({ message: "Felhasználó nem található" });
        }
    } catch (err) {
        console.error('Hiba a lekérdezés során:', err);
        res.status(500).json({ message: "Szerverhiba" });
    }
});







router.post('/adoption', async (req, res) => {
    const { a_date, g_name, u_name} = req.body;
    
    try {
        const result = await db.query(
            `INSERT INTO adoption (a_date, g_name, u_name)
             VALUES ( ?, ?, ?)`, [a_date, g_name, u_name] 
        );
        res.status(201).json({ message: 'Támogatói örökbefogadás rögzítve!', g_Id: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a támogatói örökbefogadás rögzítésekor!', error });
    }
});

//*****Adaption end*****//
module.exports = router;