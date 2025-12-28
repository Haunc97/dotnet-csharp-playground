using DesignPatterns.Builder.VehicleAssembly.Assembly;
using DesignPatterns.Builder.VehicleAssembly.Builders;

var assemblyLine = new VehicleAssemblyLine();

IVehicleBuilder builder;

builder = new ScooterBuilder();
assemblyLine.Assemble(builder).Show();

builder = new CarBuilder();
assemblyLine.Assemble(builder).Show();

builder = new MotorCycleBuilder();
assemblyLine.Assemble(builder).Show();

Console.ReadKey();