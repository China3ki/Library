using Library.Models;

namespace Library.ViewModels.Admin
{
    public class AuthorsModel(List<AuthorModel> authors, int pagination)
    {
        public List<AuthorModel> Authors { get; set; } = authors;
        public int Pagination { get; set; } = pagination;
    }
}
