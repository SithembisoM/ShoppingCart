USE MASTER 
GO 

IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'ShoppingCartDB' ) 
DROP DATABASE ShoppingCartDB 
GO 
 
CREATE DATABASE ShoppingCartDB 
GO 
 
USE ShoppingCartDB 
GO  
 
CREATE TABLE Product 
( 
	Id int identity(1,1), 
	Name VARCHAR(100) NOT NULL, 
	Price int NOT NULL, 
	Photo VARCHAR(100) NOT NULL, 
CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED  
(  
[Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO   


INSERT INTO Product([Name], Price, Photo) VALUES ('Notebook',750,'Images/Notebook.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('Printer',675,'Images/Printer.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('RAM',1950,'Images/RAM.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('Smart Phone',679,'Images/SmartPhone.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('USB',950,'Images/USB.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('Access Point',950,'Images/AccessPoint.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('CD',350,'Images/CD.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('Desktop Computer',1400,'Images/DesktopComputer.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('DVD',1390,'Images/DVD.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('DVD Player',450,'Images/DVDPlayer.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('Floppy',1250,'Images/Floppy.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('HDD',950,'Images/HDD.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('MobilePhone',1150,'Images/MobilePhone.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('Mouse',399,'Images/Mouse.png') 
INSERT INTO Product([Name], Price, Photo) VALUES ('MP3 Player ',897,'Images/MultimediaPlayer.png') 
 
CREATE TABLE ShoppingDetails 
( 
	ShopId int identity(1,1), 
	ProductId int , 
	UserName VARCHAR(100) NOT NULL, 
	Qty int NOT NULL, 
	TotalAmount int, 
	[Description] VARCHAR(200) NOT NULL, 
	shoppingDate DateTime, 
CONSTRAINT [PK_ShoppingDetails] PRIMARY KEY CLUSTERED  
(  
[shopId] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
