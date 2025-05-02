const express = require('express');
const router = express.Router();
const db = require('../db');  // Feltételezve, hogy az adatbázis lekérdezések külön fájlban vannak
 


   //***** Bejelentkezés *****//

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

   //***** Bejelentkezés *****//

   //***** Choice *****//  

   // Választott csoport listázása
   //nagyvadak
router.get('/guests/allLarge', async (req, res) => {
    try {
        const guests = await db.query(
            `SELECT * FROM guests WHERE g_species IN ('medve','farkas','muflon','őz','gím_szarvas','vaddisznó')`,   // ell.!!!!
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
            `SELECT * FROM guests WHERE g_species IN ('ló','szamár','tehén','mangalica','baromfiak')`,  
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
            `SELECT * FROM guests WHERE g_species IN ('dám_szarvas','juh','kecske','nyúl','póniló')`,  
        );
        res.status(200).json(guests);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a simogató listázásakor!', error });
    }
});
   //***** Choice *****//

   //***** Guest *****// 

   // Összes vendég lekérdezése
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
  
   // Vendég hozzáadása
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

   // Vendég törlése // 
router.delete('/guests/:g_Id', async (req, res) => {
    const g_Id = req.params.g_Id;

    try {
        await db.query(`DELETE FROM guests WHERE g_id = ?`, [g_Id]);
        res.status(200).json({ message: 'Vendég törölve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt Vendég törlése közben', error });
    }
});
   //***** Guest *****//

   //***** Adoption *****// 
 
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
 
   // Összes vendég nevének lekérése comboBoxba
router.get('/allGuests', async (req, res) => {
    try {
        const results = await db.query(
            `SELECT g_name, g_id FROM guests`   // ell.!!!!
        );
        res.status(200).json(results);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a vendégek listázásakor!', error });
    }
});
   
   // Összes felhasználó nevének lekérése comboBoxba
router.get('/allUsers', async (req, res) => {
    try {
        const result = await db.query(
            `SELECT u_name, u_id FROM users`   
        );
        res.status(200).json(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a felhasználók listázásakor!', error });
    }
}); 

   // Örökbefogadott adatainak lekérése név alapján
router.get('/adopted/:guestname', async (req, res) => {  
    const guestname = req.params.guestname;
    
    try {
        const [row] = await db.query(
           'SELECT g_id, g_name, g_species, g_gender, g_birthdate, g_image FROM guests WHERE g_name = ?',
            [guestname]
        );
        res.json(row);
    } catch (error) {
        res.status(500).json({ message: 'Szerverhiba - Örökbefogadott adatainak letöltése közben!', error });
    }
});
 
   // Örökbefogadó adatainak lekérése név alapján
router.get('/adoptive/:username', async (req, res) => {
    const u_name = req.params.username;

    console.log("Lekérdezett felhasználónév:", u_name);

    try {
        const [rows] = await db.query(
            `SELECT u_id, u_name, u_email FROM users WHERE u_name = ?`,
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

   // Örökbefogadás felvitel
router.post('/adoption', async (req, res) => {
    const { g_id, u_id, a_date} = req.body;
    
    try {
        const result = await db.query(
            `INSERT INTO adoption (g_id, u_id)
             VALUES ( ?, ? )`, [g_id, u_id] 
        );

        // 	g_name 	g_species 	g_gender 	g_birthdate 	{g_indate 	g_inplace} 	u_id 	u_name 	
        res.status(201).json({ message: 'Támogatói örökbefogadás rögzítve!', g_Id: result.insertId });
        console.table(result);
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a támogatói örökbefogadás rögzítésekor!', error });
    }
});
   //*****Adoption *****//

   //***** Contract *****//

   // Oklevél felvitel
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
   //***** Contract *****//

   //***** Ticket *****//  

   // Összes jegyrendelés
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
 
   // Összes jegyrendelések id lekérése comboBoxba
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

   // Jegyrendelés adatainak lekérése 
router.get('/tickets/:ticketid', async (req, res) => {  
    const ticketid = req.params.ticketid;
    
    try {
        const [row] = await db.query(
            `SELECT tickets.*, users.u_name, users.u_email
            FROM tickets
            JOIN users ON tickets.u_id = users.u_id
            WHERE tickets.t_id = ?`, [ticketid]
        );
        res.json(row);
    } catch (error) {
        res.status(500).json({ message: 'Szerverhiba - Örökbefogadott adatainak letöltése közben!', error });
    }
});
 
   // Jegyrendelés módosítás
   router.put('/tickets/:t_Id', async (req, res) => {
    const t_Id = req.params.t_Id;
    const { t_date, t_time, t_piece, t_amount} = req.body;
    try {
        const result = await db.query(
            `UPDATE tickets
             SET t_date = ?, t_time = ?, t_piece = ?, t_amount = ?
             WHERE t_id = ?`, [t_date, t_time, t_piece, t_amount, t_Id]
        );
        res.status(200).json({ message: 'Jegyrendelés adatai frissítve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt jegyrendelés adatainak frissítése közben!', error });
    }
});
 
   // Jegyrendelés törlése
router.delete('/tickets/:t_Id', async (req, res) => {
    const t_Id = req.params.t_Id;
    try {
        await db.query(`DELETE FROM tickets WHERE t_id = ?`, [t_Id]);
        res.status(200).json({ message: 'Jegyrendelés törölve!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a jegyrendelés törlése közben', error });
    }
});
   //***** Ticket *****//

   //***** Service *****//

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
 
   // Névellenőrzés felvitelhez 
router.post("/checkname", async (req, res) => {
  const { name } = req.body;

  if (!name) {
    return res.status(400).json({ success: false, message: "Név hiányzik!" });
  }

  try {
    const result = await db.query("SELECT * FROM workers WHERE LOWER(w_name) = LOWER(?)", [name]);

    if (result.length > 0) {
      return res.status(200).json({ exists: true, message: "A név már létezik az adatbázisban." });
    } else {
      return res.status(200).json({ exists: false, message: "A név még nem szerepel az adatbázisban." });
    }
  } catch (err) {
    console.error("Adatbázis hiba:", err);
    res.status(500).json({ success: false, message: "Szerverhiba!" });
  }
});

  // worker felvitel 
router.post('/services', async (req, res) => {
    const { w_name, w_password, w_role } = req.body;

    console.log("Bejövő dolgozó:", req.body);

    try {
        const result = await db.query(
            `INSERT INTO workers (w_name, w_password, w_role)
             VALUES (?, ?, ?)`, [w_name, w_password, w_role]
        );
        res.status(201).json({ message: 'Dolgozó hozzáadva!', w_id: result.insertId });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt a dolgozó hozzáadásakor!', error });
    }
});

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

   // worker törlés
router.delete('/services/:w_name', async (req, res) => {
    const w_name = req.params.w_name;

    try {
        await db.query(`DELETE FROM workers WHERE w_name = ?`, [w_name]);

        res.status(200).json({ message: 'Dolgozó törölve lett!' });
    } catch (error) {
        res.status(500).json({ message: 'Hiba történt dolgozó törlése közben!', error });
    }
});
   //***** Service *****//


module.exports = router;