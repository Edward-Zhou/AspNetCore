using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    public class MVCModel
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ordered")]
        public decimal NoInvoAb { get; set; }
    }
}
