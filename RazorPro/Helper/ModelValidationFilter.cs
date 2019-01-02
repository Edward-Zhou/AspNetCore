using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RazorPro.Helper
{
    public class ModelValidationFilter : IAsyncPageFilter
    {
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            if (context.HttpContext.Request.Method.Equals("POST") || context.HttpContext.Request.Method.Equals("PUT"))
            {
                if (!context.ModelState.IsValid)
                {
                    if (context.HttpContext.Request.IsAjaxRequest())
                    {
                        var errorModel = context.ModelState.Keys.Where(x => context.ModelState[x].Errors.Count > 0)
                            .Select(x => new
                            {
                                key = x,
                                errors = context.ModelState[x].Errors.Select(y => y.ErrorMessage).ToArray()
                            });

                        context.Result = new JsonResult(new AjaxResultHelper<IEnumerable<object>>
                        {
                            Response = errorModel,
                            Message = "_InvalidData_"
                        });
                    }
                    else
                    {
                        var result = await next();
                        
                        var provider = context.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();
                        var viewDataDictionaryModelType = context.ActionDescriptor.DeclaredModelTypeInfo ?? typeof(object);

                        //if (viewDataDictionaryModelType != null)
                        //{
                        //    Type _viewDataDictionaryType = typeof(ViewDataDictionary<>).MakeGenericType(viewDataDictionaryModelType);
                        //    _rootFactory = ViewDataDictionaryFactory.CreateFactory(viewDataDictionaryModelType.GetTypeInfo());
                        //    _nestedFactory = ViewDataDictionaryFactory.CreateNestedFactory(viewDataDictionaryModelType.GetTypeInfo());
                        //}

                        var factory = ViewDataDictionaryFactory.CreateFactory(viewDataDictionaryModelType.GetTypeInfo());
                        var _nestedFactory = ViewDataDictionaryFactory.CreateNestedFactory(viewDataDictionaryModelType.GetTypeInfo());

                        var viewData = factory(provider, context.ModelState);
                        var viewData2 = _nestedFactory(viewData);
                        var contentType = context.HttpContext.Request.ContentType;
                        
                        context.Result = new PageResult
                        {
                            ViewData = viewData,
                            ContentType = contentType,
                            StatusCode = 400,
                        };
                    }
                }
            }
            else
            {
                await next.Invoke();
            }
        }

        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            await Task.CompletedTask;
        }
    }

    internal class AjaxResultHelper<T>
    {
        public T Response { get; set; }
        public string Message { get; set; }
    }

    public static class Extension
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return true;
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
    }
}
