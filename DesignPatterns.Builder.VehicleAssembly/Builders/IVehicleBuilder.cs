using DesignPatterns.Builder.VehicleAssembly.Domain;

namespace DesignPatterns.Builder.VehicleAssembly.Builders;

public interface IVehicleBuilder
{
    Vehicle Vehicle { get; }

    void BuildFrame();
    void BuildEngine();
    void BuildWheels();
    void BuildDoors();
}
