using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
