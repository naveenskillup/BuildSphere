using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Web.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
