using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pizza:BaseEntity
    {

        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public int PizzeriaID { get; set; }
        public string PizzeriaName { get; set; }

    }
}
