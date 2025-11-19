using Library.Components;
using Library.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public CategoriesController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _client = factory.CreateClient("LibraryAPI");
        }
        public async Task<IActionResult> Index(int? page)
        {
            if (!Auth.CheckAdmin(HttpContext)) return RedirectToAction("Index", "Home");
            CategoriesModel model = await ViewCreator.GetCategoriesModel(_client, page);
            return View(model);
        }
    }
}
