# 📦 Products API

API REST para gerenciamento de produtos desenvolvida em **ASP.NET Core (.NET 9)**, utilizando **Entity Framework Core**, **PostgreSQL**, **Docker** e **arquitetura em camadas**.

---

## 🧠 Descrição

Este projeto tem como objetivo demonstrar a criação de uma API moderna em .NET, com boas práticas de organização, separação de responsabilidades e persistência de dados. A aplicação permite o cadastro e gerenciamento de produtos, utilizando migrações do EF Core para criação automática das tabelas no banco de dados.

---

## 🗂️ Estrutura do Projeto

```
ProductsApi.sln
├── ProductsApi.API              # Camada de apresentação (Controllers, Program.cs)
├── ProductsApi.Application      # Camada de aplicação (Services, DTOs)
├── ProductsApi.Domain           # Camada de domínio (Entidades, Interfaces)
├── ProductsApi.Infrastructure   # Infraestrutura (DbContext, Repositories, Migrations)
```

---

## 🚀 Tecnologias Utilizadas

* **.NET 9 / C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **PostgreSQL**
* **Docker**
* **Swagger (Swashbuckle)**
* **xUnit / EF InMemory (Testes)**

---

## ✅ Pré-requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

* [.NET SDK 9](https://dotnet.microsoft.com/)
* [Docker](https://www.docker.com/)
* Visual Studio 2022 ou VS Code

---


## 🔧 Configuração da Connection String

No arquivo `appsettings.json` da API:

```json
"ConnectionStrings": {
  "Postgres": "Host=localhost;Port=5432;Database=productsdb;Username=postgres;Password=postgres"
}
```

---

## 🗄️ Migrações e Criação das Tabelas

Crie a migration inicial:

```bash
dotnet ef migrations add InitialCreate \
  --project ProductsApi.Infrastructure\ProductsApi.Infrastructure.csproj \
  --startup-project ProductsApi.API\ProductsApi.API.csproj
```

Aplique a migration no banco:

```bash
dotnet ef database update \
  --project ProductsApi.Infrastructure\ProductsApi.Infrastructure.csproj \
  --startup-project ProductsApi.API\ProductsApi.API.csproj
```

---

## ▶️ Executando a Aplicação

```bash
dotnet run --project ProductsApi.API\ProductsApi.API.csproj
```

Acesse o Swagger:

```
https://localhost:5001/swagger
```

---

## 📌 Endpoints Principais

| Método | Rota           | Descrição               |
| ------ | -------------- | ----------------------- |
| GET    | /products      | Lista todos os produtos |
| GET    | /products/{id} | Busca produto por ID    |
| POST   | /products      | Cria um novo produto    |
| PUT    | /products/{id} | Atualiza um produto     |
| DELETE | /products/{id} | Remove um produto       |

---

## 🧪 Testes Unitários

Para testes, é utilizado o **Entity Framework InMemory**, permitindo testar regras de negócio sem dependência de banco real.

Exemplo:

```csharp
var options = new DbContextOptionsBuilder<ProductsDbContext>()
    .UseInMemoryDatabase("TestDb")
    .Options;
```

---
