using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email.Events
{
    public class CheckoutEvent
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
