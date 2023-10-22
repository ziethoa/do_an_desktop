﻿CREATE DATABASE QuanLyQuanBida
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

CREATE TABLE FoodAndDrinkCatagory
(
	id INT IDENTITY PRIMARY KEY,
	tenhienthi NVARCHAR (100)NOT NULL DEFAULT N'Chua dat ten'
)
GO
DROP TABLE FoodCatagory

CREATE TABLE FoodAndDrink
(
	id INT IDENTITY PRIMARY KEY,
	tenhienthi NVARCHAR (100)NOT NULL DEFAULT N'Chua dat ten',
	idCatagory INT NOT NULL,
	gia INT NOT NULL DEFAULT 0

	FOREIGN KEY (idCatagory) REFERENCES dbo.FoodAndDrinkCatagory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	ngayvaogiovao DATETIME NOT NULL DEFAULT GETDATE(),
	ngayragiora DATETIME ,
	idTable INT NOT NULL,
	tinhtrang INT NOT NULL DEFAULT 0, -- 1: da thanh toan, 0: chua thanh toan
	tonggia INT NOT NULL

	FOREIGN KEY (idTable) REFERENCES dbo.TableBida(id)
)
GO
ALTER TABLE Bill
ADD giamgia int
UPDATE Bill SET giamgia = 0

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFoodOrDrink INT NOT NULL,
	count INT NOT NULL DEFAULT 0 

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFoodOrDrink) REFERENCES dbo.FoodAndDrink(id)
)
GO

DROP TABLE Bill

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

UPDATE TableBida SET tinhtrang = N'Trống' WHERE ten = N'Bàn 10'

SELECT* FROM TableBida
SELECT* FROM Bill
SELECT* FROM BillInfo	
SELECT* FROM FoodAndDrink
SELECT* FROM FoodAndDrinkCatagory 
GO
--thêm food catagory
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'-None-' )
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'Trái cây' )
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'Ăn Vặt' )
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'Mì' )
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'Cơm' )
GO
--thêm drink catagory
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'Nước Ngọt' )
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'Bia' )
INSERT INTO FoodAndDrinkCatagory ( tenhienthi ) VALUES ( N'Thuốc lá' )
GO
--thêm món ăn
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'-None-', 1, 0 )
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Táo', 2, 15000 )
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Ổi', 2, 15000 )
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Thơm', 2, 15000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Xoài',2 ,15000) 
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Mận', 2, 15000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Khoai tây chiên', 3, 30000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Xiên que', 3, 30000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Snack', 3, 15000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Bắp xào', 3, 20000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Mì xào bò', 4, 40000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Mì xào hải sản', 4, 40000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Cơm chiên dương châu', 5, 35000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Cơm gà', 5, 35000)
GO
--thêm đồ uống
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Sting', 6, 10000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'7up', 6, 10000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Pepsi/Coca', 6, 10000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Redbull', 6, 10000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Trà xanh không độ', 6, 10000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Cafe', 6, 15000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Aquafina', 6, 7000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Bia 333', 7, 15000) 
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Bia Tiger', 7, 15000)
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Thuốc lá Ba số bạc', 8, 30000) 
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Thuốc lá Sài gòn bạc', 8, 30000) 
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Thuốc lá Con mèo', 8, 30000) 
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES (N'Thuốc lá Con ngựa', 8, 30000) 
GO
--reset id identity
DELETE FROM TableBida
DELETE FROM Bill
DELETE FROM BillInfo 
DELETE FROM FoodAndDrink
DELETE FROM FoodAndDrinkCatagory
DBCC CHECKIDENT(TableBida, RESEED, 0)
DBCC CHECKIDENT(Bill, RESEED, 0)
DBCC CHECKIDENT(BillInfo, RESEED, 0)
DBCC CHECKIDENT(FoodAndDrink, RESEED, 0)
DBCC CHECKIDENT(FoodAndDrinkCatagory, RESEED, 0)
GO
--bill
INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia) VALUES (GETDATE(), GETDATE(), 4, 1, 0)
INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia) VALUES (GETDATE(), GETDATE(), 6, 1, 0)
INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia) VALUES (GETDATE(), GETDATE(), 9, 1, 0)
INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia) VALUES (GETDATE(), NULL, 7, 0, 0)
GO
--bill info 
INSERT INTO BillInfo (idBill, idFoodOrDrink, count) VALUES (2, 4, 4)
INSERT INTO BillInfo (idBill, idFoodOrDrink, count) VALUES (3, 14, 2)
INSERT INTO BillInfo (idBill, idFoodOrDrink, count) VALUES (2, 9, 3)
INSERT INTO BillInfo (idBill, idFoodOrDrink, count) VALUES (1, 7, 3)
GO

CREATE PROC USP_Bills--da them vao vs
@IdTable int 
AS
BEGIN
	SELECT* FROM Bill WHERE idTable = @IdTable AND tinhtrang = 1
END
GO
EXEC USP_Bills @IdTable = 7
GO

CREATE PROC USP_BillInfos
@IdTable int
AS
BEGIN
	SELECT FoodAndDrink.tenhienthi, BillInfo.count, FoodAndDrink.gia, BillInfo.count*FoodAndDrink.gia AS 'Tonggia'FROM BillInfo, Bill, FoodAndDrink 
	WHERE BillInfo.idBill = Bill.id AND BillInfo.idFoodOrDrink = FoodAndDrink.id AND Bill.tinhtrang = 0 AND Bill.idTable = @IdTable
END
GO
EXEC USP_BillInfos @IdTable 
GO

