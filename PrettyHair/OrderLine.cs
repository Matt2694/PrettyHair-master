using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PrettyHair
{
    public class OrderLine
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public OrderLine() { }

        public OrderLine(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
