using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingPro2_1.Models
{
    public class MemberViewModel
    {
        public string Member_NameFirst { get; set; }
        public string Member_NameLast { get; set; }

        public byte[] Member_Picture { get; set; }
        public IFormFile Member_UploadPicture { get; set; }
        public string Member_Picture_Show { get; set; }
    }
}
