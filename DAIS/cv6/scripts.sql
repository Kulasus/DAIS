--------------------------------------------------------------------------------
/*  Vytvoøte tabulku Student. */
--------------------------------------------------------------------------------
CREATE TABLE Student (
login CHAR(6) PRIMARY KEY,
fname VARCHAR(30) NOT NULL,
lname VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL);
GO
-------------------------------------1.-----------------------------------------
/*  Vytvorte uloženou proceduru AddStudent se ctyrmi parametry
p_login, p_fname, p_lname, p_email, která vloží nový
záznam. Zavolejte uloženou proceduru príkazem EXECUTE. */
--------------------------------------------------------------------------------
CREATE PROCEDURE AddStudent (@p_login CHAR(6), @p_fname VARCHAR(30), @p_lname VARCHAR(50), @p_email VARCHAR(50)) 
AS
BEGIN
	INSERT INTO Student(login, fname, lname, email) VALUES (@p_login, @p_fname, @p_lname, @p_email)
END
GO

EXECUTE AddStudent 'KON035','Lukas','Kondiolka','lukaskondiolka.st@vsb.cz';
GO

-------------------------------------2.-----------------------------------------
/*  Vytvorte uloženou proceduru PAddStudent, která bude
fungovat stejne jako procedura AddStudent a navíc bude ve
výstupním parametru vracet ’ok’, pokud bude záznam úspešne
vložen a ’error’ pokud dojde k chybe (použijte TRY - CATCH). 
K vypsání výsledku použijte funkci print. */
--------------------------------------------------------------------------------
CREATE PROCEDURE PAddStudent (@p_login CHAR(6), @p_fname VARCHAR(30), @p_lname VARCHAR(50), @p_email VARCHAR(50)) 
AS
BEGIN TRY
		INSERT INTO Student(login, fname, lname, email) VALUES (@p_login, @p_fname, @p_lname, @p_email)
		PRINT 'OK'
END TRY
BEGIN CATCH
		ROLLBACK
		PRINT 'ERROR'
END CATCH
GO

EXECUTE PAddStudent 'NOV009','Michal','Novotny','michalnovotny.st@vsb.cz';
GO

--------------------------------------------------------------------------------
/*  Vytvoøte tabulku Teacher. */
--------------------------------------------------------------------------------
CREATE TABLE Teacher (
login CHAR(6) NOT NULL PRIMARY KEY,
fname VARCHAR(30) NOT NULL,
lname VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL,
department INT NOT NULL,
specialization VARCHAR(30) NULL);
GO

-------------------------------------3.-----------------------------------------
/* Vytvorte proceduru StudentBecomeTeacher se dvema parametry p_login
a p_department, která presune záznam studenta s daným loginem z tabulky 
Student do tabulky Teacher. */
--------------------------------------------------------------------------------
CREATE PROCEDURE StudentBecomeTeacher (@p_login CHAR(6), @p_department INT)
AS
BEGIN
	INSERT INTO Teacher(login, fname, lname, email, department, specialization) SELECT *,@p_department,NULL from Student where login=@p_login
	DELETE FROM Student WHERE login = @p_login
END
GO

EXECUTE StudentBecomeTeacher 'kon035', 1
GO

-------------------------------------4.-----------------------------------------
/* Upravte proceduru StudentBecomeTeacher tak, aby
predstavovala jednu transakci. */
--------------------------------------------------------------------------------
ALTER PROCEDURE StudentBecomeTeacher (@p_login CHAR(6), @p_department INT)
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO Teacher(login, fname, lname, email, department, specialization) SELECT *,@p_department,NULL from Student where login=@p_login
			DELETE FROM Student WHERE login = @p_login
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
		END CATCH
END
GO

--------------------------------------------------------------------------------
/* Vytvorte novou tabulku student. */
--------------------------------------------------------------------------------
DROP TABLE STUDENT;
CREATE TABLE Student (
login CHAR(6) PRIMARY KEY,
fname VARCHAR(30) NOT NULL,
lname VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL,
tallness INT NOT NULL);
GO

