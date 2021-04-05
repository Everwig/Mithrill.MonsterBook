using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Mithrill.MonsterBook.WebApi.Controllers.Common
{
    public class NotFoundResultFilterConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if(IsApiController(controller))
                controller.Filters.Add(new NotFoundResultFilterAttribute());
        }

        private static bool IsApiController(ControllerModel controller)
        {
            return controller.Attributes.OfType<IApiBehaviorMetadata>().Any()
                   || controller.ControllerType.Assembly.GetCustomAttributes().OfType<IApiBehaviorMetadata>().Any();
        }
    }

    public class NotFoundResultFilterAttribute : Attribute, IAlwaysRunResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if(context.Result is ObjectResult objectResult && objectResult.Value == null)
                context.Result = new NotFoundResult();
        }
    }
}