
-------------------------------------1.-----------------------------------------
/* Vypi�te studenty (tedy hodnoty v�ech atribut�), kte�� maj� v roce
2009 zaps�ny kurzy garantovan� ucitelem s pr�jmen�m Codd. */
--------------------------------------------------------------------------------
SELECT student.*
FROM student LEFT JOIN studijniplan ON student.login = studijniplan.login
    LEFT JOIN kurz ON studijniplan.kod = kurz.kod
    LEFT JOIN garant ON kurz.kod = garant.kod
    LEFT JOIN ucitel ON garant.login = ucitel.login
WHERE studijniplan.rok = 2009 AND ucitel.prijmeni LIKE 'Codd';

-------------------------------------2.-----------------------------------------
/* Vypi�te kurzy, kter� si v roce 2009 zapsal student s pr�jmen�m
Plav�cek. */
--------------------------------------------------------------------------------
SELECT kurz.*
FROM kurz LEFT JOIN studijniplan ON kurz.kod = studijniplan.kod
    LEFT JOIN student ON student.login = studijniplan.login
WHERE studijniplan.rok = 2009 AND student.prijmeni LIKE 'Plav�cek';

-------------------------------------3.-----------------------------------------
/* Vypi�te kurzy, kter� si zapsal student pr�jmen�m Plav�cek */
--------------------------------------------------------------------------------
SELECT kurz.*
FROM kurz LEFT JOIN studijniplan ON kurz.kod = studijniplan.kod
    LEFT JOIN student ON student.login = studijniplan.login
WHERE student.prijmeni LIKE 'Plav�cek';

-------------------------------------4.-----------------------------------------
/* Vypi�te k�dy kurz�, kter� si v roce 2009 zapsal alespon jeden
student (odstrante duplicitn� z�znamy).  */
--------------------------------------------------------------------------------
SELECT DISTINCT kurz.kod
FROM kurz JOIN studijniplan ON kurz.kod = studijniplan.kod
    JOIN student ON student.login = studijniplan.login;
    
-------------------------------------5.-----------------------------------------
/* Vypi�te ucitele, kter� v roce 2009 garantuj� kurzy, kter� si ve
stejn�m roce zapsal alespon jeden student (odstrante duplicitn� z�znamy). */
--------------------------------------------------------------------------------
SELECT DISTINCT ucitel.*
FROM ucitel LEFT JOIN garant ON ucitel.login = garant.login
    LEFT JOIN studijniplan ON garant.kod = studijniplan.kod
    LEFT JOIN student ON studijniplan.login = student.login
WHERE garant.rok = 2009 AND studijniplan.rok = 2009;

-------------------------------------6.-----------------------------------------
/* Vypi�te v�echny ucitele garantuj�c� v roce 2009 alespon jeden
kurz a jejich� pracovn� pomer trv� d�le ne� 3 roky. */
--------------------------------------------------------------------------------
SELECT DISTINCT ucitel.*
FROM ucitel JOIN garant ON ucitel.login = garant.login 
WHERE garant.rok = 2009 AND ucitel.pracpomerkonec - ucitel.pracpomerzacatek > 3*365;

-------------------------------------7.-----------------------------------------
/* SQL pr�kazem SELECT * FROM USER_TABLES; vypi�te ze syst�mov�ho katalogu 
v�echny tabulky u�ivatele. */
--------------------------------------------------------------------------------
SELECT * FROM user_tables;

-------------------------------------8.-----------------------------------------
/* SQL pr�kazem
SELECT * FROM USER_TAB_COLUMNS WHERE
TABLE_NAME=�STUDENT�;
vypi�te ze syst�mov�ho katalogu informace o atributech tabulky Student. */
--------------------------------------------------------------------------------
SELECT * FROM user_tab_columns WHERE
table_name = 'student'; -- This one is not working properly

DESC student; -- This one does

-------------------------------------9.-----------------------------------------
/* Vypi�te n�zvy tabulek jejich� je aktu�ln� u�ivatel vlastn�k. */
--------------------------------------------------------------------------------
SELECT table_name FROM user_tables;

-------------------------------------10.----------------------------------------
/* Vypi�te n�zvy tabulek a vlastn�ka tabulek ke kter�m m� aktu�ln�
u�ivatel alespon jedno pr�stupov� pr�vo. */
--------------------------------------------------------------------------------
SELECT table_name, owner
FROM all_tables;

-------------------------------------11.----------------------------------------
/* Vypi�te n�zvy atributu a jejich datov� typy zvolen� tabulky
vlastnen� aktu�ln�m u�ivatelem. */
--------------------------------------------------------------------------------
SELECT column_name, data_type
FROM user_tab_columns
WHERE table_name = 'ucitel'