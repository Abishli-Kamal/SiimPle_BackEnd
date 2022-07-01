using Microsoft.AspNetCore.Mvc;

namespace Siimple_Back__End.Areas.SiimpleAdmin.Controllers
{
    [Area("SiimpleAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
