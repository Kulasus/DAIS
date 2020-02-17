
-------------------------------------1.-----------------------------------------
/* Vypi�te studenty (tedy hodnoty v�ech atribut�), kte�� maj� v roce
2009 zaps�ny kurzy garantovan� ucitelem s pr�jmen�m Codd. */
--------------------------------------------------------------------------------
SELECT student.*
FROM student LEFT JOIN studijniplan ON student.login = studijniplan.login
    LEFT JOIN kurz ON studijniplan.kod = kurz.kod
    LEFT JOIN garant ON kurz.kod = garant.kod
    LEFT JOIN ucitel ON garant.login = ucitel.login
WHERE studijniplan.rok = 2009 AND ucitel.prijmeni LIKE 'Codd'

-------------------------------------2.-----------------------------------------
/* Vypi�te kurzy, kter� si v roce 2009 zapsal student s pr�jmen�m
Plav�cek. */
--------------------------------------------------------------------------------
SELECT kurz.*
FROM kurz LEFT JOIN studijniplan ON kurz.kod = studijniplan.kod
    LEFT JOIN student ON student.login = studijniplan.login
WHERE studijniplan.rok = 2009 AND student.prijmeni LIKE 'Plav�cek'

-------------------------------------3.-----------------------------------------
/* Vypi�te kurzy, kter� si zapsal student p�r�jmen�m Plav�cek */
--------------------------------------------------------------------------------
SELECT kurz.*
FROM kurz LEFT JOIN studijniplan ON kurz.kod = studijniplan.kod
    LEFT JOIN student ON student.login = studijniplan.login
WHERE student.prijmeni LIKE 'Plav�cek'

-------------------------------------4.-----------------------------------------
/* Vypi�te k�dy kurz�, kter� si v roce 2009 zapsal alespon jeden
student (odstrante duplicitn� z�znamy).  */
--------------------------------------------------------------------------------
SELECT DISTINCT kurz.kod
FROM kurz JOIN studijniplan ON kurz.kod = studijniplan.kod
    JOIN student ON student.login = studijniplan.
    
-------------------------------------5.-----------------------------------------
/* Vypi�te ucitele, kter� v roce 2009 garantuj� kurzy, kter� si ve
stejn�m roce zapsal alespon jeden student (odstrante duplicitn� z�znamy). */
--------------------------------------------------------------------------------
SELECT DISTINCT ucitel.*
FROM ucitel LEFT JOIN garant ON ucitel.login = garant.login
    LEFT JOIN studijniplan ON garant.kod = studijniplan.kod
    LEFT JOIN student ON studijniplan.login = student.login
WHERE garant.rok = 2009 AND studijniplan.rok = 2009



