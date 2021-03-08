using Dapr.Client;
using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Fake product list 
        private readonly Product[] _products = new Product[]
            {
                new Product() { Name="Toilet paper", Description="Very rare in Covid-19 time. Must have product!"},
                new Product() { Name="Treated wood", Description="Very rare in Covid-19 time. For better outdooring lifestyle."},
                new Product() { Name="Dapr hat", Description="If you're lucky, wear this beautiful hat and answer everyone asking you : What's Dapr?"},
                new Product() { Name="Dapr shirt", Description="If you're lucky, wear this beautiful T-Shirt."}
            };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = new ProductsVM() { Products = _products };
            return View(vm);
        }

        [Route("{controller}/{action}/{productName}")]
        public async Task<IActionResult> AddToCart(string productName, 
                                                   [FromServices] DaprClient daprClient)
        {
            await daprClient.InvokeMethodAsync("cart", "Cart", productName);            

            var vm = new ProductsVM() { Products = _products, Message = @$"{productName} added." };

            return View("Index", vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
