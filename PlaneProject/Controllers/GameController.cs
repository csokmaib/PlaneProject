using Microsoft.AspNetCore.Mvc;

namespace PlaneProject.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
