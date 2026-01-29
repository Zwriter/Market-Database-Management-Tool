-------------------DATA BASE-----------------

CREATE DATABASE dbMarket

USE dbMarket

-------------------SEQUENCES-----------------

CREATE SEQUENCE Seq_Client START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Seq_Category START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Seq_Receipt START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Seq_Product START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Seq_Factory START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Seq_Sale START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Seq_Record START WITH 1 INCREMENT BY 1;

--------------------TABLES-------------------

CREATE TABLE tClient ( 
    Id CHAR(10) 
		CONSTRAINT pk_Client PRIMARY KEY
		DEFAULT (
            'CLIE' + RIGHT('000000' + CAST(NEXT VALUE FOR Seq_Client AS VARCHAR(6)), 6)
        ),
    Name VARCHAR(50), 
    PhoneNumber VARCHAR(12),
    Email VARCHAR(100) CHECK (email LIKE '%_@_%._%'),
	CreatedAt DATETIME2(3) NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2(3)
);

CREATE TABLE tCategory ( 
    Id CHAR(10) 
		CONSTRAINT pk_Category PRIMARY KEY
		DEFAULT (
            'CATE' + RIGHT('000000' + CAST(NEXT VALUE FOR Seq_Category AS VARCHAR(6)), 6)
        ),
    CategoryName VARCHAR(50),
	CreatedAt DATETIME2(3) NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE tReceipt ( 
    Id CHAR(10) 
		CONSTRAINT pk_Receipt PRIMARY KEY
		DEFAULT (
            'RECE' + RIGHT('000000' + CAST(NEXT VALUE FOR Seq_Receipt AS VARCHAR(6)), 6)
        ),
    ClientId CHAR(10) CONSTRAINT fk_Client FOREIGN KEY REFERENCES tClient(Id),
	CreatedAt DATETIME2(3) NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE tProduct ( 
    Id CHAR(10) 
		CONSTRAINT pk_Product PRIMARY KEY
		DEFAULT (
            'PROD' + RIGHT('000000' + CAST(NEXT VALUE FOR Seq_Product AS VARCHAR(6)), 6)
        ),
    ProductName VARCHAR(50),
	CreatedAt DATETIME2(3) NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE tFactory ( 
    Id CHAR(10) 
		CONSTRAINT pk_Factory PRIMARY KEY
		DEFAULT (
            'FACT' + RIGHT('000000' + CAST(NEXT VALUE FOR Seq_Factory AS VARCHAR(6)), 6)
        ),
    FactoryName VARCHAR(50),
	CreatedAt DATETIME2(3) NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE tSale ( 
    Id CHAR(10) 
		CONSTRAINT pk_Sale PRIMARY KEY
		DEFAULT (
            'SALE' + RIGHT('000000' + CAST(NEXT VALUE FOR Seq_Sale AS VARCHAR(6)), 6)
        ),
    ReceiptId CHAR(10) CONSTRAINT fk_Receipt FOREIGN KEY REFERENCES tReceipt(Id),
    ProductId CHAR(10) CONSTRAINT fk_Product FOREIGN KEY REFERENCES tProduct(Id), 
    Quantity INT NOT NULL CHECK(Quantity > 0)
);

CREATE TABLE tRecord ( 
    Id CHAR(10) 
		CONSTRAINT pk_Record PRIMARY KEY
		DEFAULT (
            'RECO' + RIGHT('000000' + CAST(NEXT VALUE FOR Seq_Record AS VARCHAR(6)), 6)
        ),
    CategoryId CHAR(10) CONSTRAINT fk_Record_Category FOREIGN KEY REFERENCES tCategory (Id),
    FactoryId CHAR(10) CONSTRAINT fk_Record_Factory  FOREIGN KEY REFERENCES tFactory(Id), 
    ProductId CHAR(10) CONSTRAINT fk_Record_Product FOREIGN KEY REFERENCES tProduct(Id), 
    Stock INT NOT NULL DEFAULT 0  CHECK( Stock >= 0),
    Price DECIMAL(10,2) CHECK( Price >= 0),
    ExpirationDate DATE
);

---------------------DROP TABLE-------------------------

DROP TABLE tClient
DROP TABLE tCategory
DROP TABLE tReceipt
DROP TABLE tProduct
DROP TABLE tFactory
DROP TABLE tSale
DROP TABLE tRecord

---------------------PROCEDURES-------------------------

-- Earnings for a set period

CREATE PROCEDURE dbo.GetEarningsByDateRange
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    WITH AvgPrice AS (
        SELECT ProductId, AVG(Price) AS AvgPrice
        FROM tRecord
        GROUP BY ProductId
    )
    SELECT
        CAST(r.CreatedAt AS DATE) AS SaleDate,
        SUM(s.Quantity * ISNULL(ap.AvgPrice, 0)) AS TotalEarnings
    FROM tSale s
    LEFT JOIN tReceipt r ON s.ReceiptId = r.Id
    LEFT JOIN AvgPrice ap ON s.ProductId = ap.ProductId
    WHERE r.CreatedAt >= @FromDate AND r.CreatedAt <= @ToDate
    GROUP BY CAST(r.CreatedAt AS DATE)
    ORDER BY SaleDate;
END
GO

-- Sales grouped by day
CREATE PROCEDURE dbo.GetSalesByDateRange
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        CAST(CreatedAt AS DATE) AS SaleDate,
        SUM(Quantity) AS TotalQuantity,
        COUNT(*) AS SalesCount
    FROM tSale s
    LEFT JOIN tReceipt r ON s.ReceiptId = r.Id
    WHERE r.CreatedAt >= @FromDate AND r.CreatedAt <= @ToDate
    GROUP BY CAST(r.CreatedAt AS DATE)
    ORDER BY SaleDate;
END

-- Top N products
CREATE PROCEDURE dbo.GetTopProducts
    @TopN INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP (@TopN)
        p.Id AS ProductId,
        p.ProductName,
        SUM(s.Quantity) AS TotalQuantity
    FROM tSale s
    INNER JOIN tProduct p ON s.ProductId = p.Id
    GROUP BY p.Id, p.ProductName
    ORDER BY TotalQuantity DESC;
END

-- Current stock by product
CREATE PROCEDURE dbo.GetStockByProduct
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        p.Id AS ProductId,
        p.ProductName,
        SUM(r.Stock) AS TotalStock,
        AVG(r.Price) AS AvgPrice
    FROM tRecord r
    INNER JOIN tProduct p ON r.ProductId = p.Id
    GROUP BY p.Id, p.ProductName
    ORDER BY p.ProductName;
END

----------------------TRIGGERS--------------------------

CREATE TRIGGER trg_UpdateClient
ON tClient
AFTER UPDATE
AS
BEGIN
    UPDATE tClient
    SET UpdatedAt = SYSDATETIME()
    FROM Inserted i
    WHERE tClient.Id = i.Id;
END;

-----------------------INSERT---------------------------

INSERT INTO tClient (Name, PhoneNumber, Email) VALUES
('Ion Popescu', '0711223344', 'ion.popescu@gmail.com'),
('Maria Ionescu', '0722334455', 'maria.ionescu@yahoo.com'),
('George Vasilescu', '0733445566', 'george.vasilescu@outlook.com');

INSERT INTO tCategory (CategoryName) VALUES
('Electronics'),
('Home Appliances'),
('IT & Computing');

INSERT INTO tFactory (FactoryName) VALUES
('Samsung'),
('Philips'),
('Dell');

INSERT INTO tProduct (ProductName) VALUES
('4K LED TV'),
('No Frost Refrigerator'),
('Inspiron Laptop');

INSERT INTO tReceipt (ClientID) VALUES
('CLIE000001'),
('CLIE000002'),
('CLIE000003');

INSERT INTO tSale (ReceiptId, ProductId, Quantity) VALUES
('RECE000001', 'PROD000001', 1),
('RECE000001', 'PROD000003', 1),
('RECE000002', 'PROD000002', 2),
('RECE000003', 'PROD000001', 1);

INSERT INTO tRecord 
(CategoryId, FactoryId, ProductId, Stock, Price, ExpirationDate) VALUES
('CATE000001', 'FACT000001', 'PROD000001', 20, 2000.00, '2026-12-31'),
('CATE000002', 'FACT000002', 'PROD000002', 15, 1500.00, '2027-01-15'),
('CATE000003', 'FACT000003', 'PROD000003', 10, 3500.00, '2025-11-30');

------------------------SELECT--------------------------------

SELECT * FROM tClient
SELECT * FROM tCategory
SELECT * FROM tReceipt
select * from tRecord