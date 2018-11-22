using Microsoft.AspNetCore.Mvc.Filters;
using MVCPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
        public class FileDownloadCompleteActionFilter : ActionFilterAttribute
        {
            private readonly MVCProContext _context;
            public FileDownloadCompleteActionFilter(MVCProContext context)
            {
                _context = context;
            }
            public override void OnActionExecuted(ActionExecutedContext context)
            {
                base.OnActionExecuted(context);
                //called after executing the action
                _context.Language.Add(new Language {  LanguageName = "L1"});
                _context.SaveChanges();
            }
        }
}
