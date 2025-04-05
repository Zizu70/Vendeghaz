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
        res.status(500).json({ success: false, message: 'BE Szerverhiba!' });
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

//*****Choice start***********************************************************************//
// Csoport választás kezelése

// Csoport választás listázása 
   //nagyvadak
router.get('/guests/allLarge', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT * FROM guests WHERE g_species IN ('medve','farkas','muflon','őz','gímszarvas')`,   // ell.!!!!
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a nagyvadak listázásakor!', error });
    }
});

   //apróvadak   
router.get('/guests/allSmall', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT * FROM guests WHERE g_species IN ('róka','vadmacska','hiúz','aranysakál','mosómedve')`,   // ell.!!!!
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a nagyvadak listázásakor!', error });
    }
});

   //madarak
router.get('/guests/allBird', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT * FROM guests WHERE g_species IN ('sas','bagoly','páva','holló','vércse','varjú')`,   // ell.!!!!
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a apróvadak listázásakor!', error });
    }
});

   //parasztudvar
router.get('/guests/allYard', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT * FROM guests WHERE g_species IN ('ló','szamár','tehén','mangalica','baromfiak')`,   // ell.!!!!
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a paraszt udvar listázásakor!', error });
    }
});

   //simogató
router.get('/guests/allStoking', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT * FROM guests WHERE g_species IN ('dámszarvas','juh','kecske','nyúl','póniló')`,   // ell.!!!!
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a simogató listázásakor!', error });
    }
});
//*****Choice end**************************************************************************//

//*****Guest start*************************************************************************//

// Vendégek lekérdezése
router.get('/guests', async (req, res) => {
    try {
        const result = await db.query(
            `SELECT * FROM guests`   
        );
        res.status(200).json(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a vendégek listázásakor!', error });
    }
});
// Új vendég hozzáadása
router.post('/guests', async (req, res) => {
    const { g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, g_image} = req.body;
    
    try {
        const result = await db.query(
            `INSERT INTO guests (g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, g_image)
             VALUES (?, ?, ?, ?, ?, ?, ?, ?)`, [g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, g_image] 
        );
        res.status(201).json({ message: 'Vendég hozzáadva!', g_Id: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég hozzáadáskor!', error });
    }
});
// Vendég módosítása
router.put('/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.g_Id;
    const { g_name, g_species, g_gender, g_birthdate, g_indate,  g_inplace,g_other, g_image} = req.body;
    try {
        const result = await db.query(
            `UPDATE guests
             SET g_name = ?, g_species = ?, g_gender = ?, g_birthdate = ?, g_indate = ?, g_inplace = ?, g_other = ?, g_image = ?
             WHERE g_id = ?`, [g_name, g_species, g_gender, g_birthdate, g_indate, g_inplace, g_other, g_image, g_Id]
        );
        res.status(200).json({ message: 'Vendég adatai frissítve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég adatainak frissítése közben!', error });
    }
});
// Vendég törlése
router.delete('/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.eventId;
    try {
        await db.query(`DELETE FROM guests WHERE g_id = ?`, [g_Id]);
        res.status(200).json({ message: 'Vendég törölve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég törlése közben', error });
    }
});

//*****Guest end****************************************************************************//

//*****Chip start**************************************************************************//

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

//*****Adaption top****************************AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA*************//
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
//**ok**//
   // Összes vendég nevének lekérése // nem kell
   router.get('/guests', async (req, res) => {
    try {
        const result = await db.query(
            `SELECT * FROM guests`   
        );
        res.status(200).json(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a vendégek listázásakor!', error });
    }
//**ok**//
   // Összes felhasználó nevének lekérése // nem kell
   router.get('/users', async (req, res) => {
    try {
        const result = await db.query(
            `SELECT * FROM users`   
        );
        res.status(200).json(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a felhasználók listázásakor!', error });
    }
});});
// Örökbefogadott adatainak lekérése név alapján


// Marcival Örökbefogadott adatainak lekérése név alapján
router.get('/guests/:guestname', async (req, res) => {  
    const guestname = req.params;  //const { guestname } = req.params;

    try {
        //const guestname  = req.params;
        const [row] = await db.query(
            'SELECT g_name, g_species, g_gender, g_image FROM guests WHERE g_name = ?',
            [guestname]
        );

        //if (result.length > 0) {
            //res.json(result[0]); // Az első találatot küldi vissza
        //}
         //else {
            res.status(404).json({ message: "Örökbefogadott nem található" });
        //}
    } catch (err) {
        console.error('Hiba a örökbefagadott állat lekérdezése során:', err);
        res.status(500).json({ message: "Szerverhiba" });
    }
});

// Marcival Örökbefogadó adatainak lekérése név alapján
router.get('/users/:username1', async (req, res) => {
    const u_name = req.params.username1;

    console.log("Lekérdezett felhasználónév:", u_name);

    try {
        const [rows] = await db.query(
            `SELECT u_name, u_email FROM users WHERE u_name = ?`,
            [u_name]
        );
        res.json(rows);
        //console.log("SQL: SELECT u_name, u_email FROM users WHERE u_name = ?");
        console.table(rows);  // terminálra info
        /*
        if (rows.length > 0) {
            res.json(rows[0]);
        } else {
            res.status(404).json({ message: "Felhasználó nem található" });
        }
        */
    } catch (err) {
        console.error('Hiba az örökbefogadó lekérdezés során:', err);
        res.status(500).json({ message: "Szerverhiba" });
    }
});

// Örökbefogadó adatainak lekérése név alapján
router.get('/adoptive/:username', async (req, res) => {
    const u_name = req.params.username;

    console.log("Lekérdezett felhasználónév:", u_name);

    try {
        const [rows] = await db.query(
            `SELECT u_name, u_email FROM users WHERE u_name = ?`,
            [u_name]
        );
        res.json(rows);
        //console.log("SQL: SELECT u_name, u_email FROM users WHERE u_name = ?");
        console.table(rows);  // terminálra info
        /*
        if (rows.length > 0) {
            res.json(rows[0]);
        } else {
            res.status(404).json({ message: "Felhasználó nem található" });
        }
        */
    } catch (err) {
        console.error('Hiba az örökbefogadó lekérdezés során:', err);
        res.status(500).json({ message: "Szerverhiba" });
    }
});

router.get('/adopted/:guestname', async (req, res) => {
    const guestname = req.params.guestname;
    
    try {
        const [row] = await db.query(
           'SELECT g_name, g_species, g_gender, g_image FROM guests WHERE g_name = ?',
            [guestname]
        );
        res.json(row);
    } catch (error) {
        res.status(500).json({ message: 'Szerverhiba - Örökbefogadott adatainak letöltése közben!', error });
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
        console.table(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a támogatói örökbefogadás rögzítésekor!', error });
    }
});

//*****Adaption end********************************AAAAAAAAAAAAAAAAAAAAAAAVVVVVVVVVVVVVVVVVVVVVVVVV**//

module.exports = router;