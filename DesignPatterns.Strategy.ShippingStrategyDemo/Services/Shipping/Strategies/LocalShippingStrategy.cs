namespace DesignPatterns.Strategy.ShippingStrategyDemo.Services.Shipping.Strategies;

public class LocalShippingStrategy : IShippingStrategy
{
    public string Name => "Local Shipping";

    public decimal CalculateCost(decimal orderTotal)
    {
        return 10.00m;
    }
}
