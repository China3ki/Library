using Library.Models;
using Library.Models.User;
using Library.ViewModels.Admin;
using Library.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Components
{
    static public class ViewCreator
    {
        static public async Task<HomeModel> GetHomeData(HttpClient client)
        {
            var booksRate = Data.GetData<List<BookModel>>(client, "/api/Books?sortBy=Rate&limit=10");
            var booksDate = Data.GetData<List<BookModel>>(client, "/api/Books?sortBy=date&limit=10");
            var categories = Data.GetData<List<CategoryModel>>(client, "/api/Categories");
            var reviews = Data.GetData<List<ReviewModel>>(client, "/api/Reviews/5");
            await Task.WhenAll(booksRate, booksDate, categories, reviews);
            return new HomeModel(booksRate.Result, booksDate.Result, categories.Result, reviews.Result, null, null, null, null, null);
        }
        static public async Task<HomeModel> GetHomeSessionData(HttpClient client, int userId)
        {
            var booksRate = Data.GetData<List<BookModel>>(client, "/api/Books?sortBy=Rate&limit=10");
            var booksDate = Data.GetData<List<BookModel>>(client, "/api/Books?sortBy=date&limit=10");
            var categories = Data.GetData<List<CategoryModel>>(client, "/api/Categories");
            var reviews = Data.GetData<List<ReviewModel>>(client, "/api/Reviews/5");
            var userModel = Data.GetData<UserModel>(client, $"/api/Users/{userId}");
            var userFollowers = Data.GetData<List<UserFollow>>(client, $"/api/Users/followers/{userId}");
            var userFollowed = Data.GetData<List<UserFollow>>(client, $"/api/Users/followed/{userId}");
            var userFavourite = Data.GetData<List<BookModel>>(client, $"/api/Books/favourite/{userId}");
            var userLease = Data.GetData<List<LeaseModel>>(client, $"/api/Lease/{userId}");
            await Task.WhenAll(booksRate, booksDate, categories, reviews, userModel, userFollowers, userFollowed, userFavourite, userLease);
            
            return new HomeModel(booksRate.Result, booksDate.Result, categories.Result, reviews.Result, userModel.Result, userFollowers.Result, userFollowed.Result, userFavourite.Result, userLease.Result);
        }
        static public async Task<BooksModel> GetBooksModel(HttpClient client, int? page)
        {
            int startIndex = page == null ? 1 : (int)((page - 1) * 10);
            var books = Data.GetData<List<BookModel>>(client, $"/api/Books?start={startIndex}&limit=10");
            var count = Data.GetData<int>(client, "/api/Books/count");
            await Task.WhenAll(books, count);
            return new BooksModel(books.Result, GetPagination(count.Result));
        }
        static public async Task<CreateBookModel> GetCreateBookModel(HttpClient client)
        {
            var categories = Data.GetData<List<CategoryModel>>(client, "/api/Categories");
            var authors = Data.GetData<List<AuthorModel>>(client, "/api/Authors");
            await Task.WhenAll(categories, authors);
            List<SelectListItem> categoriesList = [];
            List<SelectListItem> authorsList = [];
            foreach(var category in categories.Result)
            {
                categoriesList.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.CategoryName });
            }
            foreach(var author in authors.Result)
            {
                authorsList.Add(new SelectListItem { Value = author.AuthorId.ToString(), Text = $"{author.AuthorName} {author.AuthorSurname}" });
            }
            return new CreateBookModel(categoriesList, authorsList, null);
        }
        static public async Task<AuthorsModel> GetAuthorsModel(HttpClient client, int? page)
        {
            int startIndex = page == null ? 1 : (int)((page - 1) * 10);
            var authors = Data.GetData<List<AuthorModel>>(client, $"/api/Authors?start={startIndex}&limit=10");
            var count = Data.GetData<int>(client, "/api/Authors/count");
            await Task.WhenAll(authors, count);
            return new AuthorsModel(authors.Result, GetPagination(count.Result));
        }
        static public async Task<AuthorModel> GetAuthorModel(HttpClient client, int authorId)
        {
            var author = await Data.GetData<AuthorModel>(client, $"/api/Authors/{authorId}");
            return author;
        }
        static public async Task<CategoriesModel> GetCategoriesModel(HttpClient client, int? page)
        {
            int startIndex = page == null ? 1 : (int)((page - 1) * 10);
            var categories = Data.GetData<List<CategoryModel>>(client, $"/api/Categories?start={startIndex}&limit=10");
            var count = Data.GetData<int>(client, "/api/Categories/count");
            await Task.WhenAll(categories, count);
            return new CategoriesModel(categories.Result, GetPagination(count.Result));
        }
        static public int GetPagination(int numberOfElements)
        {
            int divisior = 10;
            float divide = ((float)numberOfElements / (float)divisior);
            int pagination = divisior > numberOfElements ? 1 : (int)Math.Ceiling(divide);
            return pagination;
        }
    }
}