-------------------------------------5.-----------------------------------------
/* Vytvorte proceduru AddStudent2 se tremi parametry p_fname,
p_lname a p_tallness, která vytvorí login z príjmení
(parametr p_lname): za první tri znaky príjmení pridá ’000’, a
email z login: za login pridá ’@vsb.cz’, a vloží záznam do tabulky
Student */
--------------------------------------------------------------------------------
CREATE PROCEDURE AddStudent2 (@p_fname VARCHAR(30), @p_lname VARCHAR(50), @p_tallness INT)
AS
BEGIN
	DECLARE @l_login CHAR(6) = CONCAT(LOWER(SUBSTRING(@p_lname,0,4)),'000')
	DECLARE @l_email VARCHAR(50) = CONCAT(@l_login,'@vsb.cz')
	INSERT INTO Student(login, fname, lname, email, tallness) VALUES (@l_login, @p_fname, @p_lname, @l_email, @p_tallness)
END
GO

EXECUTE AddStudent2 'Adam', 'Kondiolka', 155
EXECUTE AddStudent2 'Petr', 'Kolomaznik', 210

-------------------------------------6.-----------------------------------------
/* Pridejte do tabulky Student atribut isTall, který bude nabývat
hodnoty 0 nebo 1. */
--------------------------------------------------------------------------------
ALTER TABLE Student
ADD isTall BIT
GO
-------------------------------------7.-----------------------------------------
/* Vytvorte proceduru IsStudentTall s jedním parametrem
p_login, která nalezne záznam s daným loginem. Nastaví u nej
hodnotu atributu isTall na 0 pokud je atribut tallness menší
než jeho prumerná hodnota a hodnotu 1 v opacném prípade. */
--------------------------------------------------------------------------------
CREATE PROCEDURE IsStudentTall (@p_login CHAR(6))
AS
BEGIN
	DECLARE @l_avgTallness INT
	DECLARE @l_studentTallness INT
	DECLARE @l_isTall BIT

	SELECT @l_avgTallness=AVG(tallness) FROM Student
	SELECT @l_studentTallness=tallness FROM Student WHERE login = @p_login
	IF @l_studentTallness < @l_avgTallness
		SET @l_isTall = 0;
	ELSE 
		SET @l_isTall = 1;
	UPDATE Student SET isTall=@l_isTall WHERE login=@p_login
END
GO

EXECUTE IsStudentTall 'kol000'
GO
-------------------------------------8.-----------------------------------------
/* Vytvorte funkci LoginExist s jedním parametrem p_login,
která vrátí true pokud existuje záznam s loginem p_login.
Použijte funkci LoginExist k rozšírení procedury
AddStudent2, která bude vytváret login tak dlouho dokud
nenalezne nepoužitý login (použijte WHILE). */
--------------------------------------------------------------------------------
CREATE FUNCTION LoginExist (@p_login CHAR(6))
RETURNS BIT
AS
BEGIN
	DECLARE @l_return BIT
	IF EXISTS(SELECT * FROM Student WHERE login = @p_login)
		SET @l_return = 1
	ELSE 
		SET @l_return = 0
	RETURN @l_return
END
GO

ALTER PROCEDURE AddStudent2 (@p_fname VARCHAR(30), @p_lname VARCHAR(50), @p_tallness INT)
AS
BEGIN
	DECLARE @l_login CHAR(6)
	DECLARE @l_email VARCHAR(50)
	DECLARE @l_loginNum INT = 0
	DECLARE @l_loginTmp VARCHAR(10) = LOWER(SUBSTRING(@p_lname,0,4))
	WHILE @l_loginNum < 1000
	BEGIN
		IF @l_loginNum < 10
			SET @l_login = @l_loginTmp + '00' + CAST(@l_loginNum AS CHAR(1))
		ELSE IF @l_loginNum < 100
			SET @l_login = @l_loginTmp + '0' + CAST(@l_loginNum AS CHAR(2))
		ELSE IF @l_loginNum < 100
			SET @l_login = @l_loginTmp + CAST(@l_loginNum AS CHAR(3))
		IF dbo.LoginExist(@l_login) = 0
			BREAK
		SET @l_loginNum = @l_loginNum + 1 
	END
	SET @l_email = CONCAT(@l_login,'@vsb.cz')
	INSERT INTO Student(login, fname, lname, email, tallness) VALUES (@l_login, @p_fname, @p_lname, @l_email, @p_tallness)
