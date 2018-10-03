using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPro.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Attributes { get; set; }
    }
    public class CustomerVM: Customer
    {
        public string Year { get; set; }
    }
}
