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
	count INT NOT NULL DEFAULT 0 

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id),
	FOREIGN KEY (idDrink) REFERENCES dbo.Drink(id)
)
GO
