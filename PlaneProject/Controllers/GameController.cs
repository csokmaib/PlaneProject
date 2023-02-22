using Microsoft.AspNetCore.Mvc;
using PlaneProject.Models;

namespace PlaneProject.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            Player player = new Player(true);
            //player.OpponentId = "2";
            //player.OwnPlanes = 





            return View("Index", player);
        }
    }
}
