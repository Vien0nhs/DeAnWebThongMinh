using DeAnWebThongMinh.Data;
using DeAnWebThongMinh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DeAnWebThongMinh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _context;
        public HomeController(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var list  = await _context.Products.ToListAsync();

			Product? lastViewedProduct = null;
			var lastViewedProductJson = HttpContext.Session.GetString("LastViewedProduct");
			if (!string.IsNullOrEmpty(lastViewedProductJson))
			{
				var deserializedProduct = JsonConvert.DeserializeObject<Product>(lastViewedProductJson);
				if (deserializedProduct != null)
				{
					lastViewedProduct = deserializedProduct;
				}
				else
				{
					lastViewedProduct = new Product();
				}
			}
			ViewBag.LastViewedProduct = lastViewedProduct;
			return View(list);
        }
    }
}
