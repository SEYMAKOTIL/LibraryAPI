# LibraryAPI

## Features

- User Registration and Login (JWT Authentication)
- Role-Based Authorization (Admin, User)
- Book CRUD Operations
- Admin: Add, update, delete books
- User: List and view books
- API Documentation with Swagger
- Using SQL Server Databases with Entity Framework Core

## Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- JWT Authentication
- Swagger (OpenAPI)
- SQL Server (LocalDB)

## Installation

1. Clone the repository:
bash
git clone https://github.com/SEYMAKOTIL/LibraryAPI.git
cd LibraryAPI

2. Install dependencies:
dotnet restore

3. Perform database migrations:
dotnet ef database update

4. Run the application:
dotnet run

5. Open Swagger UI in browser:
https://localhost:{port}/swagger

## Usage

You can register a user using /api/auth/register.
You can obtain a JWT token using /api/auth/login.
You can use the token to make authorized requests for book transactions.
The Admin role can add, update, and delete books.
The User role can list and view books.

## Contributing
I look forward to your contributions! Please submit a pull request or open an issue.
