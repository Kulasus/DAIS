ALTER TABLE ucitel
ADD pracPomerZacatek DATE;

ALTER TABLE ucitel
ADD pracPomerKonec DATE;

UPDATE ucitel
SET pracPomerZacatek = TO_DATE('1.1.1995', 'DD.MM.YYYY'),
    pracPomerKonec = TO_DATE('1.1.2015', 'DD.MM.YYYY')
WHERE prijmeni LIKE 'Codd';

UPDATE ucitel
SET pracPomerZacatek = TO_DATE('1.1.2008', 'DD.MM.YYYY'),
    pracPomerKonec = TO_DATE('1.1.2010', 'DD.MM.YYYY')
WHERE prijmeni LIKE 'Bayer';

