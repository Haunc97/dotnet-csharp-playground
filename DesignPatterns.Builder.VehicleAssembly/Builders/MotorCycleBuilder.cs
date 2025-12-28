namespace DesignPatterns.Builder.VehicleAssembly.Builders;

public sealed class MotorCycleBuilder : VehicleBuilder
{
    public MotorCycleBuilder() : base("Motorcycle") { }

    public override void BuildFrame() => Vehicle.Frame = "Motorcycle Frame";
    public override void BuildEngine() => Vehicle.Engine = "500 cc";
    public override void BuildWheels() => Vehicle.Wheels = 2;
    public override void BuildDoors() => Vehicle.Doors = 0;
}
