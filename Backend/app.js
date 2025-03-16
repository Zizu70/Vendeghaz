const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); // Ha több domainről szeretnél hozzáférni
const WebRoutes = require('./routes/WebRoutes');  // Webes végpontok
const DesktopRoutes = require('./routes/DesktopRoutes'); // Adminisztrátori végpontok
/*const LoginRoute = require('./routes/LoginRoutes'); // A bejelentkezési route importálása
*/
const app = express();

// Middleware-ek beállítása
app.use(bodyParser.json()); // JSON formátumú kérés feldolgozása
/*app.use(bodyParser.urlencoded({ extended: true })); // Nem udom kell-e 
// tURL-enkódolt adatok */
app.use(cors());  // Ha szükséges, CORS engedélyezése






// Alapértelmezett route, ha valaki nem talál semmit
app.get('/', (req, res) => {
    res.send('Vendeghaz API működik!');
});

// Webes végpontok használata (felhasználói végpontok)
app.use('/web', WebRoutes);

// Adminisztrátori (asztali) végpontok használata
app.use('/desktop', DesktopRoutes);

// Bejelentkezési végpontok használata
/*app.use('/api', LoginRoutes);*/

// Hiba kezelő middleware
app.use((err, req, res, next) => {
    console.error(err.stack);
    res.status(500).json({ message: 'Hiba történt az alkalmazásban!' });
});

// Szerver indítása
const PORT = process.env.PORT || 3000;  // Alapértelmezett port
app.listen(PORT, () => {
    console.log(`Szerver fut a http://localhost:${PORT} porton`);
});