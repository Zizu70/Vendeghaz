const express = require('express');
const router = express.Router();
const db = require('../db');  // Feltételezve, hogy az adatbázis lekérdezések külön fájlban vannak




//***** Bejelentkezés *****//
   //**ok**//
   //belépés gomb
router.post('/login', async (req, res) => {
    const { name, password } = req.body;

    if (!name || !password) {
        return res.status(400).json({ error: "Név és jelszó megadása kötelező!" });
    }

    try {
        const query = 'SELECT * FROM workers WHERE BINARY w_name = ? AND BINARY w_password = ? LIMIT 1';
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

//***** Szervíz *****//
   //** ok **//
   // Összes dolgoző lekérdezése
router.get('/workers', async (req, res) => {
    try {
        const result = await db.query(
            `SELECT * FROM workers`   
        );
        res.status(200).json(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a vendégek listázásakor!', error });
    }
});

   //**ok**//
/*router.get('/workers', async (req, res) => {  
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
});*/
   //**ok**//
   // Szervíz belépés - belépés gomb
router.post("/services", async (req, res) => {
    const { name, password } = req.body;
  
    if (!name || !password) {
      return res.status(400).json({ success: false, message: "Hiányzó adatok" });
    }
  
    try {
      const [rows] = await db.query(
        "SELECT * FROM workers WHERE BINARY w_name = ? AND BINARY w_password = ? AND w_role = 'admin'",
        [name, password]
      );
  
      if (rows.length === 0) {
        return res.status(401).json({
          success: false,
          message: "Hibás név, jelszó, vagy nincs admin jogosultság!",
        });
      }
  
      res.status(200).json({
        success: true,
        message: "Sikeres admin bejelentkezés!",
        /*user: {
          id: rows[0].id, 
          w_name: rows[0].w_name,
          w_password: rows[0].w_password,
          w_role: rows[0].w_role,
        },
        */
      });
    } catch (err) {
      console.error("Bejelentkezési hiba:", err);
      res.status(500).json({ success: false, message: "Szerverhiba" });
    }
  });

// Névellenőrzés felvitelhez
router.post("/checkname", async (req, res) => {
  const { name } = req.body;

  /*if (!name) {
    return res.status(400).json({ success: false, message: "Név hiányzik!" });
  }*/

  try {
    const [rows] = await conn.query("SELECT * FROM workers WHERE w_name = ?", [name]);

    if (rows.length > 0) {
      return res.status(200).json({ exists: true, message: "A név már létezik az adatbázisban." });
    } else {
      return res.status(200).json({ exists: false, message: "A név még nem szerepel az adatbázisban." });
    }
  } catch (err) {
    console.error("Adatbázis hiba:", err);
    res.status(500).json({ success: false, message: "Szerverhiba!" });
  }
});



  //**   **//
  // worker felvitel  created_at 
router.post('/services', async (req, res) => {
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

   //** **//
   // worker frissítése
router.put('/services/:w_name', async (req, res) => {
    const w_name = req.params.w_name;
    const {w_password, w_role} = req.body;
    try {
        const result = await db.query(
            `UPDATE workers
             SET w_password = ?, w_role = ?
             WHERE w_name = ?`, [ w_password, w_role, w_name]
        );
        res.status(200).json({ message: 'Dolgozó adatai frissítve lettek!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt dolgozó frissítésekor!', error });
    }
});

   //**  **//
   // worker törlés
router.delete('/services/:w_name', async (req, res) => {
    const {w_name, delete_at} = req.params.w_name;
    try {
        await db.query(`DELETE FROM workers WHERE w_name = ?`, [w_name, delete_at]);
        res.status(200).json({ message: 'Dolgozó törölve lett!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt dolgozó törlése közben!', error });
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



//*****Choice Start*******************************************//

// Csoport választás kezelése
// Választott csoport listázása 
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
// Vendég törlése nem
router.delete('/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.eventId;
    try {
        await db.query(`DELETE FROM guests WHERE g_id = ?`, [g_Id]);
        res.status(200).json({ message: 'Vendég törölve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég törlése közben', error });
    }
});
// Vendég törlése soft delete-tel
router.put("/guests/:g_Id", async (req, res) => {
    const guestId = req.params.g_Id;
    const currentDateTime = new Date();
  
    try {
      const [result] = await conn.query(
        "UPDATE guests SET deleted_at = ? WHERE g_id = ? AND deleted_at IS NULL",
        [currentDateTime, guestId]
      );
  
      if (result.affectedRows === 0) {
        return res.status(404).json({ message: "Nincs ilyen aktív vendég vagy már törölve lett." });
      }
  
      res.json({ message: "Vendég törölve (soft delete)", timestamp: currentDateTime });
    } catch (err) {
      console.error("Soft delete hiba:", err);
      res.status(500).json({ message: "Szerverhiba történt a soft delete során." });
    }
  });

//*****Guest end****************************************************************************//

//*****Adaption top - OK   ****************************AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA*************//
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
   // Összes vendég nevének lekérése comboBoxba
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
   // Összes felhasználó nevének lekérése comboBoxba
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
   //**ok** nem kell ide **//
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
   //**ok**//
   // Örökbefogadott adatainak lekérése név alapján
router.get('/adopted/:guestname', async (req, res) => {  
    const guestname = req.params.guestname;
    
    try {
        const [row] = await db.query(
           'SELECT g_name, g_species, g_gender, g_birthdate, g_image FROM guests WHERE g_name = ?',
            [guestname]
        );
        res.json(row);
    } catch (error) {
        res.status(500).json({ message: 'Szerverhiba - Örökbefogadott adatainak letöltése közben!', error });
    }
});
   //**ok**//
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
   //**ok**//
   // Örökbefogadás mentése
router.post('/adoption', async (req, res) => {
    const { g_name, g_species, g_gender, g_birthdate, u_name, a_date} = req.body;
    
    try {
        const result = await db.query(
            `INSERT INTO adoption (g_name, g_species, g_gender, g_birthdate, u_name, a_date)
             VALUES ( ?, ?, ?, ?, ?, ?)`, [g_name, g_species, g_gender, g_birthdate, u_name, a_date] 
        );
        res.status(201).json({ message: 'Támogatói örökbefogadás rögzítve!', g_Id: result.insertId });
        console.table(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a támogatói örökbefogadás rögzítésekor!', error });
    }
});

//*****Adaption end********************************AAAAAAAAAAAAAAAAAAAAAAAVVVVVVVVVVVVVVVVVVVVVVVVV**//

//*****Contract top - OK ********************************CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC*****//
router.get('/contract', (req, res) => {
    const { g_name, u_name, a_date } = req.query;
  
    if (!g_name || !u_name || !a_date) {
      return res.status(400).json({ message: 'Hiányzó paraméter(ek): g_name, u_name vagy a_date' });
    }
  
    const sql = `
      SELECT 
        g.g_name,
        g.g_species,
        g.g_gender,
        g.g_birthdate,
        u.u_name,
        u.u_email,
        a.a_date
      FROM adoption a
      JOIN guests g ON a.guest_id = g.guest_id
      JOIN users u ON a.user_id = u.user_id
      WHERE g.g_name = ? AND u.u_name = ? AND a.a_date = ?
    `;
  
    db.query(sql, [g_name, u_name, a_date], (err, results) => {
      if (err) {
        console.error('Hiba az adatbázis lekérdezés során:', err);
        return res.status(500).json({ message: 'Szerverhiba' });
      }
  
      if (results.length === 0) {
        return res.status(404).json({ message: 'Nem található ilyen örökbefogadás' });
      }
  
      res.json(results); // csak egy rekordra számítunk
    });
  });

//*****Contract top********************************CCCCCCCCCCCCCCCCCCCCCCCCCCVVVVVVVVVVVVVVVVVVVVVVV*****//

//***** Ticket *************************************//
   //** **//
   // Összes foglalás
router.get('/tickets', async (req, res) => {
    
    try {
        const tickets = await db.query(
            `SELECT * FROM tickets`
        );
        res.status(200).json(tickets);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a jegyek lekérésekor!', error });
    }
});
   //**ok**//
   // Összes rendelés lekérése comboBoxba
   router.get('/allTickets', async (req, res) => {
    try {
        const results = await db.query(
            `SELECT t_id FROM tickets`   
        );
        res.status(200).json(results);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a jegy rendelések listázásakor!', error });
    }
});
   //**  **//
   // Jegyrendelés adatainak lekérése név alapján
   router.get('/tickets/:ticketid', async (req, res) => {  
    const ticketid = req.params.ticketid;
    
    try {
        const [row] = await db.query(
           'SELECT * FROM tickets WHERE t_id = ?',
            [ticketid]
        );
        res.json(row);
    } catch (error) {
        res.status(500).json({ message: 'Szerverhiba - Örökbefogadott adatainak letöltése közben!', error });
    }
});
//***** Ticket *************************************//

module.exports = router;