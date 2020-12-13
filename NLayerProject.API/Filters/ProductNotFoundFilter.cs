using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Service;

namespace NLayerProject.API.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int) context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                var errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"Id'si {id} olan ürün bulunamadı!");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}