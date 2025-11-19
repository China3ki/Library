using Library.Components;
using Library.Models;
using Library.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace Library.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public AuthorsController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _client = factory.CreateClient("LibraryAPI");
        }
        public async Task<IActionResult> Index(int? page)
        {
            if (!Auth.CheckAdmin(HttpContext)) RedirectToAction("Index", "Home");
            AuthorsModel model = await ViewCreator.GetAuthorsModel(_client, page);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int authorId)
        {
            AuthorModel author = await ViewCreator.GetAuthorModel(_client, authorId);
            return View(author);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(AuthorDto author)
        {
            MultipartFormDataContent form = new();;
            form.Add(new StringContent(author.AuthorId.ToString()), "AuthorId");
            form.Add(new StringContent(author.AuthorName), "Name");
            form.Add(new StringContent(author.AuthorSurname), "Surname");
            if (author.Image != null)
            {
                var stream = author.Image.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(author.Image.ContentType);
                form.Add(fileContent, "Image", author.Image.FileName);
            }
            var fetch = await _client.PutAsync("/api/Authors", form);
            Console.WriteLine(fetch.StatusCode);
            return RedirectToAction("Index", "Authors", new { page = 1 });
        }
        [HttpPost]
        public async Task<IActionResult> Add(AuthorDto author)
        {
            MultipartFormDataContent form = new();
            form.Add(new StringContent(author.AuthorName), "Name");
            form.Add(new StringContent(author.AuthorSurname), "Surname");
            if (author.Image != null)
            {
                var stream = author.Image.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(author.Image.ContentType);
                form.Add(fileContent, "Image", author.Image.FileName);
            }
            var fetch = await _client.PostAsync("/api/Authors", form);
            return RedirectToAction("Index", "Authors", new { page = 1});
        }
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            var delete = await _client.DeleteAsync($"/api/Authors/{authorId}");
            return RedirectToAction("Index", "Authors", new { page = 1 });
        }
    }
}
