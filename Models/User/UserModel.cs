namespace Library.Models.User
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserNick { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;
        public int UserFollowers { get; set; }
        public int UserFollowed { get; set; }
    }
}
