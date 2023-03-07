using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PizzaOrderItem
    {
        public int OrderItemID { get; set; }
        public int PizzaID { get; set; }
        public int OrderID { get; set; }
        public string Toppings { get; set; }
        public decimal Price { get; set; }
    }
}
