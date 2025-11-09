using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
