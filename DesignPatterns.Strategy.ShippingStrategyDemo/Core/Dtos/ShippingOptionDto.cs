namespace DesignPatterns.Strategy.ShippingStrategyDemo.Core.Dtos;

public class ShippingOptionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}
