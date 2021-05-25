-- Seuphone Database

CREATE DATABASE Seuphone 
ON   
( NAME = SeuphoneDB,  
    FILENAME = 'C:\vs-workspace\Seuphone.Web\Seuphone.Database\seuphonedb.mdf',  
    SIZE = 10MB,  
    MAXSIZE = 500MB,  
    FILEGROWTH = 1MB )  
LOG ON  
( NAME = SeuphoneLOG,  
    FILENAME = 'C:\vs-workspace\Seuphone.Web\Seuphone.Database\seuphonelog.ldf',  
    SIZE = 10MB,  
    MAXSIZE = 200MB,  
    FILEGROWTH = 1MB 
);  

USE Seuphone;



CREATE TABLE tb_provider (
	Id int IDENTITY(1,1) NOT NULL,
	CompanyName VARCHAR(60) NOT NULL,
	CNPJ VARCHAR(60) NOT NULL,
	ZipCode VARCHAR(60) NOT NULL,
	Address VARCHAR(60) NOT NULL,
	HouseNumber int NOT NULL,
	District VARCHAR(60) NOT NULL,
	City VARCHAR(60) NOT NULL,
	State VARCHAR(60) NOT NULL,
	CONSTRAINT PK_tb_provider PRIMARY KEY (Id)
)


CREATE TABLE tb_role (
	Id int IDENTITY(1,1) NOT NULL,
	RoleName VARCHAR(20) NOT NULL,
	Description VARCHAR(60) NULL,
	CONSTRAINT PK_tb_role PRIMARY KEY (Id)
)


CREATE TABLE tb_user (
	Id int IDENTITY(1,1) NOT NULL,
	Email VARCHAR(40) NOT NULL,
	Password VARCHAR(20) NOT NULL,
	ConfirmPassword VARCHAR(60) NOT NULL,
	Token VARCHAR(60) NULL,
	Name VARCHAR(40) NOT NULL,
	Genre VARCHAR(1) NOT NULL,
	BirthDate datetime2(7) NOT NULL,
	CPF VARCHAR(14) NOT NULL,
	ZipCode VARCHAR(60) NOT NULL,
	Address VARCHAR(60) NOT NULL,
	HouseNumber int NOT NULL,
	District VARCHAR(60) NOT NULL,
	City VARCHAR(60) NOT NULL,
	State VARCHAR(60) NOT NULL,
	CONSTRAINT PK_tb_user PRIMARY KEY (Id)
)


CREATE TABLE tb_order (
	Id int IDENTITY(1,1) NOT NULL,
	UserId int NOT NULL,
	Total float NOT NULL,
	ContractDuration int NOT NULL,
	CreationDate datetime2(7) NOT NULL,
	OrderStatus int NOT NULL,
	PaymentMethod int NOT NULL,
	OrderType int NOT NULL,
	CONSTRAINT PK_tb_order PRIMARY KEY (Id),
	CONSTRAINT FK_tb_order_tb_user_UserId FOREIGN KEY (UserId) REFERENCES tb_user(Id)
)


CREATE TABLE tb_product (
	Id int IDENTITY(1,1) NOT NULL,
	ProductName VARCHAR(60) NOT NULL,
	Description VARCHAR(60) NOT NULL,
	Model VARCHAR(60) NOT NULL,
	Color VARCHAR(60) NOT NULL,
	Storage VARCHAR(60) NOT NULL,
	Price float NOT NULL,
	StockQuantity int NOT NULL,
	[Image] varchar(MAX) NOT NULL,
	ProviderId int NOT NULL,
	CONSTRAINT PK_tb_product PRIMARY KEY (Id),
	CONSTRAINT FK_tb_product_tb_provider_ProviderId FOREIGN KEY (ProviderId) REFERENCES tb_provider(Id)
)


CREATE TABLE tb_user_role (
	UserId int NOT NULL,
	RoleId int NOT NULL,
	CONSTRAINT PK_tb_user_role PRIMARY KEY (UserId,RoleId),
	CONSTRAINT FK_tb_user_role_tb_role_RoleId FOREIGN KEY (RoleId) REFERENCES tb_role(Id),
	CONSTRAINT FK_tb_user_role_tb_user_UserId FOREIGN KEY (UserId) REFERENCES tb_user(Id)
)


CREATE TABLE tb_order_items (
	Id int IDENTITY(1,1) NOT NULL,
	Quantity int NOT NULL,
	SubTotal float NOT NULL,
	OrderId int NOT NULL,
	ProductId int NOT NULL,
	CONSTRAINT PK_tb_order_items PRIMARY KEY (Id),
	CONSTRAINT FK_tb_order_items_tb_order_OrderId FOREIGN KEY (OrderId) REFERENCES tb_order(Id),
	CONSTRAINT FK_tb_order_items_tb_product_ProductId FOREIGN KEY (ProductId) REFERENCES tb_product(Id)
)
