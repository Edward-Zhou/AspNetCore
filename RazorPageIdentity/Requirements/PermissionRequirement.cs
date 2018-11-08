using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageIdentity.Requirements
{
    public class PermissionRequirement
    {
    }

    public class ReadPermission : IAuthorizationRequirement
    {
        // Code omitted for brevity
    }
    public class EditPermission : IAuthorizationRequirement
    {
        // Code omitted for brevity
    }
    public class DeletePermission : IAuthorizationRequirement
    {
        // Code omitted for brevity
    }

}
