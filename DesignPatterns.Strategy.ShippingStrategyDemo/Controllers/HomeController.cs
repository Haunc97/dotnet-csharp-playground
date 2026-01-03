using DesignPatterns.Strategy.ShippingStrategyDemo.Core.Interfaces;
using DesignPatterns.Strategy.ShippingStrategyDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Strategy.ShippingStrategyDemo.Controllers;

public class HomeController(IShippingService shippingService) : Controller
{

    public IActionResult Index()
    {
        var model = GetOrderDetails();
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(CheckoutViewModel model)
    {
        // Re-populate options for the view
        model.ShippingMethods = shippingService.GetShippingOptions();

        try
        {
            // Calculate cost using the service
            var shippingCost = shippingService.CalculateShippingCost(model.OrderTotal, model.SelectedMethod);
            model.FinalTotal = model.OrderTotal + shippingCost;
        }
        catch
        {
            // Should handle invalid selection gracefully, maybe add model error
            // For now, consistent with previous behavior of ignoring/defaulting
        }

        return View(model);
    }

    private CheckoutViewModel GetOrderDetails()
    {
        var model = new CheckoutViewModel()
        {
            OrderTotal = 100.00m,
            ShippingMethods = shippingService.GetShippingOptions()
        };
        return model;
    }
}
