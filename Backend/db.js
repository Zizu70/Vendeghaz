const mysql = require('mysql2');
require('dotenv').config();  // Környezeti változók betöltése a .env fájlból

// Adatbázis kapcsolat létrehozása
const pool = mysql.createPool({
    host: process.env.DB_HOST,
    port: process.env.DB_PORT,
    user: process.env.DB_USER,
    password: process.env.DB_PASSWORD,
    database: process.env.DATABASE,
    waitForConnections: true,  // Várakozik, ha nincs szabad kapcsolat
    connectionLimit: 10,  // Max. 10 egyidejű kapcsolat
    queueLimit: 0  // Nincs korlátozva a várakozó kapcsolatok száma
});

function query(sql, params) {
    return new Promise((resolve, reject) => {
        pool.query(sql, params, (err, results) => {
            if (err) {
                console.error("Hiba a lekérdezés végrehajtása során: ", err);
                reject(err);
            } else {
                resolve(results);
            }
        });
    });
}

// Csatlakozás tesztelése
function testConnection() {
    pool.getConnection((err, connection) => {
        if (err) {
            console.error('Hiba történt a MySQL szerverhez való csatlakozáskor: ', err.stack);
            return;
        }
        console.log('Csatlakozva a MySQL szerverhez, kapcsolat ID: ' + connection.threadId);
        connection.release();  // Szabadon engedjük a kapcsolatot, hogy újra felhasználható legyen
    });
}

module.exports = {
    query,
    testConnection
};