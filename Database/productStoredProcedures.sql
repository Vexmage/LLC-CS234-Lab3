USE mmabooksframework;

DELIMITER // 

-- Drop and Create for usp_ProductDelete
DROP PROCEDURE IF EXISTS usp_ProductDelete; 
CREATE PROCEDURE usp_ProductDelete (in productId_p int, in conCurrId int)
BEGIN
	Delete from products where ProductId = productId_p and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

-- Drop and Create for usp_ProductCreate
DROP PROCEDURE IF EXISTS usp_ProductCreate;
DELIMITER // 
CREATE PROCEDURE usp_ProductCreate (
    out ProductID int, 
    in productCode_p varchar(30), 
    in description_p varchar(50), 
    in unitPrice_p decimal(9,2), 
    in onHandQty_p int
)
BEGIN
	Insert into products (ProductCode, Description, UnitPrice, OnHandQuantity, ConcurrencyID)
    Values (productCode_p, description_p, unitPrice_p, onHandQty_p, 1);
    Select LAST_INSERT_ID() into ProductID;
    
END //
DELIMITER ;

-- Drop and Create for usp_ProductSelect
DROP PROCEDURE IF EXISTS usp_ProductSelect;
DELIMITER // 
CREATE PROCEDURE usp_ProductSelect (in productId_p int)
BEGIN
	Select * from products where ProductId=productId_p;
END //
DELIMITER ;

-- Drop and Create for usp_ProductSelectAll
DROP PROCEDURE IF EXISTS usp_ProductSelectAll;
DELIMITER // 
CREATE PROCEDURE usp_ProductSelectAll ()
BEGIN
	Select * from products order by Description;
END //
DELIMITER ;

-- Drop and Create for usp_ProductUpdate
DROP PROCEDURE IF EXISTS usp_ProductUpdate;
DELIMITER // 
CREATE PROCEDURE usp_ProductUpdate (
    in productId_p int, 
    in productCode_p varchar(30), 
    in description_p varchar(50), 
    in unitPrice_p decimal(9,2), 
    in onHandQty_p int, 
    in conCurrId int
)
BEGIN
	Update products
    Set ProductCode = productCode_p, 
        Description = description_p, 
        UnitPrice = unitPrice_p, 
        OnHandQuantity = onHandQty_p, 
        ConcurrencyID = (ConcurrencyID + 1)
    Where ProductId = productId_p and ConcurrencyID = conCurrId;
    
END //
DELIMITER ;
