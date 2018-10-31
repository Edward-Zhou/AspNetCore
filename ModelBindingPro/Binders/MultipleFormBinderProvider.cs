using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingPro.Binders
{
    public class MultipleFormBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType)
            {
                var propertyBinders = new Dictionary<ModelMetadata, IModelBinder>();
                for (var i = 0; i < context.Metadata.Properties.Count; i++)
                {
                    var property = context.Metadata.Properties[i];
                    propertyBinders.Add(property, context.CreateBinder(property));
                }

                //var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
                //return new ComplexTypeModelBinder(propertyBinders, loggerFactory);
                return new CustomBinder(propertyBinders);
            }

            return null;
        }

    }
}
