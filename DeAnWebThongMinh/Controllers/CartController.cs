using Microsoft.AspNetCore.Mvc;

namespace DeAnWebThongMinh.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
