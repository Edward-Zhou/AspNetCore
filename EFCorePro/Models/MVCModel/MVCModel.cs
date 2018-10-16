using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCorePro.Models.MVCModel
{
    public class MVCModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ordered")]
        public decimal NoInvoAb { get; set; }

        [Display(Name = "Created on")]
        [UIHint("DateDisabled")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime? CreationDate { get; set; }

    }
}
