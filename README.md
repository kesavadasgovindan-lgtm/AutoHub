# AutoHub 🚗

AutoHub is a web-based garage management system designed for billing, inventory management, and reporting.

This project is built using **Clean Architecture** with **ASP.NET Core (.NET 8)** and is intended for small to medium automobile workshops.

---

## 🔧 Features

- Customer management
- Employee management
- Inventory management
- Billing & invoicing
- VAT-ready reporting
- Clean Architecture structure
- Repository pattern with Unit of Work
- RESTful APIs
- Swagger API documentation

---

## 🏗 Architecture

AutoHub
│
├── AutoHub.Api → API layer (Controllers)
├── AutoHub.Application → Business logic
├── AutoHub.Domain → Entities
└── AutoHub.Infrastructure → Database & EF Core


---

## 🛠 Tech Stack

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core 8
- SQL Server / LocalDB
- Swagger
- Clean Architecture
- Repository Pattern
- Unit of Work

---

## 🚀 Getting Started

### Prerequisites
- .NET SDK 8
- SQL Server LocalDB
- Visual Studio 2022

### Run the project

```bash
dotnet run --project src/AutoHub.Api


http://localhost:5119/swagger

🚧 Backend in active development
Frontend (React) will be added later.