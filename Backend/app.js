const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); // Ha több domainről szeretnél hozzáférni
const WebRoutes = require('./routes/WebRoutes');  // Webes végpontok
const DesktopRoutes = require('./routes/DesktopRoutes'); // Asztali alk. végpontok

//dotenv.config(); cg

const usersRoutes = require('./routes/users');
const guestsRoutes = require('./routes/guests');
const workersRoutes = require('./routes/workers');
const adoptionRoutes = require('./routes/adoption');
const ticketsRoutes = require('./routes/tickets');
const workersGuestsRoutes = require('./routes/workersGuests');
const authRoutes = require('./routes/auth');

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


// Asztali végpontok használata
app.use('/desktop', DesktopRoutes);


// Szervíz végpont használata
//app.use('/services', ServiceRoutes); 
app.use('/api/auth', authRoutes); // Auth route for login and registration
app.use('/api/users', usersRoutes);
app.use('/api/guests', guestsRoutes);
app.use('/api/workers', workersRoutes);
app.use('/api/adoption', adoptionRoutes);
app.use('/api/tickets', ticketsRoutes);
app.use('/api/workers-guests', workersGuestsRoutes);


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
