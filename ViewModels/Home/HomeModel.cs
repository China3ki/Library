using Library.Models;

namespace Library.ViewModels.Home
{
    public class HomeModel
    {
        public List<BookModel> BestBooks { get; set; } = [];
        public List<BookModel> NewBooks { get; set; } = [];
        public List<CategoryModel> Categories { get; set; } = [];
        public List<ReviewModel> Reviews { get; set; } = [];
    }
}
