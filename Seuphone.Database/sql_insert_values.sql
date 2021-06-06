-- Script inserção de dados no banco de dados

USE Seuphone;

-- TB_USER
INSERT INTO tb_user VALUES ('emerson@email.com', '123456', '123456', 
'698dc19d489c4e4db73e28a713eab07b', 'Emerson Melo', 'M', '05/06/1995',
'316.678.480-20', '09360-490', 'Av. Caetano Scila', '285', 'Vila Assis Brasil', 'Mauá', 'SP' );
INSERT INTO tb_user VALUES ('thais@email.com', '654321', '654321', 
'e8a88bb6f4d420a8517965d25cd54a14', 'Thais Martins', 'F', '01/01/1990',
'011.615.830-17', '09112-000', 'Rua Silla Nalon Gonzaga', '70', 'Parque Marajoara', 'Santo André', 'SP' );
INSERT INTO tb_user VALUES ('everton@email.com', '123654', '123654', 
'70ecdf02ed3885202139357cc595622d', 'Everton Chabariberi', 'M', '02/02/1989',
'620.305.390-23', '09112-000', 'Rua Silla Nalon Gonzaga', '70', 'Parque Marajoara', 'Santo André', 'SP' );


-- TB_ROLE
INSERT INTO tb_role VALUES ('ROLE_ADMIN', 'Administrador do Sistema');
INSERT INTO tb_role VALUES ('ROLE_CLIENTE', 'Cliente do Sistema');
INSERT INTO tb_role VALUES ('ROLE_DEV', 'Desenvolvedor do Sistema');


-- TB_USER_ROLE
INSERT INTO tb_user_role VALUES (1, 1);
INSERT INTO tb_user_role VALUES (2, 1);
INSERT INTO tb_user_role VALUES (3, 2);


-- TB_PROVIDER
INSERT INTO tb_provider VALUES ('Apple Computer', '47.071.378/0001-40', 
'04542-000', 'Av Leopoldo C de Magalhaes Jr', 700, 'Bota Fogo', 'São Paulo', 'SP');
INSERT INTO tb_provider VALUES ('Rei das Capinhas', '92.655.064/0001-49', 
'09932-012', 'Rua Lazar Segal', 120, 'Brasil', 'São Paulo', 'SP');
INSERT INTO tb_provider VALUES ('Carregadores Apple', '94.336.917/0001-05', 
'09360-888', 'Rua Ruerato', 458, 'Vila América', 'Santo André', 'SP');


-- TB_PRODUCT
INSERT INTO tb_product VALUES('iPhone 12', 'iPhone 12 - 64GB - Azul', 
'iPhone 12', 'Azul', '64GB', 6999.99, 0, 'codigo_base64', 1);
INSERT INTO tb_product VALUES('iPhone 12 Pro', 'iPhone 12 Pro - 128GB - Vermelho', 
'iPhone 12 Pro', 'Vermelho', '128GB', 8999.99, 0, 'codigo_base64', 1);
INSERT INTO tb_product VALUES('iPhone 12 Pro Max', 'iPhone 12 Pro Max - 512GB - Grafite', 
'iPhone 12 Pro Max', 'Grafite', '512GB', 12999.99, 0, 'codigo_base64', 1);


-- TB_ORDER
INSERT INTO tb_order VALUES (1, 15000.99, 2, '27/05/2021', 1, 2, 1);
INSERT INTO tb_order VALUES (2, 9999.99, 1, '26/05/2021', 2, 1, 1);
INSERT INTO tb_order VALUES (1, 6999.00, 2, '25/05/2021', 1, 1, 2);


-- TB_ORDER_ITEMS
INSERT INTO tb_order_items VALUES(2, 9999.99, 1, 1);
INSERT INTO tb_order_items VALUES(5, 29999.99, 1, 3);
INSERT INTO tb_order_items VALUES(1, 6999.99, 2, 2);