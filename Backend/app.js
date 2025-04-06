const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); // Ha több domainről szeretnél hozzáférni
const WebRoutes = require('./routes/WebRoutes');  // Webes végpontok
const DesktopRoutes = require('./routes/DesktopRoutes'); // Asztali alk. végpontok

const LoginRoutes = require('./routes/LoginRoutes'); // A bejelentkezéshez útvonal
const ServiceRoutes = require('./routes/ServiceRoutes'); // Szervízhez Admin útvonal const kisbetű - req nagybetű

//dotenv.config(); cg



const app = express();
//const port = 3000; cg kell-e


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

// Asztali végpontok használata
app.use('/desktop', DesktopRoutes);

// Bejelentkezés végpont használata
app.use('/login', LoginRoutes);

// Szervíz végpont használata
app.use('/services', ServiceRoutes); 


// Hiba kezelő middleware
app.use((err, req, res, next) => {
    console.error(err.stack);
    res.status(500).json({ message: 'Hiba történt az alkalmazásban!' });
});


// Szerver indítása
const PORT = process.env.PORT || 3000;  // Alapértelmezett port
app.listen(PORT, () => {
    console.log(`Szerver a http://localhost:${PORT} porton fut.`);
});
