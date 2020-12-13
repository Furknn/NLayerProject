using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;

namespace NLayerProject.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            var errorDto = new ErrorDto {Status = 400};

            var modelErrors = context.ModelState.Values.SelectMany(v => v.Errors);

            modelErrors.ToList().ForEach(x => { errorDto.Errors.Add(x.ErrorMessage); });
            context.Result = new BadRequestObjectResult(errorDto);
        }
    }
}