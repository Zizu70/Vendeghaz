# 🐾 Vendégház Vadaspark Projekt 🐾

**Projekt célja:**  
A Vendégház Vadaspark napi munkájának támogatása webes és asztali alkalmazáson keresztül. Az alkalmazás segíti a látogatókat az örökbefogadásban és tájékozódásban, míg a dolgozók számára lehetővé teszi az állatok adminisztrációját, támogatói örökbefogadási ügyintézését dolgozók adatainak kezelését.

## 1. Célok, felhasználók, feladatok

### Webes alkalmazás célja

A látogatók számára lehetőséget biztosítani, hogy:
- Megismerjék a Vadaspark munkáját és célkitűzéseit
- Megtekinthessék támogatói örökbefogadás feltételeit
- Jelentkezzenek támogatónak 
- Önkéntesként segíthessék munkánkat

#### Webes funkciók:
- **Főoldal**
  - Bemutatkozás
  - Vadaspark bemutatása
  - Jegyvásárlás
- **Vendégeink**
  - Vendégeink megtekintése
- **Támogatói örökbefogadás**
  - Feltételek megtekintése
  - Jelentkezési űrlap
- **Bejelentkezés / Regisztráció**
- **Kapcsolat**

### Asztali alkalmazás célja

A dolgozók munkáját támogatja az alábbi területeken:
- Állatok adatainak kezelése
- Támogatói örökbefogadási folyamat dokumentálása, oklevél készítése
- Jegyvásárlás kezelése
- Dolgozók adatainak kezelése

#### Asztali funkciók:
- Bejelentkezés (dolgozói/admin)
- Munkamenet választása
- **Vendégeink**
  - Adatok megtekintése és szerkesztése
- **Támogatói örökbefogadás**
  - Támogatói örökbefogadás rögzítés
  - Örökbefogadói oklévél készítése, mentése
- **Jegyrendelés kezelése**
  - Jegyrendelés kezelése

> **Adatok tárolása:**  
> Az adatok a `vendeghaz.sql` MySQL adatbázisban kerülnek tárolásra.  
> A webes és az asztali alkalmazás is aszinkron módon, REST API végpontokon keresztül éri el az adatokat a backend segítségével,  
> így biztosítva a gyors és megbízható adatkommunikációt.

## 2. Felhasználói felületek

A rendszer két modulból áll:
- **Webes felület** – látogatók számára
- **Asztali alkalmazás** – dolgozók számára

Mindkét modul a backend segítségével kapcsolódik az adatbázishoz.

## 3. Tesztelés és felhasználói betanítás

- Folyamatok gyakorlati tesztelése
- Hibák feltárása és javítása
- Optimalizálás
- Felhasználók betanítása

## 4. Felhasznált technológiák és eszközök

| Rész             | Technológia                    |
|------------------|--------------------------------|
| **Backend**      | Express, Node.js               |
| **Frontend**     | React, HTML, Bootstrap, JS     |
| **Desktop App**  | C#, .NET Windows Forms         |
| **Verziókezelés**| GitHub                         |
| **Adatbázis**    | MySQL                          |


## Projektinformációk

- **Projekt neve:** Vendégház  
- **Készítő:** Szebeni Zita
- **2025-ös szakmai vizsgaremek**