END
GO

-------------------------------------9.-----------------------------------------
/* Napište proceduru SetStudentTallness, která bude
procházet všechny záznamy tabulky Student a nastavovat
príslušnou hodnotu atributu isTall (viz procedura
IsStudentTall). Procedura tedy bude bez parametru.
Využijte príkazy OPEN, FETCH, CLOSE.
 */
--------------------------------------------------------------------------------
CREATE PROCEDURE SetStudentTallness 
AS
BEGIN
	DECLARE @v_avg INT;
	DECLARE @v_tallness INT;
	DECLARE @v_isTall BIT;
	DECLARE @l_tmpLogin CHAR(6)
	DECLARE studentCursor CURSOR FOR SELECT login, tallness FROM Student
	SELECT @v_avg=avg(tallness) FROM Student;

	OPEN studentCursor
	FETCH NEXT FROM studentCursor INTO @l_tmpLogin, @v_tallness
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @v_tallness < @v_avg
			SET  @v_isTall = 0;
		ELSE  
			SET  @v_isTall = 1;

		UPDATE Student SET isTall=@v_isTall WHERE login=@l_tmpLogin;
		FETCH NEXT FROM studentCursor INTO @l_tmpLogin, @v_tallness
	END
	CLOSE studentCursor
	DEALLOCATE studentCursor
END
GO

------------------------------------10.-----------------------------------------
/* Vytvorte uloženou proceduru CopyTableStructure se dvema
parametry: schématem p_table_schema a názvem tabulky
p_table_name, která vytvorí kopii (pouze atributy) tabulky se
jménem p_table_name ze schématu p_table_schema. Nová
tabulka bude prázdná, bude mít príponu ’_old’ a bude mít stejná
jména atributu (a stejné typy) jako puvodní tabulka. */
--------------------------------------------------------------------------------
CREATE PROCEDURE CopyTableStructure (@p_table_schema VARCHAR(50), @p_table_name VARCHAR(50))
AS
BEGIN
	DECLARE c_columnCursor CURSOR FOR SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE 
		TABLE_SCHEMA = @p_table_schema AND TABLE_NAME = @p_table_name
	DECLARE @l_columnNameTmp VARCHAR(50)
	DECLARE @l_dataTypeTmp VARCHAR(50)
	DECLARE @l_characterMaximumLengthTmp INT
	DECLARE @l_command NVARCHAR(1000)
	DECLARE @l_index INT
	DECLARE @l_delim VARCHAR(1)

	OPEN c_columnCursor
	FETCH NEXT FROM c_columnCursor INTO @l_columnNameTmp, @l_dataTypeTmp, @l_characterMaximumLengthTmp

	SET @l_command = 'CREATE TABLE ' + @p_table_name + '_old ('
	SET @l_index = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @l_index > 0
			SET @l_delim = ','
		ELSE
			SET @l_delim = ''

		SET @l_command = @l_command + @l_delim + @l_columnNameTmp + ' ' + @l_dataTypeTmp
		IF @l_dataTypeTmp = 'char' OR @l_dataTypeTmp = 'varchar'
			SET @l_command = @l_command + '(' + CAST(@l_characterMaximumLengthTmp AS VARCHAR(10)) + ')'

		FETCH NEXT FROM c_columnCursor INTO @l_columnNameTmp, @l_dataTypeTmp, @l_characterMaximumLengthTmp
		SET @l_index = @l_index + 1
	END

	SET @l_command = @l_command + ')'
	PRINT @l_command

	EXECUTE sp_executesql @l_command

	CLOSE c_columnCursor
	DEALLOCATE c_columnCursor
END
GO

EXECUTE CopyTableStructure 'dbo', 'student'
SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'student_old'
DROP TABLE student_old
GO

