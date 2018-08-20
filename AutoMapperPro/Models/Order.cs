using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
