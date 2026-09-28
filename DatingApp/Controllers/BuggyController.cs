using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    public class BuggyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
