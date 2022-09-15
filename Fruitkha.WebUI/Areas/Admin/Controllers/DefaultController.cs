using Microsoft.AspNetCore.Mvc;

namespace Fruitkha.WebUI.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        [Area(nameof(Admin))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
