using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbInMemoryPro.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int PId { get; set; }
        public int SId { get; set; }
    }
}
