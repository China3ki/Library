namespace Library.Models.User
{
    public class UserFollowers
    {
        public int UserId { get; set; }
        public string UserNick { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;
    }
}
