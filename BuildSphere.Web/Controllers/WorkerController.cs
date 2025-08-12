using Microsoft.AspNetCore.Mvc;

namespace BuildSphere.Web.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
