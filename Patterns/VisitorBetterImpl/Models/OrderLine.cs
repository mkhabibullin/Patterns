using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorBetterImpl.Models
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
