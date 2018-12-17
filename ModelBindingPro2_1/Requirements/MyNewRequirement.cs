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
    public class MyNewRequirement : AuthorizationHandler<MyRequirement>, IAuthorizationRequirement
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
        {
            var mvcContext = context.Resource as AuthorizationFilterContext;
            //required service
            var _mvcOptions = mvcContext.HttpContext.RequestServices.GetRequiredService<IOptions<MvcOptions>>().Value;
            var parameterBinder = mvcContext.HttpContext.RequestServices.GetRequiredService<ParameterBinder>();
            var _modelBinderFactory = mvcContext.HttpContext.RequestServices.GetRequiredService<IModelBinderFactory>();
            var _modelMetadataProvider = mvcContext.HttpContext.RequestServices.GetRequiredService<IModelMetadataProvider>();

            var controllerContext = new ControllerContext(mvcContext);
            controllerContext.ValueProviderFactories = new CopyOnWriteList<IValueProviderFactory>(_mvcOptions.ValueProviderFactories.ToArray());
            var valueProvider = await CompositeValueProvider.CreateAsync(controllerContext);
            var parameters = controllerContext.ActionDescriptor.Parameters;
            var parameterBindingInfo = GetParameterBindingInfo(
                            _modelBinderFactory,
                            _modelMetadataProvider,
                            controllerContext.ActionDescriptor,
                            _mvcOptions);

            for (var i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters[i];
                var bindingInfo = parameterBindingInfo[i];
                var modelMetadata = bindingInfo.ModelMetadata;

                if (!modelMetadata.IsBindingAllowed)
                {
                    continue;
                }

                var model = await parameterBinder.BindModelAsync(
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
