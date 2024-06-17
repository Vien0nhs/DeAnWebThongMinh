using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
#nullable disable
using DeAnWebThongMinh.Models;
public class AccountController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    private static List<User> users = new List<User>();
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        foreach (var user in users)
        {
            if (username == user.Username && password == user.Password)
            {
                _httpContextAccessor.HttpContext.Session.SetString("Username", username);
                return View("Index", "Home");
            }
            else
            {
                _httpContextAccessor.HttpContext.Session.Clear();
            }
        }
        var Admin = new User {Username = "Admin", Password = "1111", Role = "Admin" };
        users.Add(Admin);
        if (Admin.Username == "Admin" && Admin.Password == "1111")
        {
            _httpContextAccessor.HttpContext.Session.SetString("UserRole", Admin.Role);
            _httpContextAccessor.HttpContext.Session.SetString("Username", Admin.Username);

            return RedirectToAction("Index", "CRUD");
        }
        else
        {
            ViewBag.ErrorMessage = "Thông tin đăng nhập không hợp lệ.";
            return View();
        }
    }

    [HttpGet]
    public IActionResult Logout()
    {
        _httpContextAccessor.HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string email, string username, string password)
    {
        if (users.Exists(u => u.Email == email || u.Username == username))
        {
            ViewBag.ErrorMessage = "Email hoặc tài khoản đã tồn tại.";
            return View();
        }

        var newUser = new User { Email = email, Username = username, Password = password, Role = "User" };
        users.Add(newUser);

        // Lưu thông tin người dùng vào session sau khi đăng ký
        _httpContextAccessor.HttpContext.Session.SetString("UserRole", newUser.Role);
        _httpContextAccessor.HttpContext.Session.SetString("Username", newUser.Username);

        // Chuyển hướng đến trang chủ hoặc trang khác sau khi đăng ký thành công
        return RedirectToAction("Login", "Account");
    }

}
