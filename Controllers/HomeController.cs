using System.Diagnostics;
using System.Text.Json;
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
            List<BookModel> bookList = await GetBooks();
            return View(bookList);  
        }
        private async Task<List<BookModel>> GetBooks()
        {
            var fetch = await _client.GetAsync("/api/books?limit=2");

            if (!fetch.IsSuccessStatusCode) return null;

            var json = await fetch.Content.ReadAsStringAsync();


            var deserialize = JsonConvert.DeserializeObject<List<BookModel>>(json);
            

            return deserialize;
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
