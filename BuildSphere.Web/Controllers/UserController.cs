using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using BuildSphere.Web.Adapters;
using BuildSphere.Common.Requests;
using BuildSphere.Common.Adaptors;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;

namespace BuildSphere.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly AuthAdapter _authClient;

        public UserController(AuthAdapter apiClient)
            => _authClient = apiClient;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await _authClient.Login(new LoginRequest { UserName = userName, Password = password });
            var token = result?.Data;
            if (token == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View();
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims.ToList();
            claims.Add(new Claim("AccessToken", token));

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principal);
            _authClient.SetAuthToken(token);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Signup()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            _authClient.ClearAuthToken();
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login", "User");
        }
    }
}
