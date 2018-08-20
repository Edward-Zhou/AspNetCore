using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro.Models
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderViewModelId { get; set; }
        public virtual OrderViewModel OrderViewModel { get; set; }

    }
}
