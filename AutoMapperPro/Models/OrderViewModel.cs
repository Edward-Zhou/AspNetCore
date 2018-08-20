using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrderItemViewModel> OrderItemViewModel { get; set; }

    }
}
