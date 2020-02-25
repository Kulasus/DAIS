--0
CREATE TABLE Statistics(
    operation VARCHAR(10) PRIMARY KEY NOT NULL,
    operationCount INT NOT NULL
);

INSERT INTO Statistics(operation, operationCount) VALUES ('INSERT',0);
INSERT INTO Statistics(operation, operationCount) VALUES ('UPDATE',0);
INSERT INTO Statistics(operation, operationCount) VALUES ('DELETE',0);

SELECT * FROM Statistics;
SELECT * FROM Student;

--1
CREATE OR REPLACE TRIGGER OperationCount BEFORE INSERT OR UPDATE OR DELETE ON Student
BEGIN
    IF INSERTING THEN
        UPDATE Statistics
        SET operationCount = operationCount+1
        WHERE operation = 'INSERT';
    ELSIF UPDATING THEN
        UPDATE Statistics
        SET operationCount = operationCount+1
        WHERE operation = 'UPDATE';
    ELSIF DELETING THEN
        UPDATE Statistics
        SET operationCount = operationCount+1
        WHERE operation = 'DELETE';
    END IF;
END;

EXECUTE AddStudent2('lukas','kondiolka',185);
EXECUTE IsStudentTall();
DELETE FROM Student;


CREATE TABLE StudentHistory(
    login CHAR(6) PRIMARY KEY,
    columnName VARCHAR(30) NOT NULL,
    oldValue VARCHAR(50) NOT NULL,
    newValue VARCHAR(50) NOT NULL,
    dateTime TIMESTAMP WITH TIME ZONE NOT NULL
)

select * from studenthistory;

CREATE OR REPLACE TRIGGER tgStudentHistory BEFORE UPDATE ON Student FOR EACH ROW
BEGIN
    IF UPDATING('fname') THEN
        INSERT INTO studentHistory(login, columnname, oldvalue, newvalue, datetime)
        VALUES(:new.login, 'fname', :old.fname, :new.fname, CURRENT_TIMESTAMP);
    ELSIF UPDATING('lname') THEN
        INSERT INTO studentHistory(login, columnname, oldvalue, newvalue, datetime)
        VALUES(:new.login, 'lname', :old.lname, :new.lname, CURRENT_TIMESTAMP);
    ELSIF UPDATING('email') THEN
        INSERT INTO studentHistory(login, columnname, oldvalue, newvalue, datetime)
        VALUES(:new.login, 'email', :old.email, :new.email, CURRENT_TIMESTAMP);
    END IF;
END;

UPDATE Student
SET fname = 'petr'
WHERE fname LIKE 'lukas';
-----------------------------------------
ALTER TABLE Kurz
ADD kapacita INT NOT NULL;

SELECT * FROM KURZ;
INSERT INTO kurz VALUES ('456-dais-01', 'Databázové a informacní systémy', 1);
INSERT INTO kurz VALUES ('456-tzd-01', 'Teorie zpracování dat', 0);

CREATE OR REPLACE TRIGGER kontrolaKapacity BEFORE INSERT ON StudijniPlan FOR EACH ROW
DECLARE
    v_currentCount INT;
    v_capacity INT;
    v_ex EXCEPTION;
BEGIN
    SELECT kapacita INTO v_capacity FROM kurz WHERE :new.kod = kod;
    SELECT COUNT(*) INTO v_currentCount FROM StudijniPlan WHERE kod = :new.kod;

    IF(v_currentCount >= v_capacity) THEN 
        dbms_output.put_line('kapacita prekrocena');
        RAISE v_ex;
    END IF;
END;

INSERT INTO studijniplan(kod,login,rok) VALUES ('456-dais-01','kon004','2009');
INSERT INTO studijniplan(kod,login,rok) VALUES ('456-dais-01','pla457','2009');

DELETE FROM studijniplan;
SELECT * FROM studijniplan;
SELECT * FROM kurz;
---------------------------------------------

CREATE OR REPLACE PROCEDURE CopyTableStructure(p_table_name VARCHAR)
AS
 v_tableName VARCHAR(200) := p_table_name || '_old';
BEGIN
        FOR one_column IN (SELECT * FROM USER_TAB_COLUMNS WHERE table_name = p_table_name) LOOP
            one_column.column_name one_column.data_type(one_column.data_length);
        END LOOP;
END;

EXECUTE CopyTableStructure('STUDENT');






