using Library.Models;

namespace Library.ViewModels.Admin
{
    public class BooksModel(List<BookModel> books, int pagination )
    {
        public List<BookModel> Books { get; set; } = books;
        public int Pagination { get; set; } = pagination;
    }
}