------------------------------------11.-----------------------------------------
/* Vytvorte uloženou proceduru CopyTable se stejnými parametry,
která nejprve vytvorí kopii tabulky a pak zkopíruje všechny
záznamy. */
--------------------------------------------------------------------------------
CREATE PROCEDURE CopyTable (@p_table_schema VARCHAR(50), @p_table_name VARCHAR(50))
AS
BEGIN
	EXECUTE CopyTableStructure @p_table_schema, @p_table_name

	DECLARE @l_command NVARCHAR(1000)
	SET @l_command = 'INSERT INTO ' + @p_table_name + '_old SELECT * FROM ' + @p_table_name
	EXECUTE sp_executesql @l_command
END
GO

EXECUTE CopyTable 'dbo', 'student'
SELECT * FROM student_old
DROP TABLE student_old
GO
------------------------------------12.-----------------------------------------
/* Vytvorte triggery které zaznamenají do tabulky Statistics
pocty operací insert, update a delete nad tabulkou Student.
Tabulka Statistics bude tabulka se dvema atributy. První
atribut operation bude predstavovat typ operace a druhý
atribut operationCount bude predstavovat pocty daných operací. */
--------------------------------------------------------------------------------
CREATE TABLE Overview (
	operation VARCHAR(30) PRIMARY KEY NOT NULL,
	operationCount INT NOT NULL
);
INSERT INTO Overview(operation, operationCount) VALUES('INSERT',0);
INSERT INTO Overview(operation, operationCount) VALUES('UPDATE',0);
INSERT INTO Overview(operation, operationCount) VALUES('DELETE',0);
SELECT * FROM Overview
GO

CREATE TRIGGER insertStudent ON Student FOR INSERT 
AS
BEGIN
	UPDATE Overview SET operationCount = operationCount + 1 WHERE operation = 'INSERT'
END
GO

CREATE TRIGGER updatetStudent ON Student FOR UPDATE 
AS
BEGIN
	UPDATE Overview SET operationCount = operationCount + 1 WHERE operation = 'UPDATE'
END
GO

CREATE TRIGGER deleteStudent ON Student FOR DELETE
AS
BEGIN
	UPDATE Overview SET operationCount = operationCount + 1 WHERE operation = 'DELETE'
END
GO

EXECUTE AddStudent2 'Martin', 'Chrobacek', 175
SELECT * FROM Student
SELECT * FROM Overview

------------------------------------14.-----------------------------------------
/* 2 Vytvorte tabulku Kurz(id, nazevKurzu, kapacita) a
vazebni tabulku StudijniPlan mezi tabulkou Kurz a
Student. Vytvorte trigger kontrolaKapacity nad tabulkou
StudijniPlan, který vypíše varovnou hlášku v prípade, že je kapacita kurzu prekrocena. */
--------------------------------------------------------------------------------
CREATE TABLE Course (
	id INT PRIMARY KEY NOT NULL,
	name VARCHAR(30) NOT NULL,
	capacity INT NOT NULL
)

CREATE TABLE StudyPlan(
	id INT PRIMARY KEY NOT NULL,
	id_course INT NOT NULL,
	login_student CHAR(6) NOT NULL,
	FOREIGN KEY(id_course) REFERENCES Course(id),
	FOREIGN KEY(login_student) REFERENCES Student(login)
)
GO

CREATE TRIGGER capacityCheck ON StudyPlan FOR INSERT
AS
BEGIN
	IF (SELECT COUNT(*) FROM StudyPlan, Inserted WHERE StudyPlan.id_course = inserted.id_course) > 
		(SELECT capacity FROM Course, Inserted WHERE Course.id = Inserted.id_course)
		PRINT 'WARNING! Capacity exceeded! ';
END
GO

------------------------------------15.-----------------------------------------
/* Vytvorte tabulky Teacher a Department:
	Teacher s atributy:
		login CHAR(5), primární klíc,
		fname VARCHAR(30),
		lname VARCHAR(50),
		email VARCHAR(50),
		department NUMBER, cizí klíc, primární klíc tabulky Department.
	Department s atributy:
		id NUMBER, primární klíc, použijte automaticky inkrementovanou hodnotu,
		name VARCHAR(50),
		head CHAR(5), cizí klíc, primární klíc tabulky Teacher.
Všechny atributy krome Department.head budou NOT NULL. */
--------------------------------------------------------------------------------
DROP TABLE Teacher

