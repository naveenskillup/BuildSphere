using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if ("Naveen".Equals(userName, StringComparison.OrdinalIgnoreCase) && password.Equals("12"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Error = "Incorrect username and password";

            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login", "User");
        }
    }
}
