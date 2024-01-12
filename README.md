# DokanDar

DokanDar is a web API built using ASP.NET Core (.NET 7) that follows the clean architecture principles. It incorporates Entity Framework Core for data access, ADO.NET for specific scenarios, and utilizes JWT authorization with Identity for secure authentication. The project implements a generic repository and generic service pattern to achieve a scalable and maintainable codebase.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Configuration](#configuration)
- [Database](#database)
- [Authentication](#authentication)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Clean Architecture:** DokanDar follows the clean architecture principles, consisting of four layers: Domain, Application, Infrastructure, and API.
- **ASP.NET Core Web API:** Utilizing the power and flexibility of ASP.NET Core for building robust and scalable APIs.
- **Entity Framework Core:** For data access and database interactions.
- **ADO.NET:** Used for specific scenarios where low-level database interactions are necessary.
- **JWT Authorization with Identity:** Ensures secure and authenticated access to the API.
- **Generic Repository and Service Pattern:** Implements a generic repository and service pattern for efficient and consistent data access.
- **SQL Server Database:** DokanDar uses SQL Server as its primary database.

## Technologies Used

- ASP.NET Core 7
- Entity Framework Core
- ADO.NET
- JWT (JSON Web Tokens) for Authorization
- Identity Framework Core
- SQL Server

## Getting Started

To get started with DokanDar, follow these steps:

1. Clone the repository: `git clone https://github.com/mostakahammed/DokanDar.git`
2. Open the solution in your preferred IDE (Visual Studio, Rider, etc.).
3. Configure the necessary settings (see [Configuration](#configuration)).
4. Set up the database (see [Database](#database)).
5. Build and run the project.

## Project Structure

DokanDar follows a modular project structure based on the four layers of Clean Architecture:

- **DokanDar.Domain:** Contains the core business logic, entities, and interfaces.
- **DokanDar.Application:** Implements application-specific business rules and logic.
- **DokanDar.Infrastructure:** Houses the data access layer using Entity Framework Core and ADO.NET.
- **DokanDar.API:** Contains the ASP.NET Core Web API controllers, authentication, and other web-related components.

Feel free to explore each module for more details.

## Configuration

DokanDar uses configuration files for managing settings. Update the `appsettings.json` file with your specific configurations.

## Database

DokanDar relies on SQL Server as its database. Ensure that you have a SQL Server instance set up and update the connection string in the `appsettings.json` file.

To apply database migrations, run the following commands:

```bash
dotnet ef database update or
update-database (package manager console)

