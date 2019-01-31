using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperPro.Models.AccountSubscription
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }
    public class AccountSubscription : BaseEntity
    {
        [Required]
        public int CustomerNumber { get; set; }

        [Required]
        public long AccountNumber { get; set; }
    }
    public class BaseDto
    {
        public int Id { get; set; }
    }
    public class AccountSubscriptionDto : BaseDto
    {
        [Required]
        public int CustomerNumber { get; set; }

        [Required]
        public IList<long> AccountList { get; set; }

    }
}
