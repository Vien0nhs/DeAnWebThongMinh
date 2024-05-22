using Microsoft.AspNetCore.Mvc;

namespace DeAnWebThongMinh.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
