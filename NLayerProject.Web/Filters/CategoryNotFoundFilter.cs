using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.Core.Service;
using NLayerProject.Web.DTOs;

namespace NLayerProject.Web.Filters
{
    public class CategoryNotFoundFilter : ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public CategoryNotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int) context.ActionArguments.Values.FirstOrDefault();
            var product = await _categoryService.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                var errorDto = new ErrorDto();
                errorDto.Errors.Add($"Id'si {id} olan kategori bulunamadı!");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}