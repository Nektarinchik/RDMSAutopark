using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autopark.WEB.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "admin, employee")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
