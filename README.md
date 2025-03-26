# TodoCA

## Overview
TodoCA is a Clean Architecture-based ASP.NET Core Web API for managing todo items. It follows a layered structure with separate projects for API, Application, Infrastructure, and Domain.

## Solution Structure
The project is divided into the following layers:

- **API**: Entry point for the application, handles HTTP requests and responses.
- **Application**: Contains business logic and use cases.
- **Domain**: Defines entities and core domain logic.
- **Infrastructure**: Handles persistence, logging, and external integrations.

## Technologies Used
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express (Windows Authentication)
- Serilog for logging
- Clean Architecture principles

## Installation & Setup

1. **Clone the Repository**
   ```sh
   git clone https://github.com/yourusername/TodoCA.git
   cd TodoCA
   ```

2. **Configure the Database**
   - Open `appsettings.json` in the `API` project and set the correct connection string under `DefaultConnection`.
   - Run database migrations:
     ```sh
     dotnet ef migrations add InitialCreate -p Infrastructure -s API
     dotnet ef database update -p Infrastructure -s API
     ```

3. **Run the Application**
   ```sh
   dotnet run --project API
   ```

## API Endpoints

### Todo Items
| Method | Endpoint | Description |
|--------|---------|-------------|
| `POST` | `/api/todoitems` | Add a new todo item |
| `GET` | `/api/todoitems` | Get a list of all todo items |
| `GET` | `/api/todoitems/{id}` | Get a todo item by ID |
| `PUT` | `/api/todoitems/{id}` | Toggle completion status of a todo item |
| `DELETE` | `/api/todoitems/{id}` | Delete a todo item |

## Logging
The project uses **Serilog** to log application events. Logs are stored in a file specified in the `appsettings.json` file.

## Contributing
Feel free to submit issues and pull requests. Follow the Clean Architecture principles and coding standards when contributing.

## License
This project is licensed under the MIT License.

