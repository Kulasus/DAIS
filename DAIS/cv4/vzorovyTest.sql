ALTER TABLE Purchase
ADD code VARCHAR(50);

SELECT * FROM Purchase;
select * from product;
SELECT * FROM CUSTOMER;
SELECT * FROM EMPLOYEE;


CREATE OR REPLACE FUNCTION getLastPurchaseEmployeeId RETURN purchase.eID%TYPE AS
l_currentDate purchase.purchaseDay%TYPE;
l_currentMaxDate purchase.purchaseDay%TYPE := CURRENT_TIMESTAMP;
l_currentId purchase.eId%TYPE := 1;
l_maxId purchase.eId%TYPE;
BEGIN
    SELECT MAX(eID) INTO l_maxID FROM purchase;
    FOR i IN 1..l_maxID LOOP
        SELECT MAX(purchaseDay) INTO l_currentDate FROM purchase WHERE eID = i;
        IF(l_currentDate < l_currentMaxDate) THEN
            l_currentMaxDate := l_currentDate;
            l_currentId := i;
        END IF;
    END LOOP;
    RETURN l_currentId;
END;


CREATE OR REPLACE PROCEDURE spTestAddPurchase(v_serialNr product.serialNr%TYPE, v_customerName customer.name%TYPE, v_price purchase.price%TYPE , v_pieces purchase.pieces%TYPE) AS
    l_nID purchase.nID %TYPE;
    l_cID purchase.cID %TYPE;
    l_pID purchase.pID %TYPE;
    l_eID purchase.eID %TYPE := getLastPurchaseEmployeeId();
    ex_noDataException EXCEPTION;
    l_purchaseCount int;
    l_code purchase.code %TYPE;
    
    BEGIN
        SELECT pID INTO l_pID FROM product WHERE serialNr LIKE v_serialNr; 
        SELECT cID INTO l_cID FROM customer WHERE name LIKE v_customerName;
        IF l_pID = null or l_cID = null THEN
            RAISE ex_noDataException;
        END IF;
        SELECT MAX(nID) INTO l_nID FROM purchase;
        SELECT COUNT(cID) INTO l_purchaseCount FROM purchase WHERE cID = l_cID;
        l_code := SUBSTR(v_serialNr, 0, 4) || '-' || EXTRACT(YEAR FROM CURRENT_TIMESTAMP) || '-' || SUBSTR(v_customerName, LENGTH(v_customerName)-3 , LENGTH(v_customerName)) || '-' || LPAD(l_purchaseCount,4,0);
        INSERT INTO Purchase(nID, cID, pID, eID, purchaseDay, price, pieces, code) VALUES (l_nID+1,l_cID,l_pID,l_eID, CURRENT_TIMESTAMP,v_price, v_pieces, l_code );
        COMMIT;
    EXCEPTION
        WHEN ex_noDataException THEN ROLLBACK;
END;

EXECUTE spTestAddPurchase('WOS-50-K2', 'fantomas', 3000, 3);
SELECT * FROM Purchase;

ALTER TABLE Purchase
ADD priceDiff INT;

CREATE OR REPLACE TRIGGER insertPriceDiff BEFORE INSERT ON purchase FOR EACH ROW
DECLARE 
l_oldPrice purchase.price%TYPE;
l_newPrice purchase.price%TYPE;
l_lastSimiliarPurchase purchase.nID%TYPE;
BEGIN
    SELECT MAX(nID) INTO l_lastSimiliarPurchase FROM purchase WHERE :new.nID != nID AND pID = :new.pID;
    SELECT price/pieces INTO l_oldPrice FROM purchase WHERE nID = l_lastSimiliarPurchase;
    l_newPrice := :new.price / :new.pieces;
    :new.priceDiff := l_newPrice - l_oldPrice;
END;

