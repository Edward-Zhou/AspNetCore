using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.Order
{
    public class Payments
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BillId { get; set; }
        public virtual Bills Bills { get; set; }
    }
}
