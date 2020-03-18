--------------------------------------------------------------------------------
/*  Vytvoøte tabulku Student. */
--------------------------------------------------------------------------------
CREATE TABLE Student (
login CHAR(6) PRIMARY KEY,
fname VARCHAR(30) NOT NULL,
lname VARCHAR(50) NOT NULL,
email VARCHAR(50) NOT NULL);GO-------------------------------------1.-----------------------------------------
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
tallness INT NOT NULL);GO-------------------------------------5.-----------------------------------------
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
Využijte príkazy OPEN, FETCH, CLOSE. */
--------------------------------------------------------------------------------
create PROCEDURE SetStudentTallness 
AS
BEGIN
	DECLARE @v_avg INT;
	DECLARE @v_tallness INT;
	DECLARE @v_isTall BIT;
	DECLARE @l_tmpLogin CHAR(6)
	DECLARE studentCursor CURSOR FOR SELECT login, tallness FROM Student
	select @v_avg=avg(tallness) from Student;

	OPEN studentCursor
	FETCH NEXT FROM studentCursor INTO @l_tmpLogin, @v_tallness
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @v_tallness < @v_avg
			SET  @v_isTall = 0;
		ELSE  
			SET  @v_isTall = 1;

		UPDATE Student set isTall=@v_isTall where login=@l_tmpLogin;
		FETCH NEXT FROM studentCursor INTO @l_tmpLogin, @v_tallness
	END
	CLOSE studentCursor
	DEALLOCATE studentCursor
END
GO