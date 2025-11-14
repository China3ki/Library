using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Library.Components;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _client = factory.CreateClient("LibraryAPI");
        }

        public async Task<IActionResult> Index()
        {
            //List<BookModel> bookList = await GetBooks();
            return View();  
        }
  
        public IActionResult Logout()
        {
            Session.EndSession(HttpContext);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            bool success = await Auth.Register(_client, register);
            //if(!success) return

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            bool success = await Auth.Login(_client, login);
            //if (!success) 
            await Session.StartSession(_client, HttpContext, login.LoginEmail);
            return RedirectToAction("Index");
        }
    }
}
