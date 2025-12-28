using DesignPatterns.Builder.VehicleAssembly.Domain;

namespace DesignPatterns.Builder.VehicleAssembly.Builders;

public abstract class VehicleBuilder : IVehicleBuilder
{
    public Vehicle Vehicle { get; }

    protected VehicleBuilder(string type)
    {
        Vehicle = new Vehicle(type);
    }

    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();
}