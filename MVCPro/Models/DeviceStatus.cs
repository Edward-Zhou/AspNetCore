using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Models
{
    public class DeviceStatus
    {
        public Guid DeviceId { get; set; }
        public string Status { get; set; }
    }
}
