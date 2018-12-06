using MVCPro.Validation;
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

        [Display(Name = "Created on")]
        [UIHint("DateDisabled")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd.MM.yyyy}")]
        //[DataType(DataType.DateTime)]
        public DateTime? CreationDate { get; set; }
        public MVCSubModel MVCSubModel { get; set; }
        public Gender Gender { get; set; }
        [AmountShouldBeLessOrEqual(nameof(MaxAmount), ErrorMessage = "Your amount should be less than {0}")]
        public decimal Amount { get; set; }
        public decimal MaxAmount { get; set; }

    }
    public class MVCSubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
