# Minimal API with SQLite

This is a .NET Minimal API project using SQLite as the database. The project uses Entity Framework Core (EF Core) for database management. The EF Core tools are provided via the .NET tool manifest.

## Prerequisites

Ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 8.0 or later)

## Setting Up the Project

### 1. Install .NET Local Tools (If not already installed)

This project includes a `.config/dotnet-tools.json` file, which contains the EF Core tools. Install them with:

```sh
# Restore .NET tools from the manifest
 dotnet tool restore
```

### 2. Configure SQLite Database

Ensure that the SQLite database file (ticket.db) is created during migrations.

## Entity Framework Core (EF Core) Commands

Use the following EF Core CLI commands via the locally installed tools.

### 1. Create a New Migration

```sh
dotnet ef migrations add <MigrationName>
```

This command generates migration files in the `Migrations` folder.

### 2. Apply Migrations to the Database

```sh
dotnet ef database update
```

This applies all pending migrations to the SQLite database.

### 3. Remove Last Migration (If Needed)

```sh
dotnet ef migrations remove
```

This removes the most recent migration if it hasn’t been applied yet.

### 4. View Current Migrations

```sh
dotnet ef migrations list
```

Lists all migrations applied to the database.

### 5. Drop the Database (Use with Caution)

```sh
dotnet ef database drop --force
```

This command will delete the database.

## Building the Project

To build the project, run:

```sh
dotnet build
```

This compiles the application and checks for errors.

## Running the API

To run the application, execute:

```sh
 dotnet run
```

The API should now be running at `http://localhost:5000` or as configured in `appsettings.json`.

## Running Unit Tests

If your project includes unit tests, you can run them using:

```sh
dotnet test
```

## Notes
- The SQLite database file is usually stored in `ticket.db` or as specified in the `ConnectionStrings` configuration.
- The API follows a minimal API architecture and can be extended with additional services and middleware.

## Additional Resources
- [Microsoft Docs: EF Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [Minimal APIs in .NET](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/)

---

Enjoy developing with .NET Minimal API and SQLite!
