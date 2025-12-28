using DesignPatterns.Builder.VehicleAssembly.Builders;
using DesignPatterns.Builder.VehicleAssembly.Domain;

namespace DesignPatterns.Builder.VehicleAssembly.Assembly;

public sealed class VehicleAssemblyLine
{
    public Vehicle Assemble(IVehicleBuilder builder)
    {
        builder.BuildFrame();
        builder.BuildEngine();
        builder.BuildWheels();
        builder.BuildDoors();

        return builder.Vehicle;
    }
}
