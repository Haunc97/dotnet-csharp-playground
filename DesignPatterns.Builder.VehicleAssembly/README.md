# Vehicle Assembly Builder Pattern Demo

This project demonstrates the Builder design pattern in C# for assembling different types of vehicles (Car, MotorCycle, Scooter) with varying specifications.

## Overview
The Builder pattern separates the construction of a complex object from its representation, allowing the same construction process to create different representations.

## Structure
- **Domain**
  - `Vehicle.cs`: Represents the vehicle product.
- **Builders**
  - `IVehicleBuilder.cs`: Interface for vehicle builders.
  - `CarBuilder.cs`, `MotorCycleBuilder.cs`, `ScooterBuilder.cs`: Concrete builders for each vehicle type.
  - `VehicleBuilder.cs`: Base class for common builder logic.
- **Assembly**
  - `VehicleAssemblyLine.cs`: Director class that assembles vehicles using a builder.
- **Program.cs**
  - Entry point demonstrating how to use the builders and assembly line.

## Usage
1. Choose a builder (e.g., `CarBuilder`).
2. Pass the builder to `VehicleAssemblyLine`.
3. Call assembly methods to construct the vehicle.
4. Retrieve the assembled vehicle from the builder.

## Example
```csharp
var builder = new CarBuilder();
var assemblyLine = new VehicleAssemblyLine(builder);
assemblyLine.Assemble();
var car = builder.GetVehicle();
```

## Pattern Benefits
- Encapsulates construction logic.
- Supports different representations (Car, MotorCycle, Scooter).
- Promotes code reuse and separation of concerns.

## References
- [Builder Pattern - Refactoring Guru](https://refactoring.guru/design-patterns/builder)
