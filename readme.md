# Seuphone Web
Seuphone web é uma aplicação simulando um e-commerce com diversas funcionalidades.

- ⚠️ Atenção
- Esta aplicação está divida entre BACK-END (Esta página) e FRONT-END, a outra parte você pode estar [consultando aqui](https://github.com/emersonmelomartins/seuphone-web-frontend-react)
- Essa aplicação trata-se de um projeto do 4 Semestre do curso de Análise e Desenvolvimento de Sistemas da faculdade FAPEN e foi desenvolvida apenas com o intuito de estudos.
- Você pode consultar projetos de outros semestres também:
- [2 Semestre](https://github.com/emersonmelomartins/fapen-seuphone).
- [3 Semestre](https://github.com/emersonmelomartins/fapen-seuphone-ionic).

## Demonstração
Você pode acessar a demonstração da página acessando [este link.](https://emersonmelomartins.dev.br/)
E também a documentação das apis [acessando aqui.](http://api.emersonmelomartins.dev.br/index.html)

```sh
# usuário administrador para testes.
usuário: bob.brown@gmail.com
senha: 123456

# Você também pode criar seu proprio usuário.
```

## Features
- Usuários
- - Criação e atualização de dados;
- - Recuperação de senha;
- Produtos
- - Listagem de produtos (Apenas com estoque);
- - Filtro de busca;
- Carrinho
- - Adição e Remoção de produtos;
- - Atualização de quantidade;
- Pedido de Compra
- - Método de pagamento (Demonstrativo apenas);
- - Atualização de endereço no ato da compra;
- Painel Administrativo;
- - Criação de Usuários;
- - Criação de Pedidos;

## Tecnologias

Esse projeto utiliza:

- [C#] - Linguagem da Microsoft para o desenvolvimento das APIS do back-end;
- [SQL Server] - Banco de dados utilizado para armazenamento de informação;
- [ReactJS] - Biblioteca em javascript para a construção do front-end;
- [Swagger] - Documentação das APIS;
- [.NET Core 3.1] - Versão utilizada no projeto;
- [Entity Framework] - Mapeamento do banco de dados para os models da aplicação.
- Opcional [Docker] - Container para a criação do banco de dados.


## Instalação
Para seguir os passos abaixo é recomendado que você tenha o [Docker](https://docs.docker.com/get-docker/), [.NET SDK 3.1](https://netovieiraleo.medium.com/instalando-e-configurando-o-dotnet-core-no-ubuntu-18-04-4-c78fbcc7472f) e [Entity Framework CLI](https://docs.microsoft.com/pt-br/ef/core/cli/dotnet) instalados.


A criação do banco de dados
```sh
# Baixar imagem sql server
docker pull mcr.microsoft.com/mssql/server

# Criando container com sql server
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=1q2w3e4R@#$" -p 1433:1433 --name seuphone-sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

Acesse a pasta "Seuphone.Api" e baixe as dependencias
```sh
dotnet restore
```

Criar/Atualizar tabelas do banco de dados
```sh
# Certifique-se de que a senha que você informou na criação do container seja a mesma que está localizada no arquivo "appsettings.json" do projeto.
dotnet ef database update
```

Executar aplicação
```sh
# É necessário estar na pasta "Seuphone.Api" para executar.
dotnet run
```

O projeto estára sendo executado na seguinte url:
```sh
http://localhost:5000
```

Por padrão é criado um usuário com os seguintes dados:
```sh
usuário: bob.brown@gmail.com
senha: 123456

# Ou

usuário: m_green@gmail.com
senha: 123456
```

