using DesignPatterns.Strategy.ShippingStrategyDemo.Core.Dtos;

namespace DesignPatterns.Strategy.ShippingStrategyDemo.Models;

public class CheckoutViewModel
{
    public IEnumerable<ShippingOptionDto> ShippingMethods { get; set; } = [];
    public string SelectedMethod { get; set; } = string.Empty;
    public decimal OrderTotal { get; set; }
    public decimal FinalTotal { get; set; }
}
