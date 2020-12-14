using Microsoft.AspNetCore.Mvc;

namespace NLayerProject.Web.Controllers
{
    //TODO:Kendin Yap
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}