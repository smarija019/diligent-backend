Kako bi se podesila baza podataka, nakon što se importuje u bazu fajl diligent_db_new.sql, potrebno je u fajlu appsettings.json u "ConnectionStrings" izmeniti u "DefaultConnection" podatke 'user' i 'password'.

Prilikom pokretanja diligent_backend aplikacije potrebno je samo pokrenuti datu aplikaciju. Tokom testiranja aplikacija je pokretana koriš?enjem Visual Studio 2019.

Prilikom pokretanja frontend aplikacije potrebno je istu pokrenuti pomo?u Angular CLI komandom ng serve --open.

Postoji nekoliko registrovanih korisnika u bazi. Korisnici koji se mogu koristiti (poznata je njihova lozinka) su:

Korisnici sa ulogom "admin":

username: p.marko
password: Makimaki4!!

username: smarija@gmail.com
password: Smarija4!

Korisnici sa ulogom "customer":

username: filip@gmail.com
password: Ffilip4!

username: fbiljana@gmail.com
password: Fbiljana4!

Tokom registrovanja novih korisnika password mora sadržati najmanje 6 karaktera i mora biti sastavljen od velikih, malih slova kao i od bar jednog nealfanumeri?kog karaktera.

Tokom editovanja entiteta, potrebno je pri svakom editovanju ponovo izabrati vrednost iz dropdown-a (mat-select element).

Razvijano i testirano koriš?enjem Angular 9.1.1 , .NET Core 3.1 i wampserver-a.