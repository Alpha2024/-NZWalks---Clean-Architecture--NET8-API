# NZWalks
A Clean Architecture .NET 8 Web API for managing regional walks and trails, built with EF Core, JWT auth, AutoMapper, and Serilog
# 🌍 NZWalks - Clean Architecture .NET 8 API

**NZWalks** is a sample ASP.NET Core Web API application designed using Clean Architecture principles. It demonstrates modern backend practices, including layered separation, AutoMapper, JWT authentication, Serilog logging, and Swagger integration.

---

## 🚀 Features

- ✅ ASP.NET Core Web API with .NET 8
- ✅ Clean Architecture (API, Core, Infrastructure layers)
- ✅ Entity Framework Core for Data Access
- ✅ JWT Authentication and Authorization
- ✅ AutoMapper for DTO Mapping
- ✅ Serilog Logging (file and console)
- ✅ Swagger UI for API testing and documentation
- ✅ Custom Action Filters and Middleware

---

## 🏗️ Project Structure
NZWalks/
│
├── NZWalks.API/ --> Presentation Layer (Controllers, Filters, Services, Middleware)
│ ├── Controllers/
│ ├── Dtos/
│ ├── MappingProfiles/
│ ├── Middlewares/
│ ├── Program.cs
│ └── appsettings.json
│
├── NZwalks.Core/ --> Domain Layer (Entities, Interfaces, Contracts)
│
├── NZwalks.Infrasture/ --> Infrastructure Layer (EF Core, Repository Implementations)
│
└── NZWalks.sln --> Solution File

---

## 🛠️ Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- Serilog
- JWT Bearer Authentication
- Swagger / Swashbuckle
- SQL Server

---

## ⚙️ Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (local or cloud)
- Visual Studio 2022+ or VS Code

### Setup Instructions

1. **Clone the repository:**
```bash

###🔐 Authentication
### This API uses JWT Bearer Tokens. Use /api/login or your custom authentication route to generate a token, then add it to Swagger under Authorize.
 Future Improvements
Unit and integration tests with xUnit/Moq

API versioning

Role-based authorization for specific endpoints

Global exception handling middleware

Docker support

📬 Contact
Alpha Unisa Sesay
  Software Developer @ GTBank Sierra Leone
📧 unisa7590@gmail.com
🔗 GitHub: github.com/Alpha2024