CREATE TABLE Teacher(
	login CHAR(5) PRIMARY KEY NOT NULL,
	fname VARCHAR(30) NOT NULL,
	lname VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	department INT NOT NULL,
)
CREATE TABLE Department(
	id INT PRIMARY KEY IDENTITY NOT NULL,
	name VARCHAR(50) NOT NULL,
	head CHAR(5) 
)

ALTER TABLE Teacher ADD CONSTRAINT fk_teacher_department FOREIGN KEY(department) REFERENCES Department(id);
ALTER TABLE Department ADD CONSTRAINT fk_department_teacher FOREIGN KEY(head) REFERENCES Teacher(login);

------------------------------------16.-----------------------------------------
/* Zrušte tabulky Teacher a Department. */
--------------------------------------------------------------------------------
ALTER TABLE Teacher DROP CONSTRAINT fk_teacher_department
ALTER TABLE Department DROP CONSTRAINT fk_department_teacher
DROP TABLE Teacher, Department

------------------------------------17.-----------------------------------------
/* Vložte nekolik záznamu do tabulky Department s využitím
automaticky generovaného klíce. */
--------------------------------------------------------------------------------
INSERT INTO Department(head, name) VALUES (NULL, 'FEI');
INSERT INTO Department(head, name) VALUES (NULL, 'FBI');
INSERT INTO Department(head, name) VALUES (NULL, 'HGF');
SELECT * FROM Department

------------------------------------18.-----------------------------------------
/* Vložte nekolik záznamu do tabulky Teacher. */
--------------------------------------------------------------------------------
INSERT INTO Teacher(login, fname, lname, email, department) VALUES ('pot01','Petr','Potek','petrpotek@vsb.cz',1);
INSERT INTO Teacher(login, fname, lname, email, department) VALUES ('bil09','Kill','Bill','killbill@vsb.cz',2);
INSERT INTO Teacher(login, fname, lname, email, department) VALUES ('kow25','Jiri','Kowalski','jirikowalski@vsb.cz',3);
INSERT INTO Teacher(login, fname, lname, email, department) VALUES ('nov25','Michal','Novak','michalnovak@vsb.cz',3);
SELECT * FROM Teacher

------------------------------------19.-----------------------------------------
/* Prirad’te každé katedre vedoucího – aktualizujte atribut head
tabulky Department. */
--------------------------------------------------------------------------------
UPDATE Department SET head = 'pot01' WHERE name = 'FEI'
UPDATE Department SET head = 'pot01' WHERE name = 'FBI'
UPDATE Department SET head = 'kow25' WHERE name = 'HGF'
SELECT * FROM Department
GO
------------------------------------20.-----------------------------------------
/* Napište uloženou proceduru PrintReport(), která vypíše tiskovou
sestavu ucitelu, kterí jsou na katedrách mající víc než jednoho
ucitele. Pro každého ucitele vypište login, jméno, príjmení, email a id
katedry. Proceduru napište s pomocí jediného kurzoru. */
--------------------------------------------------------------------------------
CREATE PROCEDURE PrintReport
AS
BEGIN
	DECLARE @l_login CHAR(5)
	DECLARE @l_fname VARCHAR(30)
	DECLARE @l_lname VARCHAR(50)
	DECLARE @l_email VARCHAR(50)
	DECLARE @l_department INT
	DECLARE c_teachers CURSOR FOR SELECT * FROM Teacher WHERE department IN (
		SELECT department FROM Teacher GROUP BY department HAVING COUNT(*) > 1
	) ORDER BY department

	OPEN c_teachers
	FETCH NEXT FROM c_teachers INTO @l_login, @l_fname, @l_lname, @l_email, @l_department

	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT 'Teacher ' + @l_login + ' ' + @l_fname + ' ' + @l_lname + ' ' + @l_email + ' Department: ' + CAST(@l_department AS VARCHAR(10))
		FETCH NEXT FROM c_teachers INTO @l_login, @l_fname, @l_lname, @l_email, @l_department
	END
	CLOSE c_teachers
	DEALLOCATE c_teachers
END
GO

EXECUTE PrintReport
