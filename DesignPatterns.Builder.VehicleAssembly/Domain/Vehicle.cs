namespace DesignPatterns.Builder.VehicleAssembly.Domain;

public sealed class Vehicle
{
    public string Type { get; }
    public string Frame { get; set; } = string.Empty;
    public string Engine { get; set; } = string.Empty;
    public int Wheels { get; set; }
    public int Doors { get; set; }

    public Vehicle(string type)
    {
        Type = type;
    }

    public void Show()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($" Vehicle Type : {Type}");
        Console.WriteLine($" Frame        : {Frame}");
        Console.WriteLine($" Engine       : {Engine}");
        Console.WriteLine($" Wheels       : {Wheels}");
        Console.WriteLine($" Doors        : {Doors}");
    }
}
