namespace DesignPatterns.Strategy.ShippingStrategyDemo.Services.Shipping.Strategies;

public class FreeShippingStrategy : IShippingStrategy
{
    public string Name => "Free Shipping";

    public decimal CalculateCost(decimal orderTotal)
    {
        return 0m;
    }
}
