using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingPro.Models
{
    public class Document
    {
        public string FileId { get; set; }
        public string FileTitle { get; set; }
        public string CategoryId { get; set; }

        public IFormFile Content { get; set; }
    }
}
