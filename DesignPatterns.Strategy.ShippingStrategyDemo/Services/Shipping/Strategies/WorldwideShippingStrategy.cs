namespace DesignPatterns.Strategy.ShippingStrategyDemo.Services.Shipping.Strategies;

public class WorldwideShippingStrategy : IShippingStrategy
{
    public string Name => "Worldwide Shipping";

    public decimal CalculateCost(decimal orderTotal)
    {
        return 50.00m;
    }
}
