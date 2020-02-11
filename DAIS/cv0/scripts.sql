SELECT student.*
FROM student LEFT JOIN studijniplan ON student.login = studijniplan.login
    LEFT JOIN kurz ON studijniplan.kod = kurz.kod
    LEFT JOIN garant ON kurz.kod = garant.kod
    LEFT JOIN ucitel ON garant.login = ucitel.login
WHERE studijniplan.rok = 2009 AND ucitel.prijmeni LIKE 'Codd'

SELECT kurz.*
FROM kurz LEFT JOIN studijniplan ON kurz.kod = studijniplan.kod
    LEFT JOIN student ON student.login = studijniplan.login
WHERE --TODO--