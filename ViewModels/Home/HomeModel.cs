using Library.Models;
using Library.Models.User;

namespace Library.ViewModels.Home
{
    public class HomeModel(List<BookModel> bestBooks, List<BookModel> newBooks, List<CategoryModel> categories, List<ReviewModel> reviews, UserModel user, List<UserFollow> followers, List<UserFollow> followed, List<BookModel> favouriteBooks, List<LeaseModel> lease)
    {
        public List<BookModel> BestBooks { get; set; } = bestBooks;
        public List<BookModel> NewBooks { get; set; } = newBooks;
        public List<CategoryModel> Categories { get; set; } = categories;
        public List<ReviewModel> Reviews { get; set; } = reviews;
        public UserModel UserModel { get; set; } = user;
        public List<UserFollow> UserFollowers { get; set; } = followers;
        public List<UserFollow> UserFollowed { get; set; } = followed;
        public List<BookModel> FavouriteBooks { get; set; } = favouriteBooks;
        public List<LeaseModel> Lease { get; set; } = lease;
    }
}
