CREATE DATABASE QuanLyQuanBida
GO

USE QuanLyQuanBida
GO

-- food, drinnk
-- table
-- foodcatagory, drinkcatagory
-- account
-- bill: bill chung
-- bill info: 1 bill nhieu mon an

CREATE TABLE TableBida
(
	id INT IDENTITY PRIMARY KEY, --cho 1 cai id bat ki bang nao de ve sau lay xai de kh bi vướng
	ten NVARCHAR(100)NOT NULL DEFAULT N'Chua dat ten',
	tinhtrang NVARCHAR(100)NOT NULL DEFAULT N'Trong',  -- trống hoặc có người
	gia INT NOT NULL DEFAULT 0

)
GO

CREATE TABLE Account
(
	tenhienthi NVARCHAR (100)NOT NULL ,
	tennguoidung NVARCHAR (100)NOT NULL PRIMARY KEY ,
	matkhau NVARCHAR (1000)NOT NULL DEFAULT 0,
	loaitaikhoan INT NOT NULL DEFAULT 0--1: ADMIN, 0: STAFF
)
GO

CREATE TABLE FoodCatagory
(
	id INT IDENTITY PRIMARY KEY,
	tenhienthi NVARCHAR (100)NOT NULL DEFAULT N'Chua dat ten'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	tenhienthi NVARCHAR (100)NOT NULL DEFAULT N'Chua dat ten',
	idCatagory INT NOT NULL,
	gia INT NOT NULL DEFAULT 0

	FOREIGN KEY (idCatagory) REFERENCES dbo.FoodCatagory(id)
)
GO

CREATE TABLE DrinkCatagory
(
	id INT IDENTITY PRIMARY KEY,
	tenhienthi NVARCHAR (100)NOT NULL DEFAULT N'Chua dat ten'
)
GO

CREATE TABLE Drink
(
	id INT IDENTITY PRIMARY KEY,
	tenhienthi NVARCHAR (100)NOT NULL DEFAULT N'Chua dat ten',
	idCatagory INT NOT NULL,
	gia INT NOT NULL DEFAULT 0

	FOREIGN KEY (idCatagory) REFERENCES dbo.DrinkCatagory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	ngayvaogiovao DATETIME NOT NULL DEFAULT GETDATE(),
	ngayragiora DATETIME NOT NULL,
	idTable INT NOT NULL,
	tinhtrang INT NOT NULL DEFAULT 0, -- 1: da thanh toan, 0: chua thanh toan
	tonggia INT NOT NULL

	FOREIGN KEY (idTable) REFERENCES dbo.TableBida(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	idDrink INT NOT NULL,
	countf INT NOT NULL DEFAULT 0 ,
	countd INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id),
	FOREIGN KEY (idDrink) REFERENCES dbo.Drink(id)
)
GO

DROP TABLE BillInfo

CREATE PROC USP_GetAccountByUserName-- thủ tục lưu trữ được dùng để thực hiện một xử lí nhắt định(bảo mất cao)
@userName nvarchar (100)
AS
BEGIN 
	SELECT* FROM Account WHERE tennguoidung = @userName
END
GO

EXEC USP_GetAccountByUserName @userName = 'dat'

CREATE PROC USP_Login 
@userName nvarchar (100), 
@passWord nvarchar(100)
AS
BEGIN
	SELECT* FROM Account WHERE tennguoidung = @userName AND matkhau = @passWord
END
GO
--thêm bàn
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 1', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 2', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 3', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 4', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 5', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 6', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 7', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 8', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 9', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 10', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 11', N'Trống', '70000')
INSERT INTO TableBida ( ten, tinhtrang, gia ) VALUES ( N'Bàn 12', N'Trống', '70000')
GO

SELECT* FROM TableBida

CREATE PROC USP_GetTableList
AS SELECT* FROM TableBida
GO

EXEC USP_GetTableList 

UPDATE TableBida SET tinhtrang = N'Có người' WHERE ten = N'Bàn 4'

