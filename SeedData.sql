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
-- Insert the sample records to the Product Table 
Insert into Product(Name,Price,Photo) values('Access Point',950,'Images/AccessPoint.png') 
Insert into Product(Name,Price,Photo) values('CD',350,'Images/CD.png') 
Insert into Product(Name,Price,Photo) values('Desktop Computer',1400,'Images/DesktopComputer.png') 
Insert into Product(Name,Price,Photo) values('DVD',1390,'Images/DVD.png') 
Insert into Product(Name,Price,Photo) values('DVD Player',450,'Images/DVDPlayer.png') 
Insert into Product(Name,Price,Photo) values('Floppy',1250,'Images/Floppy.png') 
Insert into Product(Name,Price,Photo) values('HDD',950,'Images/HDD.png') 
Insert into Product(Name,Price,Photo) values('MobilePhone',1150,'Images/MobilePhone.png') 
Insert into Product(Name,Price,Photo) values('Mouse',399,'Images/Mouse.png') 
Insert into Product(Name,Price,Photo) values('MP3 Player ',897,'Images/MultimediaPlayer.png') 
Insert into Product(Name,Price,Photo) values('Notebook',750,'Images/Notebook.png') 
Insert into Product(Name,Price,Photo) values('Printer',675,'Images/Printer.png') 
Insert into Product(Name,Price,Photo) values('RAM',1950,'Images/RAM.png') 
Insert into Product(Name,Price,Photo) values('Smart Phone',679,'Images/SmartPhone.png') 
Insert into Product(Name,Price,Photo) values('USB',950,'Images/USB.png') 
 
select * from Product


CREATE TABLE ShoppingDetails 
( 
ShopId int identity(1,1), 
ProductId int , 
UserName VARCHAR(100) NOT NULL, 
Qty int NOT NULL, 
TotalAmount int, 
Description VARCHAR(200) NOT NULL, 
shoppingDate DateTime, 
CONSTRAINT [PK_ShoppingDetails] PRIMARY KEY CLUSTERED  
(  
[shopId] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  

select * from ShoppingDetails