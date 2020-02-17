
-------------------------------------1.-----------------------------------------
/* Vypište studenty (tedy hodnoty všech atributù), kteøí mají v roce
2009 zapsány kurzy garantované ucitelem s príjmením Codd. */
--------------------------------------------------------------------------------
SELECT student.*
FROM student LEFT JOIN studijniplan ON student.login = studijniplan.login
    LEFT JOIN kurz ON studijniplan.kod = kurz.kod
    LEFT JOIN garant ON kurz.kod = garant.kod
    LEFT JOIN ucitel ON garant.login = ucitel.login
WHERE studijniplan.rok = 2009 AND ucitel.prijmeni LIKE 'Codd';

-------------------------------------2.-----------------------------------------
/* Vypište kurzy, které si v roce 2009 zapsal student s príjmením
Plavácek. */
--------------------------------------------------------------------------------
SELECT kurz.*
FROM kurz LEFT JOIN studijniplan ON kurz.kod = studijniplan.kod
    LEFT JOIN student ON student.login = studijniplan.login
WHERE studijniplan.rok = 2009 AND student.prijmeni LIKE 'Plavácek';

-------------------------------------3.-----------------------------------------
/* Vypište kurzy, které si zapsal student príjmením Plavácek */
--------------------------------------------------------------------------------
SELECT kurz.*
FROM kurz LEFT JOIN studijniplan ON kurz.kod = studijniplan.kod
    LEFT JOIN student ON student.login = studijniplan.login
WHERE student.prijmeni LIKE 'Plavácek';

-------------------------------------4.-----------------------------------------
/* Vypište kódy kurzù, které si v roce 2009 zapsal alespon jeden
student (odstrante duplicitní záznamy).  */
--------------------------------------------------------------------------------
SELECT DISTINCT kurz.kod
FROM kurz JOIN studijniplan ON kurz.kod = studijniplan.kod
    JOIN student ON student.login = studijniplan.login;
    
-------------------------------------5.-----------------------------------------
/* Vypište ucitele, kterí v roce 2009 garantují kurzy, které si ve
stejném roce zapsal alespon jeden student (odstrante duplicitní záznamy). */
--------------------------------------------------------------------------------
SELECT DISTINCT ucitel.*
FROM ucitel LEFT JOIN garant ON ucitel.login = garant.login
    LEFT JOIN studijniplan ON garant.kod = studijniplan.kod
    LEFT JOIN student ON studijniplan.login = student.login
WHERE garant.rok = 2009 AND studijniplan.rok = 2009;

-------------------------------------6.-----------------------------------------
/* Vypište všechny ucitele garantující v roce 2009 alespon jeden
kurz a jejichž pracovní pomer trvá déle než 3 roky. */
--------------------------------------------------------------------------------
SELECT DISTINCT ucitel.*
FROM ucitel JOIN garant ON ucitel.login = garant.login 
WHERE garant.rok = 2009 AND ucitel.pracpomerkonec - ucitel.pracpomerzacatek > 3*365;

-------------------------------------7.-----------------------------------------
/* SQL príkazem SELECT * FROM USER_TABLES; vypište ze systémového katalogu 
všechny tabulky uživatele. */
--------------------------------------------------------------------------------
SELECT * FROM user_tables;

-------------------------------------8.-----------------------------------------
/* SQL príkazem
SELECT * FROM USER_TAB_COLUMNS WHERE
TABLE_NAME=’STUDENT’;
vypište ze systémového katalogu informace o atributech tabulky Student. */
--------------------------------------------------------------------------------
SELECT * FROM user_tab_columns WHERE
table_name = 'student'; -- This one is not working properly

DESC student; -- This one does

-------------------------------------9.-----------------------------------------
/* Vypište názvy tabulek jejichž je aktuální uživatel vlastník. */
--------------------------------------------------------------------------------
SELECT table_name FROM user_tables;

-------------------------------------10.----------------------------------------
/* Vypište názvy tabulek a vlastníka tabulek ke kterým má aktuální
uživatel alespon jedno prístupové právo. */
--------------------------------------------------------------------------------
SELECT table_name, owner
FROM all_tables;

-------------------------------------11.----------------------------------------
/* Vypište názvy atributu a jejich datové typy zvolené tabulky
vlastnené aktuálním uživatelem. */
--------------------------------------------------------------------------------
SELECT column_name, data_type
FROM user_tab_columns
WHERE table_name = 'ucitel'