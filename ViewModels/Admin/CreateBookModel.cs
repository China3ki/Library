using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.ViewModels.Admin
{
    public class CreateBookModel(List<SelectListItem> categories, List<SelectListItem> authors, BookModel book)
    {
        public List<SelectListItem> Categories { get; set; } = categories;
        public List<SelectListItem> Authors { get; set; } = authors;
        public BookModel Book { get; set; } = book;
    }
}
