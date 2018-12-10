using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingPro.Binders
{
    public class CustomDictionaryModelBinderProvider: IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var modelType = context.Metadata.ModelType;
            var dictionaryType = ClosedGenericMatcher.ExtractGenericInterface(modelType, typeof(IDictionary<,>));
            if (dictionaryType != null)
            {
                var keyType = dictionaryType.GenericTypeArguments[0];
                var keyBinder = context.CreateBinder(context.MetadataProvider.GetMetadataForType(keyType));

                var valueType = dictionaryType.GenericTypeArguments[1];
                var valueBinder = context.CreateBinder(context.MetadataProvider.GetMetadataForType(valueType));

                var binderType = typeof(CustomDictionaryModelBinder<,>).MakeGenericType(dictionaryType.GenericTypeArguments);
                var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
                return (IModelBinder)Activator.CreateInstance(binderType, keyBinder, valueBinder, loggerFactory);
            }

            return null;
        }

    }
}
