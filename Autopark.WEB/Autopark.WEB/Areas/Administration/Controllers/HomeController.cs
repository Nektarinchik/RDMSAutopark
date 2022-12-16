using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autopark.WEB.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
