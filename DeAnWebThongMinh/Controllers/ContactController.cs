using Microsoft.AspNetCore.Mvc;

namespace DeAnWebThongMinh.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
