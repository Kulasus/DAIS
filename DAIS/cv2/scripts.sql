-------------------------------------1.-----------------------------------------
/* Vytvorte ulozenou proceduru AddStudent se ctyrmi parametry
p_login, p_fname, p_lname, p_tallness, která vloží
nový záznam. Zavolejte uloženou proceduru príkazem EXECUTE. */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE AddStudent(p_login CHAR, p_fname VARCHAR, p_lname VARCHAR, p_tallness NUMBER) AS
    BEGIN
        INSERT INTO student (login, fname, lname, tallness) VALUES (p_login, p_fname, p_lname, p_tallness);
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

-------------------------------------2.-----------------------------------------
/* Vytvorte uloženou funkci FAddStudent, která bude fungovat stejne jako 
procedura AddStudent a navíc bude vracet ’ok’, pokud bude záznam úspešne 
vložen a ’error’ pokud dojde k chybe (Použijte část Exception). K vypsání 
výsledku funkce použijte funkci dbms_output.put_line. Pred zavoláním této
funkce je nutné nastavit Set Serveroutput on. */
--------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION FAddStudent(p_login CHAR, p_fname VARCHAR, p_lname VARCHAR, p_tallness NUMBER) RETURN VARCHAR AS
    BEGIN
        INSERT INTO student (login, fname, lname, tallness) VALUES (p_login, p_fname, p_lname, p_tallness);
        COMMIT;
        RETURN 'ok';
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
        RETURN 'error';
END;

DECLARE
    v_answer VARCHAR(20);
BEGIN
    v_answer:= FAddStudent('kon035', 'Lukas', 'Kondiolka', 185);
    dbms_output.put_line(v_answer);
END;

--------------------------------------------------------------------------------
/* Vytvorte tabulku teacher podle predlohy. */
--------------------------------------------------------------------------------
CREATE TABLE Teacher (
login CHAR(6) NOT NULL PRIMARY KEY,
fname VARCHAR2(30) NOT NULL,
lname VARCHAR2(50) NOT NULL,
department INT NOT NULL,
specialization VARCHAR2(30) NULL);

-------------------------------------3.-----------------------------------------
/* Vytvorte proceduru StudentBecomeTeacher se dvema parametry p_login a 
p_department, která presune záznam studenta s daným loginem z tabulky 
Student do tabulky Teacher (príkaz SELECT INTO). */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE StudentBecomeTeacher(p_login student.login%TYPE, p_department teacher.department%TYPE) AS
    v_student Student%ROWTYPE;
    BEGIN
        SELECT * INTO v_student FROM student WHERE student.login = p_login;
        INSERT INTO teacher(login, fname, lname, department) VALUES (v_student.login, v_student.fname, v_student.lname, p_department);
        DELETE FROM student WHERE student.login = p_login;
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

-------------------------------------4.-----------------------------------------
/* Upravte proceduru StudentBecomeTeacher tak, aby predstavovala jednu transakci. */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE StudentBecomeTeacher(p_login student.login%TYPE, p_department teacher.department%TYPE) AS
    v_student Student%ROWTYPE;
    BEGIN
        SELECT * INTO v_student FROM student WHERE student.login = p_login;
        INSERT INTO teacher(login, fname, lname, department) VALUES (v_student.login, v_student.fname, v_student.lname, p_department);
        DELETE FROM student WHERE student.login = p_login;
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

-------------------------------------5.-----------------------------------------
/* Vytvorte proceduru AddStudent2 se tremi parametry p_fname, p_lname a 
p_tallness, která vytvorí login z príjmení (parametr p_lname) pridáním ’00’ 
a vloží záznam do tabulky (použijte SUBSTR). */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE AddStudent2(p_fname student.fname%TYPE, p_lname student.lname%TYPE, p_tallness student.tallness%TYPE)AS
    v_login student.login%TYPE := SUBSTR(p_lname,0,3) || '000';
    BEGIN
        INSERT INTO student(login, fname, lname, tallness) VALUES (v_login, p_fname, p_lname, p_tallness);
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

-------------------------------------7.-----------------------------------------
/* Pridejte do tabulky Student atribut isTall, který bude nabývat hodnoty 0 nebo 1.*/
--------------------------------------------------------------------------------
ALTER TABLE Student 
ADD isTall CHAR(1) CONSTRAINT  const_student_isTall CHECK (isTall IN('1','0'));

