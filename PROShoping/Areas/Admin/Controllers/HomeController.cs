using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PROShoping.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin,Data Entry")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
