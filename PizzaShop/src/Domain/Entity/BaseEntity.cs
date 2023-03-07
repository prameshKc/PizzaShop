using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class BaseEntity
    {
        public string Id { get; set; } = "0";
        public string Flag { get; set; }
        public string UserName { get; set; }
        public string CreatedBy { get; set; }
    }
}
