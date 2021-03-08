using Dapr.Client;
using Email.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpGet]
        [Route("{productName}")]
        public async Task AddToCart(string productName, [FromServices] DaprClient daprClient)
        {
            var checkoutEvent = new CheckoutEvent() { ProductName = productName, Quantity = 1 };

            await daprClient.PublishEventAsync("pubsub", "checkout", checkoutEvent);

            Console.WriteLine($"Message sent with payload : {JsonSerializer.Serialize(checkoutEvent)}");
        }
    }
}
