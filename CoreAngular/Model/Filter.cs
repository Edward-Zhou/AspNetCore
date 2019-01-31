using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngular.Model
{
    public class Filter
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
    }

    public class FilterPagination
    {
        public Filter Filter { get; set; }

        public Pagination Pagination { get; set; }
    }
}
