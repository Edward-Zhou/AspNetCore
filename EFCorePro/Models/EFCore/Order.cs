using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.EFCore
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
    }
}