SELECT* FROM TableBida
SELECT* FROM Bill
SELECT* FROM BillInfo	
SELECT* FROM Food
SELECT* FROM Drink
SELECT* FROM FoodCatagory 
SELECT* FROM DrinkCatagory
GO
--thêm food catagory
INSERT INTO FoodCatagory ( tenhienthi ) VALUES ( N'Trái cây' )
INSERT INTO FoodCatagory ( tenhienthi ) VALUES ( N'Ăn Vặt' )
INSERT INTO FoodCatagory ( tenhienthi ) VALUES ( N'Mì' )
INSERT INTO FoodCatagory ( tenhienthi ) VALUES ( N'Cơm' )
GO
--thêm drink catagory
INSERT INTO DrinkCatagory ( tenhienthi ) VALUES ( N'Nước Ngọt' )
INSERT INTO DrinkCatagory ( tenhienthi ) VALUES ( N'Bia' )
INSERT INTO DrinkCatagory ( tenhienthi ) VALUES ( N'Thuốc lá' )
GO
--thêm món ăn
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Táo', 1, 15000 )
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Ổi', 1, 15000 )
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Thơm', 1, 15000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'xoài',1 ,15000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Mận', 1, 15000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Khoai tây chiên', 2, 30000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Xiên que', 2, 30000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Snack', 2, 15000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Bắp xào', 2, 20000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Mì xào bò', 3, 40000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Mì xào hải sản', 3, 40000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Cơm chiên dương châu', 4, 35000)
INSERT INTO Food (tenhienthi, idCatagory, gia) VALUES (N'Cơm gà', 4, 35000)
GO
--thêm đồ uống
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Sting', 1, 10000)
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'7up', 1, 10000)
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Pepsi/Coca', 1, 10000)
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Redbull', 1, 10000)
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Trà xanh không độ', 1, 10000)
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Cafe', 1, 15000)
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Aquafina', 1, 7000)
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'333', 2, 15000) UPDATE Drink SET tenhienthi = N'Bia 333' WHERE id = 8
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Tiger', 2, 15000) UPDATE Drink SET tenhienthi = N'Bia Tiger' WHERE id = 9
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Ba số bạc', 3, 30000) UPDATE Drink SET tenhienthi = N'Thuốc lá Ba số bạc' WHERE id = 10
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Sài gòn bạc', 3, 30000) UPDATE Drink SET tenhienthi = N'Thuốc lá Sài Gòn bạc' WHERE id = 11
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Con mèo', 3, 30000) UPDATE Drink SET tenhienthi = N'Thuốc lá Con mèo' WHERE id = 12
INSERT INTO Drink (tenhienthi, idCatagory, gia) VALUES (N'Con ngựa', 3, 30000) UPDATE Drink SET tenhienthi = N'Thuốc lá Con ngựa' WHERE id = 13
GO
--reset id identity
DELETE FROM TableBida
DELETE FROM Bill
DELETE FROM BillInfo
DBCC CHECKIDENT(TableBida, RESEED, 0)
DBCC CHECKIDENT(Bill, RESEED, 0)
DBCC CHECKIDENT(BillInfo, RESEED, 0)
GO
--bill
INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia) VALUES (GETDATE(), GETDATE(), 4, 1, 0)
INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia) VALUES (GETDATE(), GETDATE(), 6, 1, 0)
INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia) VALUES (GETDATE(), GETDATE(), 9, 1, 0)
GO
--bill info 
INSERT INTO BillInfo (idBill, idFood, idDrink, countf, countd) VALUES (1, 4, 2, 2, 4)
INSERT INTO BillInfo (idBill, idFood, idDrink, countf, countd) VALUES (2, 8, 4, 3, 2)
INSERT INTO BillInfo (idBill, idFood, idDrink, countf, countd) VALUES (2, 2, 3, 2, 1)
GO

CREATE PROC USP_Bill--chua them vao vs
AS
	SELECT* FROM Bill WHERE idTable = 14 AND tinhtrang = 1
GO
EXEC USP_Bill
GO

CREATE PROC USP_BillInfo--chua them vao vs
AS
	SELECT Food.tenhienthi, BillInfo.countf, Food.gia, BillInfo.countf*Food.gia, Drink.tenhienthi, BillInfo.countd, Drink.gia, BillInfo.countd*Drink.gia  
	FROM BillInfo, Bill, Food, Drink 
	WHERE BillInfo.idBill = Bill.id AND BillInfo.idFood = Food.id AND BillInfo.idDrink = Drink.id AND Bill.idTable = 4
GO
EXEC USP_BillInfo
GO

SELECT* FROM Bill WHERE idTable = 14 AND tinhtrang = 1
SELECT Food.tenhienthi, BillInfo.countf, Food.gia, BillInfo.countf*Food.gia AS 'Tonggiaf', Drink.tenhienthi, BillInfo.countd, Drink.gia, BillInfo.countd*Drink.gia AS 'Tonggiad'  FROM BillInfo, Bill, Food, Drink 
WHERE BillInfo.idBill = Bill.id AND BillInfo.idFood = Food.id AND BillInfo.idDrink = Drink.id AND Bill.idTable = 4
