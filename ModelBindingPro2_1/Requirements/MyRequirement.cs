using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ModelBindingPro2_1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingPro2_1.Requirements
{
    public class MyRequirement : AuthorizationHandler<MyRequirement>, IAuthorizationRequirement
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
        {
            var mvcContext = context.Resource as AuthorizationFilterContext;
            var _modelBinderFactory = mvcContext.HttpContext.RequestServices.GetRequiredService<IModelBinderFactory>();
            var _modelMetadataProvider = mvcContext.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();
            var _mvcOptions = mvcContext.HttpContext.RequestServices.GetRequiredService<IOptions<MvcOptions>>().Value;

            //var parameters =
            //              mvcContext
            //                .ActionDescriptor
            //                .Parameters
            //                .Select(s => new
            //                {
            //                    Name = s.Name,
            //                    Value = mvcContext.HttpContext.Request.Query[s.Name]
            //                });

            //object Result = Activator.CreateInstance(typeof(List<MembershipType>));

            //Result.GetType().GetMethod("Add").Invoke(Result, new object[] { MembershipType.Admin });
            ////// TODO: need access to query parameters here
            var controllerContext = new ControllerContext(mvcContext);
            
            var controllerActionInvokerCache = mvcContext.HttpContext.RequestServices.GetRequiredService<ControllerActionInvokerCache>();
            var cacheResult = controllerActionInvokerCache.GetCachedResult(controllerContext);
            var controller = cacheResult.cacheEntry.ControllerFactory.Invoke(controllerContext) as Controller;
            var model = new List<MembershipType>();
            await controller.TryUpdateModelAsync(model);

            
            var parameterBinder = mvcContext.HttpContext.RequestServices.GetRequiredService<ParameterBinder>();

            //var rr = await parameterBinder.BindModelAsync(
            //                    controllerContext,
            //                    controllerContext.,
            //                    valueProvider,
            //                    parameter,
            //                    modelMetadata,
            //                    value: null);

            //var parameters = controllerContext.ActionDescriptor.Parameters;

            //for (var i = 0; i < parameters.Count; i++)
            //{
            //    var parameter = parameters[i];
            //    var bindingInfo = parameterBindingInfo[i];
            //    var modelMetadata = bindingInfo.ModelMetadata;

            //    if (!modelMetadata.IsBindingAllowed)
            //    {
            //        continue;
            //    }

            //    var result = await parameterBinder.BindModelAsync(
            //        controllerContext,
            //        bindingInfo.ModelBinder,
            //        valueProvider,
            //        parameter,
            //        modelMetadata,
            //        value: null);

            //    if (result.IsModelSet)
            //    {
            //        arguments[parameter.Name] = result.Model;
            //    }
            //}


            //var propertyBinderFactory = ControllerBinderDelegateProvider.CreateBinderDelegate(
            //                     parameterBinder,
            //                     _modelBinderFactory,
            //                     _modelMetadataProvider,
            //                     controllerContext.ActionDescriptor,
            //                     _mvcOptions);
            var parameterBindingInfo = GetParameterBindingInfo(
                                        _modelBinderFactory,
                                        _modelMetadataProvider,
                                        controllerContext.ActionDescriptor,
                                        _mvcOptions);
            controllerContext.ValueProviderFactories = new CopyOnWriteList<IValueProviderFactory>(_mvcOptions.ValueProviderFactories.ToArray());

            var valueProvider = await CompositeValueProvider.CreateAsync(controllerContext);
            var parameters = controllerContext.ActionDescriptor.Parameters;





            for (var i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters[i];
                var bindingInfo = parameterBindingInfo[i];
                var modelMetadata = bindingInfo.ModelMetadata;

                if (!modelMetadata.IsBindingAllowed)
                {
                    continue;
                }

                var rr = await parameterBinder.BindModelAsync(
                    controllerContext,
                    bindingInfo.ModelBinder,
                    valueProvider,
                    parameter,
                    modelMetadata,
                    value: null);

            }
        }
        private static BinderItem[] GetParameterBindingInfo(
            IModelBinderFactory modelBinderFactory,
            IModelMetadataProvider modelMetadataProvider,
            ControllerActionDescriptor actionDescriptor,
            MvcOptions mvcOptions)
            {
                var parameters = actionDescriptor.Parameters;
                if (parameters.Count == 0)
                {
                    return null;
                }

                var parameterBindingInfo = new BinderItem[parameters.Count];
                for (var i = 0; i < parameters.Count; i++)
                {
                    var parameter = parameters[i];

                    ModelMetadata metadata;
                    if (mvcOptions.AllowValidatingTopLevelNodes &&
                        modelMetadataProvider is ModelMetadataProvider modelMetadataProviderBase &&
                        parameter is ControllerParameterDescriptor controllerParameterDescriptor)
                    {
                        // The default model metadata provider derives from ModelMetadataProvider
                        // and can therefore supply information about attributes applied to parameters.
                        metadata = modelMetadataProviderBase.GetMetadataForParameter(controllerParameterDescriptor.ParameterInfo);
                    }
                    else
                    {
                        // For backward compatibility, if there's a custom model metadata provider that
                        // only implements the older IModelMetadataProvider interface, access the more
                        // limited metadata information it supplies. In this scenario, validation attributes
                        // are not supported on parameters.
                        metadata = modelMetadataProvider.GetMetadataForType(parameter.ParameterType);
                    }

                    var binder = modelBinderFactory.CreateBinder(new ModelBinderFactoryContext
                    {
                        BindingInfo = parameter.BindingInfo,
                        Metadata = metadata,
                        CacheToken = parameter,
                    });

                    parameterBindingInfo[i] = new BinderItem(binder, metadata);
                }

                return parameterBindingInfo;
            }
        private struct BinderItem
        {
            public BinderItem(IModelBinder modelBinder, ModelMetadata modelMetadata)
            {
                ModelBinder = modelBinder;
                ModelMetadata = modelMetadata;
            }

            public IModelBinder ModelBinder { get; }

            public ModelMetadata ModelMetadata { get; }
        }

    }
}
