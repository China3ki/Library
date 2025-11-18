using Library.Models;

namespace Library.ViewModels.Admin
{
    public class BooksModel(List<BookModel> books, int countBook )
    {
        public List<BookModel> Books { get; set; } = books;
        public int Count { get; set; } = countBook;
        public int Pagination { get; set; }
    }
}