-------------------------------------8.-----------------------------------------
/* Vytvorte proceduru IsStudentTall s jedním parametrem p_login, která nalezne
záznam s daným loginem. Nastaví u nej hodnotu atributu isTall na 0 pokud je atribut 
tallness menší než jeho prumerná hodnota a hodnotu 1 v opacném prípade (príkaz IF). */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE IsStudentTall(p_login student.login%TYPE) AS
    v_averageTallness FLOAT; 
    v_student student%ROWTYPE;
    BEGIN
        SELECT AVG(tallness) INTO v_averageTallness FROM student;
        SELECT * INTO v_student FROM student WHERE student.login = p_login;
        IF(v_averageTallness > v_student.tallness + 0.0) THEN
            UPDATE student
            SET istall = '0'
            WHERE student.login = p_login;
        ELSE 
            UPDATE student
            SET istall = '1'
            WHERE student.login = p_login;
        END IF;
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

-------------------------------------9.-----------------------------------------
/* Vytvorte funkci LoginExist s jedním parametrem p_login, která vrátí true 
pokud existuje záznam s loginem p_login. Použijte funkci LoginExist k rozšírení 
procedury AddStudent2, která bude vytváret login tak dlouho dokud nenalezne 
nepoužitý login (príkaz LOOP). */
--------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION LoginExist(p_login student.login%TYPE) RETURN BOOLEAN AS
    v_count NUMBER;
    BEGIN
        SELECT COUNT(*) INTO v_count FROM student WHERE login = p_login;
        IF(v_count > 0) THEN
            RETURN TRUE;
        ELSE
            RETURN FALSE;
        END IF;
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

CREATE OR REPLACE PROCEDURE AddStudent2(p_fname student.fname%TYPE, p_lname student.lname%TYPE, p_tallness student.tallness%TYPE)AS
    v_login student.login%TYPE;
    v_loginNumber NUMBER;
    BEGIN
        v_login := SUBSTR(p_lname,0,3) || '000';
        v_loginNumber := 0;
        WHILE LoginExist(v_login) LOOP
            v_loginNumber := v_loginNumber + 1 ;
            v_login := LOWER(SUBSTR(p_lname,1,3)) || LPAD(v_loginNumber,3,'0');
        END LOOP;    
        INSERT INTO student(login, fname, lname, tallness) VALUES (v_login, p_fname, p_lname, p_tallness);
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

-------------------------------------10.----------------------------------------
/* Upravte proceduru IsStudentTall tak, aby procházela všechny záznamy a 
nastavovala príslušnou hodnotu atributu isTall. Procedura tedy bude bez parametru.
Využijte typ student%ROWTYPE a príkazy OPEN, FETCH, CLOSE. */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE IsStudentTall AS
    v_averageTallness FLOAT;
    v_student student%ROWTYPE;
    CURSOR c_student IS SELECT * FROM Student;
    BEGIN
        SELECT AVG(tallness) INTO v_averageTallness FROM student;
        OPEN c_student;
        LOOP
            FETCH c_student INTO v_student;
            EXIT WHEN c_student%NOTFOUND;
            IF(v_averageTallness > v_student.tallness + 0.0) THEN
                UPDATE student
                SET istall = '0'
                WHERE student.login = v_student.login;
            ELSE 
                UPDATE student
                SET istall = '1'
                WHERE student.login = v_student.login;    
            END IF;
        END LOOP;
        CLOSE c_student;
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;

-------------------------------------11.----------------------------------------
/* Prepište proceduru IsStudentTall aby používala cyklus FOR. */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE IsStudentTall AS
    v_averageTallness FLOAT; 
    BEGIN
        SELECT AVG(tallness) INTO v_averageTallness FROM student;
        FOR one_student IN (SELECT * FROM student) LOOP
            IF(v_averageTallness > one_student.tallness + 0.0) THEN
                UPDATE student
                SET istall = '0'
                WHERE student.login = one_student.login;
            ELSE 
                UPDATE student
                SET istall = '1'
                WHERE student.login = one_student.login;
            END IF;
        END LOOP;
        COMMIT;
    EXCEPTION
        WHEN OTHERS THEN ROLLBACK;
END;