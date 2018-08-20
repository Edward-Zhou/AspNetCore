using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingPro.Binders
{
    public class CustomBinder : ComplexTypeModelBinder
    {
        private readonly IDictionary<ModelMetadata, IModelBinder> _propertyBinders;
        public CustomBinder(IDictionary<ModelMetadata, IModelBinder> propertyBinders)
            : base(propertyBinders)
        {
            _propertyBinders = propertyBinders;
        }
        protected override Task BindProperty(ModelBindingContext bindingContext)
        {
            if (bindingContext.FieldName == "BinderValue")
            {
                bindingContext.Result = ModelBindingResult.Success("BinderValueTest");
                return Task.CompletedTask;
            }
            else
            {
                return base.BindProperty(bindingContext);
            }
        }
        protected override void SetProperty(ModelBindingContext bindingContext, string modelName, ModelMetadata propertyMetadata, ModelBindingResult result)
        {
            base.SetProperty(bindingContext, modelName, propertyMetadata, result);
        }
    }
}
