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

-- Testing
SELECT * FROM tb_user;
INSERT INTO tb_user VALUES('emerson25xd@gmail.com', '123456', 'Emerson Melo Martins', 'M', '05/06/1995', '123.456.789-10', '09360490', 'Av. Caetano Scila', 285, 'Vila Assis Brasil', 'Mauá', 'SP');

SELECT * FROM tb_provider;
INSERT INTO tb_provider VALUES('Empresa', '123.456.789/0001-01', '09360490', 'Logradouro', 200, 'Bairro tal', 'Cidade', 'SP');

SELECT * FROM tb_product;
INSERT INTO tb_product VALUES('Produto 1', 'Modelo tal', 'Midnight Green', '128GB', 9999.99, 'base64code', 1);

SELECT * FROM tb_order;

SELECT * FROM tb_order_items;

