namespace DesignPatterns.Builder.VehicleAssembly.Builders;

public sealed class ScooterBuilder : VehicleBuilder
{
    public ScooterBuilder() : base("Scooter") { }

    public override void BuildFrame() => Vehicle.Frame = "Scooter Frame";
    public override void BuildEngine() => Vehicle.Engine = "50 cc";
    public override void BuildWheels() => Vehicle.Wheels = 2;
    public override void BuildDoors() => Vehicle.Doors = 0;
}
