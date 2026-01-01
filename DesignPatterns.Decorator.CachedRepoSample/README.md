# Decorator Design Pattern Sample

This project demonstrates the **Decorator Design Pattern** in .NET 10 using the Repository pattern. It showcases how to extend the functionality of a repository (e.g., adding caching and logging) without modifying the original implementation.

## Features

- **Core Functionality**: `AuthorRepository` handles standard Entity Framework Core data access.
- **Caching**: `AuthorRepositoryCachingDecorator` adds in-memory caching using `IMemoryCache`.
- **Logging**: `AuthorRepositoryLoggingDecorator` adds logging with `Serilog`, properly handling structured logging.
- **Composition**: Demonstrates how to manually chain decorators to layer behaviors.

## Project Structure

- **Data/Repositories**:
  - `IReadOnlyRepository<T>`: The common interface for repositories and decorators.
  - `AuthorRepository`: The concrete component.
  - `AuthorRepositoryCachingDecorator`: The caching decorator.
  - `AuthorRepositoryLoggingDecorator`: The logging decorator.
- **Program.cs**: Configures the dependency injection container to chain these services.

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server (LocalDB or full instance)

### Configuration

Ensure your `appsettings.json` has a valid connection string:

```json
"ConnectionStrings": {
  "AppDbContextConnection": "Server=(localdb)\\mssqllocaldb;Database=DecoratorSample;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### Running the Application

1.  Navigate to the project directory.
2.  Run the application:
    ```bash
    dotnet run
    ```

The application will seed the database if emptiness is detected (ensure you have the migration applied or auto-migration logic if present).

## Usage

In `Program.cs`, the decorators are chained as follows:

```csharp
builder.Services.AddScoped(serviceProvider =>
{
    var memoryCache = serviceProvider.GetService<IMemoryCache>();
    var logger = serviceProvider.GetService<ILogger<AuthorRepositoryLoggingDecorator>>();
    var authorRepository = serviceProvider.GetRequiredService<AuthorRepository>();

    // Wrap the repository with caching
    IReadOnlyRepository<Author> cachingDecorator = new AuthorRepositoryCachingDecorator(authorRepository, memoryCache!);

    // Wrap the cached repository with logging
    IReadOnlyRepository<Author> loggingDecorator = new AuthorRepositoryLoggingDecorator(cachingDecorator, logger!);

    return loggingDecorator;
});
```

This ensures that every call goes through:
`Logging` -> `Caching` -> `Original Repository`

## Alternative Approach using Scrutor

An alternative way to register decorators using the [Scrutor](https://github.com/khellang/Scrutor) library is also included in the comments of `Program.cs` for reference.
