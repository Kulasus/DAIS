-------------------------------------1.-----------------------------------------
/*  Vytvorte trigger OperationCount který zaznamená do tabulky
Statistics pocty operací insert, update a delete. Tabulka Statistics bude tabulka
se dvema atributy. První atribut operation bude predstavovat typ operace a druhý 
atribut operationCount bude predstavovat pocty daných operací (použijte 
detekci DML operace v triggeru). */
--------------------------------------------------------------------------------
CREATE TABLE Statistics(
    operation VARCHAR(10) PRIMARY KEY NOT NULL,
    operationCount INT NOT NULL
);

INSERT INTO Statistics(operation, operationCount) VALUES ('INSERT',0);
INSERT INTO Statistics(operation, operationCount) VALUES ('UPDATE',0);
INSERT INTO Statistics(operation, operationCount) VALUES ('DELETE',0);

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

-------------------------------------BONUS--------------------------------------
/*  Vytvoreni loggovaci tabulky pro tabulku Student */
--------------------------------------------------------------------------------
CREATE TABLE StudentHistory(
    login CHAR(6) PRIMARY KEY,
    columnName VARCHAR(30) NOT NULL,
    oldValue VARCHAR(50) NOT NULL,
    newValue VARCHAR(50) NOT NULL,
    dateTime TIMESTAMP WITH TIME ZONE NOT NULL
)

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
-------------------------------------2.-----------------------------------------
/* Pridejte atribut kapacita do tabulky Kurz, který bude predstavovat maximální
kapacitu daného kurzu. Vytvorte trigger kontrolaKapacity, který vypíše varovnou
hlášku v prípade, že je kapacita kurzu prekrocena. */
--------------------------------------------------------------------------------
ALTER TABLE Kurz
ADD kapacita INT NOT NULL;

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

-------------------------------------3.-----------------------------------------
/* Vytvorte uloženou proceduru CopyTableStructure s jedním
parametrem p_table_name, která vytvorí kopii (pouze atributy)
tabulky se jménem p_table_name. Nová tabulka bude
prázdná, bude mít príponu ’_old’ a bude mít stejná jména atributu (a stejné typy) 
jako puvodní tabulka. */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE CopyTableStructure(p_table_name VARCHAR)
AS
    v_sql VARCHAR(1000);
    v_tableName VARCHAR(50) := p_table_name;
BEGIN
    FOR v_col IN (SELECT * FROM user_tab_columns WHERE table_name = v_tableName) LOOP
        v_sql := v_sql || CHR(13) || CHR(10);
        v_sql := v_sql || v_col.column_name || ' ' || v_col.data_type || '(' || v_col.data_length || ')';
        IF v_col.nullable = 'y' THEN
            v_sql := v_sql || 'NULL';
        ELSE
            v_sql := v_sql || 'NOT NULL';
        END IF;
        v_sql := v_sql || ',';
    END LOOP;
    v_sql := SUBSTR(v_sql, 1, LEN(v_sql)-1);
    v_sql := 'CREATE TABLE ' || v_tableName;
END;
