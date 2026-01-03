# ShippingStrategyDemo

A modern ASP.NET Core application demonstrating the **Strategy Design Pattern** for shipping cost calculations.

This project serves as a reference implementation for clean code practices in .NET 10, showing how to decouple business algorithm selection from the consuming logic using Dependency Injection.

## Features

*   **Framework**: .NET 10.0
*   **Language**: C# 14 (Primary Constructors, File-scoped namespaces, Global Usings)
*   **Architecture**:
    *   **Core**: Interfaces and DTOs (Pure Domain).
    *   **Services**: Business logic including the Strategy implementations.
    *   **Web**: UI and Controller logic.
*   **Pattern**: **Strategy Pattern** applied to shipping rates (Free, Local, Worldwide).

## Getting Started

### Prerequisites

*   [.NET 10.0 SDK](https://dotnet.microsoft.com/download)

### Running the Application

1.  Clone the repository and navigate to the project folder:
    ```powershell
    cd ShippingStrategyDemo
    ```

2.  Run the application:
    ```powershell
    dotnet run
    ```

3.  Open your browser to `http://localhost:5000` (or the port shown in the console).

## Project Structure

*   **/Core**
    *   `Interfaces/IShippingService.cs`: Contract for the main service.
    *   `Dtos/ShippingOptionDto.cs`: Data transfer object for UI display.
*   **/Services**
    *   `Shipping/ShippingService.cs`: The Context context/service that executes the strategies.
    *   `Shipping/Strategies/`: Concrete implementations (`Free`, `Local`, `Worldwide`).
*   **/Controllers**
    *   `HomeController.cs`: Coordinates the View and the Service using Primary Constructors.

## How it Works

The `ShippingService` is injected with all available `IShippingStrategy` implementations. When a user selects a shipping method, the service selects the matching strategy by name and executes the cost calculation logic.

```csharp
// Example usage in ShippingService
public decimal CalculateShippingCost(decimal orderTotal, string shippingMethodName)
{
    var strategy = strategies.FirstOrDefault(s => s.Name == shippingMethodName);
    return strategy.CalculateCost(orderTotal);
}
```
