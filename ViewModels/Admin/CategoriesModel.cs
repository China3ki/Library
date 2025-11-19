using Library.Models;

namespace Library.ViewModels.Admin
{
    public class CategoriesModel(List<CategoryModel> categories, int pagination)
    {
        public List<CategoryModel> Categories = categories;
        public int Pagination = pagination;
    }
}
