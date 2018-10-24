using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Areas.User
{
    [ViewComponent(Name = "UserShare")]
    public class ShareViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View<string>("User.ShareViewComponent");
        }
    }
}