SELECT* FROM Bill WHERE idTable = 4 AND tinhtrang = 1
SELECT FoodAndDrink.tenhienthi, BillInfo.count, FoodAndDrink.gia, BillInfo.count*FoodAndDrink.gia AS 'Tonggia'FROM BillInfo, Bill, FoodAndDrink 
WHERE BillInfo.idBill = Bill.id AND BillInfo.idFoodOrDrink = FoodAndDrink.id AND Bill.idTable = 4
GO

CREATE PROC USP_Catagory
AS
	SELECT* FROM FoodAndDrinkCatagory
GO
EXEC USP_Catagory
GO

CREATE PROC USP_CatagoryByID
@idcatagory int
AS
BEGIN
	SELECT* FROM FoodAndDrinkCatagory WHERE id = @idcatagory
END
GO
EXEC USP_CatagoryByID @idcatagory
GO

CREATE PROC USP_FoD
@idcatagory int
AS
BEGIN
	SELECT* FROM FoodAndDrink WHERE idCatagory = @idcatagory
END
GO
EXEC USP_FoD @idcatagory 
GO

--CAST (GETDATE() AS DATE: chuyển datetime thành date
CREATE PROC USP_InsertBill
@idTable int
AS
BEGIN
	INSERT INTO Bill (ngayvaogiovao, ngayragiora, idTable, tinhtrang, tonggia, giamgia) VALUES ( GETDATE(), NULL, @idTable, 0, 0, 0)
END
GO
EXEC USP_InsertBill @idTable 
GO

CREATE PROC USP_InsertBillInfo
@idBill int,
@idFoD int,
@count int
AS
BEGIN
	INSERT INTO BillInfo (idBill, idFoodOrDrink, count) VALUES (@idBill, @idFoD, @count)
END
GO

EXEC USP_InsertBillInfo @idBill = 2 , @idFoD = 1 , @count = 1
GO

--sửa proc
ALTER PROC USP_InsertBillInfo
@idBill int,
@idFoD int,
@count int
AS
BEGIN
	DECLARE @isExistBillInfo int = 0
	DECLARE @FoDcount int = 1

	SELECT @isExistBillInfo = id, @FoDcount = BillInfo.count FROM BillInfo WHERE idBill = @idBill AND idFoodOrDrink = @idFoD

	IF(@isExistBillInfo > 0)
	BEGIN
		DECLARE @NewCount int = @FoDcount + @count
		IF (@NewCount > 0)
			UPDATE BillInfo SET BillInfo.count = @FoDcount + @count WHERE idFoodOrDrink = @idFoD
		ELSE
			DELETE BillInfo WHERE idBill = @idBill AND idFoodOrDrink = @idFoD
	END 
	ELSE
	BEGIN
		INSERT INTO BillInfo (idBill, idFoodOrDrink, BillInfo.count) VALUES (@idBill, @idFoD, @count)
	END
END
GO

SELECT* FROM Bill WHERE idTable = 1 AND tinhtrang = 0

SELECT id,count FROM BillInfo WHERE idBill = 5 

SELECT MAX(id) FROM Bill

--them bot mon t-sql





CREATE TRIGGER UTG_UpdateBillInfo
ON BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill int
	SELECT @idBill = idBill FROM inserted
	DECLARE @idTable int
	SELECT @idTable = idTable FROM Bill WHERE id = @idBill AND tinhtrang = 0
	UPDATE TableBida SET tinhtrang = N'Có người' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_UpdateBill
ON Bill FOR UPDATE
AS 
BEGIN
	DECLARE @idBill int
	SELECT @idBill = id FROM inserted
	DECLARE	@idTable int
	SELECT @idTable = idTable FROM Bill WHERE id = @idBill
	DECLARE @count int = 0
	SELECT @count = COUNT(*) FROM Bill WHERE idTable = @idTable AND tinhtrang = 0
	IF(@count = 0)
		UPDATE TableBida SET tinhtrang = N'Trống' WHERE id = @idTable
END
GO

CREATE PROC USP_GetListBillByDate
@checkin DATE, @checkout DATE
AS
BEGIN
	SELECT t.ten AS [Số Bàn], b.tonggia AS [Tổng tiền], b.ngayvaogiovao AS [Ngày giờ Checkin], b.ngayragiora AS [Ngày giờ Checkout], b.giamgia AS [Giảm giá]
	FROM Bill as b, TableBida as t
	WHERE b.ngayvaogiovao >= @checkin  AND b.ngayragiora <= @checkout AND b.tinhtrang = 1 AND t.id = b.idTable
END
GO
EXEC USP_GetListBillByDate @checkin, @checkout

CREATE PROC USP_UpdateAccount
@username nvarchar(50), @displayname nvarchar(50), @password nvarchar(50), @newpassword nvarchar(50) 
AS
BEGIN
	DECLARE @isRightPass INT
	SELECT @isRightPass = COUNT(*) FROM Account WHERE tennguoidung = @username AND matkhau = @password
	IF (@isRightPass = 1)
		BEGIN
			IF (@newpassword = NULL OR @newpassword = '')
			BEGIN
				UPDATE Account SET tenhienthi = @displayname WHERE tennguoidung = @username
			END
			ELSE
				UPDATE Account SET tenhienthi = @displayname, matkhau = @password WHERE tennguoidung = @username
		END
END
GO
INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES ( N'', 0 , 0.0)	

UPDATE FoodAndDrink SET tenhienthi = N'', idCatagory = 0, gia = 0 WHERE id = 3

SELECT* FROM TableBida
SELECT* FROM Bill
SELECT* FROM BillInfo	
SELECT* FROM FoodAndDrink
SELECT* FROM FoodAndDrinkCatagory 
SELECT* FROM Account
SELECT tenhienthi AS N'Displayname', tennguoidung AS N'Username' FROM Account
GO