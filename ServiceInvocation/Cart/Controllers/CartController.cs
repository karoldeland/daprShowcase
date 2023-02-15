using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Controllers
{
    [Route("{controller}/{action}")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ILogger<CartController> Logger { get; }

        public CartController([FromServices] ILogger<CartController> logger)
        {
            Logger = logger;
        }

        public async Task Add([FromBody]string productName) => await Task.Run(() => Logger.LogInformation(productName));

    }
}
