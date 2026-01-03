using DesignPatterns.Strategy.ShippingStrategyDemo.Core.Dtos;

namespace DesignPatterns.Strategy.ShippingStrategyDemo.Core.Interfaces;

public interface IShippingService
{
    IEnumerable<ShippingOptionDto> GetShippingOptions();
    decimal CalculateShippingCost(decimal orderTotal, string shippingMethodName);
}
