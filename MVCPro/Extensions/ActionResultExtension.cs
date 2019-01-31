using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;
using MVCPro.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Extensions
{
    public static class ActionResultExtension
    {
        //public static IActionResult WithTitle(this PartialViewResult result, string modalTitle)
        //{
        //    result.ViewData["Title"] = modalTitle;
        //    return result;
        //}

        public static IActionResult WithTitle(this IActionResult action, string modalTitle)
        {
            return new ModalTitleDecorator(action, modalTitle);
        }
    }

    public class ModalTitleDecorator : PartialViewResult
    {
        private readonly IActionResult _actionResult;
        private readonly string _modalTitle;

        public ModalTitleDecorator(IActionResult action, string modalTitle)
        {
            _actionResult = action;
            _modalTitle = modalTitle;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            ViewDataDictionary viewData = _actionResult
                                        .GetType()
                                        .GetProperty("ViewData")
                                        .GetValue(_actionResult) as ViewDataDictionary;
            if (viewData != null)
            {
                viewData["Title"] = _modalTitle;
            }
            await _actionResult.ExecuteResultAsync(context);
        }
    }
}
