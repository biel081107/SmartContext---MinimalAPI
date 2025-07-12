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

```bash
git clone https://github.com/SEU_USUARIO/SmartSupplements.git
cd SmartSupplements

dotnet restore

dotnet ef database update

dotnet run
```

📚 Descrição (PT-BR)
SmartSupplements é uma Minimal API desenvolvida com ASP.NET Core, simulando uma empresa fictícia de suplementos alimentares.
Ela inclui:

🛡️ Autenticação via JWT e validação de token

📦 Gerenciamento de produtos

🧾 Criação de pedidos com múltiplos produtos e quantidades

🗃️ Camadas de Repositório e Serviço para manter uma arquitetura limpa

🔁 Relacionamento muitos-para-muitos (Pedidos ⇄ Produtos)

🛠️ Tecnologias Utilizadas
ASP.NET Core 9 (Minimal API)

Entity Framework Core 9

SQLite

Autenticação JWT Bearer

Swagger (OpenAPI)

🧩 Estrutura do Banco de Dados
Tabela	Descrição
Usuarios	Armazena usuários e seus papéis (roles)
Produtos	Armazena informações dos produtos
Pedidos	Armazena os pedidos realizados
PedidosProdutos	Tabela intermediária (produto + quantidade)

🚀 Funcionalidades
✅ Login com criptografia de senha usando BCrypt

✅ Geração e validação de tokens JWT

✅ Criação de pedidos com vários produtos e quantidades

✅ Cálculo automático do valor total do pedido

✅ Listagem de pedidos e seus respectivos produtos

✅ Validações e tratamento de erros

✅ Camadas separadas: Serviço, Repositório e Models

▶️ Como Rodar Localmente
bash
Copiar
Editar
git clone https://github.com/SEU_USUARIO/SmartSupplements.git
cd SmartSupplements

dotnet restore

dotnet ef database update

dotnet run
Depois, acesse:

bash
Copiar
Editar
https://localhost:PORT/swagger
📌 Autor
Desenvolvido por Gabriel Alexandre

