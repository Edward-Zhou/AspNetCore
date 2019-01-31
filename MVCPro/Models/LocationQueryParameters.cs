using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    public class LocationQueryParameters
    {
        [FromQuery(Name = "category")]
        [BindRequired]
        public string Category { get; set; }

        [FromQuery(Name = "itemsCount")]
        [BindRequired]
        [Range(1, 999)]
        public int ItemsCount { get; set; }
    }
}
