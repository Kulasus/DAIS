CREATE TABLE Student (
login CHAR(6) PRIMARY KEY,
fname VARCHAR(30) NOT NULL,
lname VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL);

ALTER TABLE Student ADD tallness int;

ALTER TABLE Student MODIFY email VARCHAR(50) NULL;

BEGIN
    INSERT INTO Student (login, fname, lname, tallness) VALUES ('buh005', 'Jan', 'Buhda', 175);
END;

BEGIN
    dbms_output.put_line('Ahoj');
END;

SET SERVEROUTPUT ON;
SET SERVEROUTPUT OFF;

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

DECLARE
    v_login student.login%TYPE;
    v_fname student.fname%TYPE;
    v_lname student.lname%TYPE;
    v_email student.email%TYPE;
    v_tallness student.tallness%TYPE;
BEGIN
    SELECT login, fname, lname, email, tallness INTO v_login, v_fname, v_lname, v_email, v_tallness
    FROM Student;
    dbms_output.put_line(v_login || ' ' || v_fname || ' ' || v_lname || ' ' ||v_email || ' ' || v_tallness );
END;

DECLARE
    v_student Student%ROWTYPE;
BEGIN
    SELECT * INTO v_student
    FROM Student;
    dbms_output.put_line(v_student.login || ' ' || v_student.fname || ' ' || v_student.lname || ' ' ||v_student.email || ' ' || v_student.tallness );
END;

BEGIN
    INSERT INTO Student (login, fname, lname, tallness) VALUES ('buh005', 'Jan', 'Buhda', 175);
    INSERT INTO Student (login, fname, lname, tallness) VALUES ('buh005', 'Jan', 'Buhda', 175);
    COMMIT; -- Submits transaction and starts another one
EXCEPTION -- Goes here if transaction execution fails
    WHEN OTHERS THEN ROLLBACK; -- Return DB to state before transaction
END;



SELECT * FROM student;

DELETE FROM student;

