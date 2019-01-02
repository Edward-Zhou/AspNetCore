using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    public class Shortcode
    {
        public string Tag { get; set; }   
        public string Content { get; set; }  

        public IList<Shortcode> Children { get; set; }
    }
}
