using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PizzeriaUserLogin : BaseEntity
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public int PizzeriaID { get; set; }
    }
}
