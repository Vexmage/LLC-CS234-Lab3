DROP PROCEDURE IF EXISTS usp_CustomerDelete;
DELIMITER // 
CREATE PROCEDURE usp_CustomerDelete (in p_CustomerID int, in conCurrId int)
BEGIN
    Delete from customers where CustomerID = p_CustomerID and ConcurrencyID = conCurrId;
END //
DELIMITER ; 

DROP PROCEDURE IF EXISTS usp_CustomerSelect;
DELIMITER // 
CREATE PROCEDURE usp_CustomerSelect (in p_CustomerID int)
BEGIN
    Select * from customers where CustomerID = p_CustomerID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_CustomerSelectAll;
DELIMITER // 
CREATE PROCEDURE usp_CustomerSelectAll ()
BEGIN
    Select * from customers order by CustomerID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_CustomerUpdate;
DELIMITER // 
CREATE PROCEDURE usp_CustomerUpdate (in p_CustomerID int, in name_p varchar(100), in address_p varchar(50), in city_p varchar(20), in state_p varchar(2), in zipcode_p varchar(15), in conCurrId int)
BEGIN
    Update customers
    Set Name = name_p, Address = address_p, City = city_p, State = state_p, ZipCode = zipcode_p, ConcurrencyID = (ConcurrencyID + 1)
    Where CustomerID = p_CustomerID and ConcurrencyID = conCurrId;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_CustomerCreate;
DELIMITER // 
CREATE PROCEDURE usp_CustomerCreate (out p_CustomerID int, in name_p varchar(100), in address_p varchar(50), in city_p varchar(20), in state_p varchar(2), in zipcode_p varchar(15))
BEGIN
    Insert into customers (Name, Address, City, State, ZipCode, ConcurrencyID)
    Values (name_p, address_p, city_p, state_p, zipcode_p, 1);
    Select LAST_INSERT_ID() into p_CustomerID;
END //
DELIMITER ;
