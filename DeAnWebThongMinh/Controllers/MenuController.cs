using DeAnWebThongMinh.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeAnWebThongMinh.Controllers
{
    public class MenuController : Controller
    {
		private readonly ProductDbContext _context;

		public MenuController(ProductDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.Products.ToListAsync());
		}
	}
}
