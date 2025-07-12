# 🧠 SmartSupplements API (Minimal API with JWT, EF Core, SQLite)

## 📜 Description (EN)

SmartSupplements is a **Minimal API built with ASP.NET Core**, simulating a fictional supplement company.  
It includes:

- 🛡️ JWT Authentication and Token Validation
- 📦 Product management
- 🧾 Order creation with multiple products
- 🗃️ Repository and Service Layers for clean architecture
- 🔁 Many-to-Many relationship (Orders ⇄ Products)

This project follows **best practices** using:
- Minimal APIs (no controllers)
- Clean folder structure
- Error handling and model validation

---

## 🛠️ Technologies Used

- ASP.NET Core 9 (Minimal API)
- Entity Framework Core 9
- SQLite
- JWT Bearer Authentication
- Swagger (OpenAPI)

---

## 🧩 Database Structure

| Table              | Description                                 |
|--------------------|---------------------------------------------|
| `Usuarios`         | Stores user credentials and roles           |
| `Produtos`         | Stores product data                         |
| `Pedidos`          | Stores customer orders                      |
| `PedidosProdutos`  | Intermediary table (Product + Quantity)     |

---

## 🚀 Features

- ✅ User login with password hashing (BCrypt)
- ✅ JWT token generation and validation
- ✅ Create orders with multiple products and quantities
- ✅ Calculates total price of orders automatically
- ✅ List all orders and their associated products
- ✅ Validations and error handling
- ✅ Repository and Service Layer separation

---

## ▶️ How to Run Locally

1. Clone the repo:
   ```bash
   git clone https://github.com/SEU_USUARIO/SmartSupplements.git
   cd SmartSupplements
Restore packages:

bash
Copiar
Editar
dotnet restore
Apply migrations (if needed):

bash
Copiar
Editar
dotnet ef database update
Run the app:

bash
Copiar
Editar
dotnet run
Access Swagger at:

bash
Copiar
Editar
https://localhost:PORT/swagger
📚 Descrição (PT-BR)
SmartSupplements é uma Minimal API em ASP.NET Core que simula uma empresa fictícia de suplementos.
Ela possui:

🛡️ Login com autenticação JWT e validação de token

📦 Sistema de produtos

🧾 Criação de pedidos com múltiplos produtos e quantidades

🗃️ Arquitetura com repositórios, serviços e Program.cs

🔧 Tecnologias Utilizadas
ASP.NET Core 9 (Minimal API)

Entity Framework Core 9

SQLite

JWT Bearer Authentication

Swagger (OpenAPI)

🧩 Estrutura do Banco de Dados
Tabela	Descrição
Usuarios	Armazena usuários e papéis (roles)
Produtos	Armazena os dados dos produtos
Pedidos	Armazena os pedidos realizados
PedidosProdutos	Tabela intermediária (produto + quantidade)

✅ Funcionalidades
Login com criptografia de senha (BCrypt)

Geração e validação de tokens JWT

Criação de pedidos com vários produtos

Cálculo automático do valor total do pedido

Listagem de pedidos com seus respectivos produtos

Validações de entrada e tratamento de erros

Separação em camadas: Service, Repository, Models

▶️ Como Rodar Localmente
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/SEU_USUARIO/SmartSupplements.git
cd SmartSupplements
Restaure os pacotes:

bash
Copiar
Editar
dotnet restore
Aplique as migrations (se necessário):

bash
Copiar
Editar
dotnet ef database update
Rode o projeto:

bash
Copiar
Editar
dotnet run
Acesse o Swagger:

bash
Copiar
Editar
https://localhost:PORT/swagger

📌 Autor
Desenvolvido por Gabriel Alexandre