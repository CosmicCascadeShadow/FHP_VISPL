using Microsoft.AspNetCore.Mvc;

namespace FHP_web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
