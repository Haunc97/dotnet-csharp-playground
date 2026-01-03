using DesignPatterns.Strategy.ShippingStrategyDemo.Core.Dtos;
using DesignPatterns.Strategy.ShippingStrategyDemo.Core.Interfaces;
using DesignPatterns.Strategy.ShippingStrategyDemo.Services.Shipping.Strategies;

namespace DesignPatterns.Strategy.ShippingStrategyDemo.Services.Shipping;

public class ShippingService(IEnumerable<IShippingStrategy> strategies) : IShippingService
{
    public IEnumerable<ShippingOptionDto> GetShippingOptions()
    {
        var options = new List<ShippingOptionDto>();
        int index = 1;
        foreach (var strategy in strategies)
        {
            options.Add(new ShippingOptionDto
            {
                Id = index++,
                Name = strategy.Name,
                Cost = strategy.CalculateCost(0)
            });
        }
        return options;
    }

    public decimal CalculateShippingCost(decimal orderTotal, string shippingMethodName)
    {
        var strategy = strategies.FirstOrDefault(s => s.Name == shippingMethodName);

        if (strategy == null)
        {
            throw new ArgumentException($"Invalid shipping method: {shippingMethodName}");
        }

        return strategy.CalculateCost(orderTotal);
    }
}
