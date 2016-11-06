using Microsoft.AspNetCore.Mvc;

namespace typescript_react_server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
