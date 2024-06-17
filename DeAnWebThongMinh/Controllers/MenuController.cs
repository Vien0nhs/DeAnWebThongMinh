using DeAnWebThongMinh.Data;
using DeAnWebThongMinh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace DeAnWebThongMinh.Controllers
{
    public class MenuController : Controller
    {
        private readonly ProductDbContext _context;
        private CartItemsController _cartItemsController;
		public MenuController(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> Detail(int id)
        {
            var p = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (p == null)
            {
                return NotFound();
            }
            var v = new Product
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                ProductPrice = p.ProductPrice,
                ImageUrl = p.ImageUrl,
                Quantity = 1
            };
			HttpContext.Session.SetString("LastViewedProduct", JsonConvert.SerializeObject(p));
			return View(v);
        }
        public IActionResult Cart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }
        [HttpPost]
        public IActionResult AddToCart(int id, int quantity)
        {

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            List<CartItem> cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    Quantity = quantity,
                    ImageUrl = product.ImageUrl
                });
            }

            
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == id);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Cart");
        }
    }
}

