Select * from Employees E 
JOIN Orders O           ON E.EmployeeID  = O.EmployeeID
JOIN Shippers S         ON S.ShipperID   = O.ShipVia
JOIN Customers C        ON O.CustomerID  = C.CustomerID
JOIN [Order Details] OD ON OD.OrderID    = O.OrderID
JOIN Products P         ON P.ProductID   = OD.ProductID
JOIN Categories Ca      ON Ca.CategoryID = P.CategoryID


 

ALTER TRIGGER TAPSIRIQ
ON SHIPPERS
AFTER INSERT, UPDATE, DELETE
--INSTEAD OF 
AS
BEGIN

    DECLARE @companyName NVARCHAR(50)
          , @phone       NVARCHAR(24)
          , @shipperId   INT
    DECLARE @deletedCompanyName NVARCHAR(50)
          , @deletedPhone       NVARCHAR(24)
          , @deletedShipperId   INT
		   
    IF EXISTS (SELECT * FROM INSERTED)
    BEGIN

        SELECT @companyName = CompanyName
             , @phone       = Phone
        FROM INSERTED
        IF EXISTS (SELECT * FROM DELETED)
        BEGIN
            SELECT @deletedShipperId   = ShipperID
                 , @deletedCompanyName = CompanyName
                 , @deletedPhone       = Phone
            FROM DELETED

            PRINT ('
			---------- Kargo Tablosunda Kayıt Güncellendi ----------
			--- Şirket ID             : ' + CAST(@deletedShipperId AS NVARCHAR(50))
                   + ' 
			--- Eski Şirket Adı       : ' + @deletedCompanyName + ' 
			--- Eski Telefon Numarası : ' + @deletedPhone
                   + '

			--------------------------------------------------------

			--- Yeni Şirket Adı       : ' + @companyName + ' 
			--- Yeni Telefon Numarası : ' + @phone
                  )

        END
        ELSE
        BEGIN
            PRINT ('
			---------- Kargo Tablosuna Kayıt Eklendi ----------
			--- Şirket Adı            : ' + @companyName + ' 
			--- Telefon Numarası      : ' + @phone)
        END
    END
    ELSE IF EXISTS (SELECT * FROM DELETED)
    BEGIN
        SELECT @deletedShipperId   = ShipperID
             , @deletedCompanyName = CompanyName
             , @deletedPhone       = Phone
        FROM DELETED
        PRINT ('
			---------- Kargo Tablosundan Kayıt Silindi ----------
			--- Şirket ID        : ' + CAST(@deletedShipperId AS NVARCHAR(50)) + ' 
			--- Şirket Adı       : ' + @deletedCompanyName + ' 
			--- Telefon Numarası : ' + @deletedPhone)
    END
END


DECLARE @ShipperId int 
--INSERT INTO Shippers VALUES ('Aras Kargo','444 00 00')  
SET @ShipperId = @@IDENTITY
--PRINT(@ShipperId)
--UPDATE Shippers      SET    CompanyName = CompanyName + '_MV'  WHERE ShipperID = @ShipperId
DELETE FROM Shippers WHERE  ShipperID = @ShipperId 
SELECT * FROM Shippers

select FirstName, LastName, Country from Employees

update Employees set Country = 'TR' where EmployeeID = 1

SELECT FirstName, LastName ,
  CASE Country
  WHEN 'UK'     THEN 'İngiltere Birşelik Kırallığı'
  WHEN 'USA'    THEN 'Amerika Birleşik Devletleri'
  --WHEN 'TR'   THEN 'Türkiye Cumhuriyeti'
  WHEN Country  THEN Country
  END AS 'No Column Name Yazmasın Diye Ekliyoruz :)' 
FROM Employees

-- EmployeeId değeri 5 küçüse 5'ten küçüktür, 5'ten büyüktür, default 5'e eşittir

-- 3. güne ödev
-- verilen telefon numarasını formatlayan function yazınız. eğer sayı harici bir data içeriyorsa hata verecek.
-- telefon numarası 0504441245 olarak verildiğinde -> (050) 444 12-45 şeklinde dönecektir. eksik veya fazla numara verilirse hata verilecek. 

--RAISERROR ( 'Telefon Formatı Yanlış',1,1)


SELECT EmployeeID, FirstName, LastName, 
    case 
    when EmployeeID < 5 then '5''ten büyüktür'
	when EmployeeID > 5 then '5''ten küçüktür'
	when EmployeeID = 5 then '5''e eşittir'
end as Sonuc
FROM Employees