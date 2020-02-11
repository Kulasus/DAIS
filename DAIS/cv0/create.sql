CREATE TABLE Student(
    login CHAR(6) PRIMARY KEY NOT NULL,
    jmeno VARCHAR(30) NOT NULL,
    prijmeni VARCHAR(50) NOT NULL
);

CREATE TABLE Kurz(
    kod CHAR(11) PRIMARY KEY NOT NULL,
    nazev VARCHAR(50)
);

CREATE TABLE Ucitel(
    login CHAR(5) PRIMARY KEY NOT NULL,
    jmeno VARCHAR(30) NOT NULL,
    prijmeni VARCHAR(50) NOT NULL
)

CREATE TABLE StudijniPlan(
    rok INT NOT NULL CONSTRAINT FourDigitsStudijniPlanConstraint CHECK (rok BETWEEN 0 AND 9999),
    login CHAR(6) NOT NULL,
    kod CHAR(11) NOT NULL,
    PRIMARY KEY (rok, login, kod),
    FOREIGN KEY (login) REFERENCES Student(login),
    FOREIGN KEY (kod) REFERENCES Kurz(kod)
)

CREATE TABLE Garant(
    rok INTEGER NOT NULL CONSTRAINT FourDigitsGarantConstraint CHECK (rok BETWEEN 0 AND 9999),
    login CHAR(5) NOT NULL,
    kod CHAR(11) NOT NULL,
    PRIMARY KEY (rok, login, kod),
    FOREIGN KEY (login) REFERENCES Ucitel(login),
    FOREIGN KEY (kod) REFERENCES Kurz(kod)
)
