using Microsoft.AspNetCore.Mvc;

namespace DeAnWebThongMinh.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
