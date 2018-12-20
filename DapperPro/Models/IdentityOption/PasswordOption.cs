using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPro.Models.IdentityOption
{
    public class PasswordOption
    {
        //
        // Summary:
        //     Gets or sets the minimum length a password must be.
        //
        // Remarks:
        //     This defaults to 6.
        public int RequiredLength { get; set; }
        //
        // Summary:
        //     Gets or sets the minimum number of unique chars a password must comprised of.
        //
        // Remarks:
        //     This defaults to 1.
        public int RequiredUniqueChars { get; set; }
        //
        // Summary:
        //     Gets or sets a flag indicating if passwords must contain a non-alphanumeric character.
        //
        // Remarks:
        //     This defaults to true.
        public bool RequireNonAlphanumeric { get; set; }
        //
        // Summary:
        //     Gets or sets a flag indicating if passwords must contain a lower case ASCII character.
        //
        // Remarks:
        //     This defaults to true.
        public bool RequireLowercase { get; set; }
        //
        // Summary:
        //     Gets or sets a flag indicating if passwords must contain a upper case ASCII character.
        //
        // Remarks:
        //     This defaults to true.
        public bool RequireUppercase { get; set; }
        //
        // Summary:
        //     Gets or sets a flag indicating if passwords must contain a digit.
        //
        // Remarks:
        //     This defaults to true.
        public bool RequireDigit { get; set; }

    }
}
