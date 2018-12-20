using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPro.Models.IdentityOption
{
    public class LockoutOption
    {
        public int Id { get; set; }
        //
        // Remarks:
        //     Defaults to true.
        public bool AllowedForNewUsers { get; set; }
        //
        // Summary:
        //     Gets or sets the number of failed access attempts allowed before a user is locked
        //     out, assuming lock out is enabled.
        //
        // Remarks:
        //     Defaults to 5 failed attempts before an account is locked out.
        public int MaxFailedAccessAttempts { get; set; }
        //
        // Summary:
        //     Gets or sets the System.TimeSpan a user is locked out for when a lockout occurs.
        //
        // Remarks:
        //     Defaults to 5 minutes.
        public TimeSpan DefaultLockoutTimeSpan { get; set; }
    }
}
