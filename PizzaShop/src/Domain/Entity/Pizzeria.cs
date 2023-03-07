using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pizzeria:BaseEntity
    {
        public int PizzeriaID { get; set; }
        public string PizzeriaName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
    }
}
