using Microsoft.AspNetCore.Mvc;

namespace KawaAssignment.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
