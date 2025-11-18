using Library.Components;
using Library.Models;
using Library.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public BooksController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _client = factory.CreateClient("LibraryAPI");
        }
        public async Task<IActionResult> Index(int page)
        {
            if(!CheckAdmin()) return RedirectToAction("Index", "Home");
            int startIndex = page == null ? 1 : (int)((page - 1) * 10);
            BooksModel bookModel = await ViewCreator.GetBooksModel(_client, startIndex);
            bookModel.Pagination = GetPagination(bookModel.Count);
            return View(bookModel);
        }
        public async Task<IActionResult> Create()
        {
            if (!CheckAdmin()) return RedirectToAction("Index", "Home");
            CreateBookModel model = await ViewCreator.GetCreateBookModel(_client);
            return View(model);
        }
        public async Task<IActionResult> Edit(int bookId)
        {
            if(!CheckAdmin()) return RedirectToAction("Index", "Home");
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Id")) || bool.Parse(HttpContext.Session.GetString("Admin")) == false) return RedirectToAction("Index", "Home");
            CreateBookModel model = await ViewCreator.GetCreateBookModel(_client);
            model.Book = await Data.GetData<BookModel>(_client, $"/api/Books/{bookId}");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookDto bookDto)
        {
            MultipartFormDataContent form = new();
            form.Add(new StringContent(bookDto.Title), "Title");
            form.Add(new StringContent(bookDto.Description), "Description");
            form.Add(new StringContent(bookDto.CategoryId.ToString()), "CategoryId");
            form.Add(new StringContent(bookDto.AuthorId.ToString()), "AuthorId");
            form.Add(new StringContent(bookDto.ReleaseDate.ToString()), "ReleaseDate");
            form.Add(new StringContent(bookDto.Amount.ToString()), "Amount");

            var stream = bookDto.Image.OpenReadStream();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(bookDto.Image.ContentType);
            form.Add(fileContent, "Image", bookDto.Image.FileName);

            
            var fetch = await _client.PostAsync("/api/Books", form);
            return RedirectToAction("Create", "Books");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDto bookDto)
        {
            MultipartFormDataContent form = new();
            form.Add(new StringContent(bookDto.BookId.ToString()), "BookId");
            form.Add(new StringContent(bookDto.Title), "Title");
            form.Add(new StringContent(bookDto.Description), "Description");
            form.Add(new StringContent(bookDto.CategoryId.ToString()), "CategoryId");
            form.Add(new StringContent(bookDto.AuthorId.ToString()), "AuthorId");
            form.Add(new StringContent(bookDto.ReleaseDate.ToString()), "ReleaseDate");
            form.Add(new StringContent(bookDto.Amount.ToString()), "Amount");

            if(bookDto.Image != null)
            {
                var stream = bookDto.Image.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(bookDto.Image.ContentType);
                form.Add(fileContent, "Image", bookDto.Image.FileName);
            }


            var fetch = await _client.PutAsync("/api/Books", form);
            return RedirectToAction("Edit", "Books", new { bookId = bookDto.BookId});
        }
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var fetch = await _client.DeleteAsync($"api/Books/{bookId}");
            return RedirectToAction("Index", "Books", new { page = 1 });
        }
        private bool CheckAdmin()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Id")) || bool.Parse(HttpContext.Session.GetString("Admin")) == false) return false;
            return true;
        }
        private int GetPagination(int numberOfElements)
        {
            int divisior = 10;
            float divide = ((float)numberOfElements / (float)divisior);
            int pagination = divisior > numberOfElements ? 1 : (int)Math.Ceiling(divide);
            return pagination;
        }
    }
}
