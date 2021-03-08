using Dapr;
using Email.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Email.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [Topic("pubsub", "checkout")]
        public void CheckoutEventHandler(CheckoutEvent checkoutEvent)
        {
            Console.WriteLine("Event catched by Email service : " + JsonSerializer.Serialize(checkoutEvent));
        }
    }
}
