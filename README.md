# Szebeni Zita - Vendégház Menedék projekt

A projekt a Vendégház Menedék napi munkájának segítésére szolgál mely mind a webes felhasználókat, mind a dolgzók menhelyi munkáját segíti adminisztráció területén.

# 1. Célok, felhasználók, feladatok

    A projekt webes alkalmazásának feladata, hogy a Menedék látogatói és felhasználói a  megismerhessék munkánkat, célkitűzéseinket, megismerhessék "vendégeinket", akiket örökbe is fogadhatnak, segítséget nyújthatnak munkánkban, illetve segítséget kaphassanak tőlünk a talált állatkák chipes beazonosításával az állat gazdájának megtalálásában. Itt nézhető meg a sikertörténetünk is, a már szerető gazdára leltek csapata.

    Fentiek alapján az alábbi feladatok ellátását a web alkalmazás teljesíti:

    ⦁	Főoldal
        ⦁	Bemutatkozás
        ⦁	Segítségnyújtás
        ⦁	Sikertörténetek
    ⦁	Vendégeink
        ⦁	Vendégeink megtekintése és innen az
            ⦁	Egyén adataihoz
    ⦁	Örökbefogadás 
        ⦁	Örökbefogadás feltételek megtekintése, jelentkezés elküldése
    ⦁	Bejelentkezés vagy regisztráció 
        ⦁	Bejelentkezés 
        ⦁	Regisztráció 
    ⦁	Kapcsolat 

    A projekt asztali alkalmazásának feladata, hogy a Menedék dolgozói, munkájuk során több területen  kezeljék és feldolgozzák a beérkező adatokat. 
    Fő feladatunk: Vendégeink, azaz a hozzánk érkező kutyák és cicák adatainak kezelése, feldolgozása, örökbefogadásuk intézése és chipes beazonosításuk.
     
    Fentiek alapján az alábbi feladatok ellátását az asztali alkalmazás teljesíti:

    ⦁	Bejelentkezés -  dolgozók, admin részére
    ⦁	Munkamenet választása 
    ⦁	Vendégeink
        innen jutunk el:
        ⦁	Vendégeink oldalra és innen az
        ⦁	Egyén adataihoz
    ⦁	Örökbefogadás 
        innen jutunk el:
        ⦁	Örökbefogadás rögzítéséhez, majd innen az
        ⦁	Örökbefogadói nyilatkozathoz
    ⦁	Chip keresés 
        innen jutunk el:
        ⦁	Chipszám alapján történő tulajdonos beazonosításhoz 
        ⦁	Chipszámmal kapcsolatban módosítás miatt az egyén adataihoz

    Az adatok tárolására a vendeghaz.sql adatbázis szolgál.

# 2. Felhaszálói felületek

    A projekt két modulból áll: egy asztali és egy webes alkalmazásből.
    Mely a backenden keresztül kapcsolódik az adatbázishoz.

    Webes felületen a felhsználó tájkékozódhat 
        a Menedék életéről, míg bejelentezés után örökbefogadást kezdeményezhet. 
    Asztali alkalmazás a "vendégeink" adatkezelésével és 
        az örökbefogadás dokumentációjával foglalkozik.

# 3. Tesztelés, felhasználói betanítás

    A különböző folyamatok gyakorlati tesztjei
    Hibák javítása
    Optimalizálás

# 4. Felhasznált technológiák, eszközök

    Backend: Express, Node.js
    Frontend: React, HTML - Bootstrap, JavaScript
    Desktop: C#, .NET Windows Forms
    Verziókezelés: GitHub
    Database: MySQL