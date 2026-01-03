namespace DesignPatterns.Strategy.ShippingStrategyDemo.Services.Shipping.Strategies;

public interface IShippingStrategy
{
    string Name { get; }
    decimal CalculateCost(decimal orderTotal);
}