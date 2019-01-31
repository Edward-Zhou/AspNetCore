using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    [DataContract]
    public class MyDTO
    {
        [DataMember(IsRequired = true)]
        public string MyProperty { get; set; }
    }
}
