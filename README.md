# Recept gyűjtemény

## Feladatkiírás

A hallgatók feladata egy olyan webes vagy mobil alkalmazás elkészítése, amely receptek keresését teszi lehetővé nagy recept katalógusból, több szempont szerint. Az alkalmazás adatbázisa lehet saját scrape-elt adatra épülő, vagy használhatnak létező recept API-kat is.

## A fejlesztői csapat
| Név      |     NEPTUN-kód        |  E-mail cím |
|----------|:---------------------:|-------------|
| Sándor József |  HE0HPP | sjozsef2000@gmail.com   |
| Szász Tamás   |  PCKVJ5 | tamas.szasz12@gmail.com |

## Részletes feladatleírás
A projekt során célunk egy olyan alkalmazás készítése, amely képes egy publikus API végpontról recepteket összegyűjteni. Az összegyűjtött recepteket egy adatbázisban eltárolja. Az eltárolt recepteket képes a felhasználó számára megjeleníteni egy webes felületen. A felületen a felhasználónek lehetősége van a receptek kezelésére, keresésére, illetve új receptek hozzáadására. Az alkalmazás elérése regisztrációhoz kötött így a felhasználónak lehetősége van regisztrálni, illetve bejelentkezni az alkalmazásba.

## Technikai paraméterek
A definiált alkalmazást .NET Core 3.1 platformra készítjük el annak érdekében, hogy több operációs rendszeren (Windows, Linux) is lehessen futtatni. Az alkalmazás adatait egy SQL Server (vagy más hasonló) adatbázisban tárolja annak érdekében, hogy a publikus API által visszaadott adatokat megőrizze és ne kelljen minden adatlekérő felhasználói interakció után a távoli végponthoz forduljon az alkalmazás. Az adatok adatbázisban való tárolása továbbá biztosítja azt is, hogy ha a használt végpont nem üzemel, az alkalmazás akkor is funkcionális lesz. Az alkalmazás működéséhez továbbá szükség van egy webszerverre (a megvalósításban IIS/IIS express).

## Architektúra
![Alt text](/Pictures/3layerArch.png)

## Use case-ek:

### Adminisztráció:

- Felhasználó regisztráció (username/password only)

- Felhasználó bejelentkezés

### Receptkezelés:

- Publikus webhelyeken található receptek betöltése az alkalmazás adatbázisába (scrape/api)

- Saját recept létrehozás és elmentés az adatbázisba

- Saját recept utólagos módósítása (másik felhasználó receptjét nem lehet módosítani, viszont lehet látni)

- Adatbázisban levő receptek szűrése/keresése a recept metaadatai alpján

- Tetszőleges recept lementése .txt formátumban

### Recept metaadatai:

- név

- leírás

- alapanyagok, hozzávalók

- hány adag

- összes idő = előkészületi idő + elkészítési idő

- tápanyag infó

- elkészítési lépések

- recept szerzőjének neve

- értékelések ?

- allergének (pl. mogyoró) ?

- étkezés kategória (pl. desszert) ?

- diéta típus (pl. vegán) ?

- recept származása (pl. olasz) ?


