# NZWalks

# ASP.NET Core Web API with .NET 8, EF Core, and SQL Server

This project is an **ASP.NET Core Web API** built using **.NET 8**, **Entity Framework Core (EF Core)**, and **SQL Server**. It follows best practices, including clean architecture principles, dependency injection, and authentication using JWT.

## 📌 About the Project
Developers of all levels master **ASP.NET Core Web API**.

This Project is designed for:
- **Beginners & Intermediate Developers** who have prior knowledge of **C#** and **ASP.NET MVC** and want to deepen their skills.
- Developers looking to understand **REST API development** with ASP.NET Core and .NET 8.

## 🚀 What You Will Learn

In this **ASP.NET Core Web API** Project, you will build a real-world project—creating an API to manage **regions and walks in New Zealand**. Clients can consume this API to fetch and manage data efficiently.

### 📌 Key Learning Areas
- **Understanding REST Principles** and how to build a Web API using **ASP.NET Core**
- **Setting up a .NET 8 Web API Project** with clean architecture
- **Installing and using Entity Framework Core (EF Core)** for database interactions
- **Applying EF Core Migrations** to create and update a **SQL Server Database**
- **Using Swagger UI** for API testing
- **Implementing Domain Models, DTOs, and the Repository Pattern**
- **Mapping Objects Using AutoMapper**
- **Performing CRUD Operations** (Create, Read, Update, Delete)
- **Implementing Authentication & Authorization** using **JWT Tokens**
- **Using ASP.NET Core Identity** to manage users and roles
- **Adding Filtering, Sorting, and Pagination**
- **Testing Authentication & Authorization with Postman & Swagger**

## 📂 Tech Stack
- **.NET 8**
- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core (EF Core)**
- **SQL Server**
- **AutoMapper**
- **JWT Authentication & Authorization**
- **Swagger & Postman**

## 🔧 Getting Started
### 1️⃣ Clone the Repository
```bash
git clone https://github.com/Jeeva7RP-DevEng/NZWalks/NZWalks-API.git
cd NZWalks-API
```

### 2️⃣ Configure the Database
- Update **appsettings.json** (or use `secrets.json` for security) with your **SQL Server connection string**.
- Apply database migrations:
  ```bash
  dotnet ef database update
  ```

### 3️⃣ Run the Application
```bash
dotnet run
```

The API will be available at `http://localhost:5000/swagger` for testing.

## 💡 Features
✔️ REST API following **RESTful best practices**
✔️ **Entity Framework Core** for data access
✔️ **Dependency Injection** for better code structure
✔️ **JWT Authentication & Role-Based Authorization**
✔️ **AutoMapper** for model-to-DTO conversion
✔️ **Filtering, Sorting, and Pagination**
✔️ **Unit Testing** (coming soon)

## 📜 License
This project is licensed under the **MIT License**.

---

**Happy Coding! 🚀**
