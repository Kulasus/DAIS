-------------------------------------0.-----------------------------------------
/* Vytvorte tabulku student. */
--------------------------------------------------------------------------------
CREATE TABLE Student (
login CHAR(6) PRIMARY KEY,
fname VARCHAR(30) NOT NULL,
lname VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL);

-------------------------------------1.-----------------------------------------
/* Pridejte do tabulky atribut tallness typu Int. */
--------------------------------------------------------------------------------
ALTER TABLE Student ADD tallness int;

-------------------------------------2.-----------------------------------------
/* Modifikujte integritn� omezen� atributu email tabulky tak, aby
mohl b�t NULL. */
--------------------------------------------------------------------------------
ALTER TABLE Student MODIFY email VARCHAR(50) NULL;

-------------------------------------3.-----------------------------------------
/* Spust�te n�sleduj�c� anonymn� proceduru: viz. dole. */
--------------------------------------------------------------------------------
BEGIN
    INSERT INTO Student (login, fname, lname, tallness) VALUES ('buh005', 'Jan', 'Buhda', 175);
END;

-------------------------------------poznamka-----------------------------------
/*  
    BEGIN
        dbms_output.put_line('Ahoj'); -- Vyp�se do server outputu neco.
    END;

    SET SERVEROUTPUT ON; -- Musi se nastavit na on aby mohl probihat vypis.
    SET SERVEROUTPUT OFF; -- Timto se zakaze vypis.
    
    -- Druha moznost je otevrit si ve view/dbms_output okno a divat se na vypis
    tam. Pak muze byt SERVEROUTPUT nastaveny na OFF.
*/
--------------------------------------------------------------------------------

-------------------------------------4.-----------------------------------------
/*  Zmente proceduru tak, aby konkr�tn� hodnoty ulo�ila do lok�ln�ch
promenn�ch stejn�ho typu jako jsou atributy tabulky Student. */
--------------------------------------------------------------------------------
DECLARE
    v_login CHAR(6);
    v_fname VARCHAR(30);
    v_lname VARCHAR(50);
    v_email VARCHAR(50);
    v_tallness int;
BEGIN
    v_login := 'buh005';
    v_fname := 'Jan';
    v_lname := 'Buhda';
    v_email := null;
    v_tallness := 173;
    INSERT INTO Student (login, fname, lname, email, tallness) VALUES(v_login, v_fname, v_lname, v_email, v_tallness);
END;

-------------------------------------5.-----------------------------------------
/*  Zmente proceduru tak, aby konkr�tn� hodnoty ulo�ila do
lok�ln�ch promenn�ch s vyu�it�m %TYPE.*/
--------------------------------------------------------------------------------
DECLARE
    v_login student.login%TYPE;
    v_fname student.fname%TYPE;
    v_lname student.lname%TYPE;
    v_email student.email%TYPE;
    v_tallness student.tallness%TYPE;
BEGIN
    v_login := 'buh005';
    v_fname := 'Jan';
    v_lname := 'Buhda';
    v_email := null;
    v_tallness := 173;
    INSERT INTO Student (login, fname, lname, email, tallness) VALUES(v_login, v_fname, v_lname, v_email, v_tallness);
END;


-------------------------------------5.-----------------------------------------
/* Napi�te anonymn� proceduru, kter� vybere z�znam studenta s
loginem buh005 a ulo�� jej do lok�ln� promenn� s vyu�it�m %ROWTYPE. */
--------------------------------------------------------------------------------
DECLARE
    v_student Student%ROWTYPE;
BEGIN
    SELECT * INTO v_student
    FROM Student
    WHERE Student.login LIKE 'buh005';
    dbms_output.put_line(v_student.login || ' ' || v_student.fname || ' ' || v_student.lname || ' ' ||v_student.email || ' ' || v_student.tallness );
END;

-------------------------------------6.-----------------------------------------
/* Napi�te anonymn� proceduru, kter� vlo�� dva z�znamy do
tabulky Student a provede COMMIT. V pr�pade selh�n� jedn� zoperac� se provede 
ROLLBACK. */
--------------------------------------------------------------------------------
BEGIN
    INSERT INTO Student (login, fname, lname, tallness) VALUES ('buh005', 'Jan', 'Buhda', 175);
    INSERT INTO Student (login, fname, lname, tallness) VALUES ('buh005', 'Jan', 'Buhda', 175);
    COMMIT; -- Submits transaction and starts another one
EXCEPTION -- Goes here if transaction execution fails
    WHEN OTHERS THEN ROLLBACK; -- Return DB to state before transaction
END;
