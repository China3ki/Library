namespace Library.Models
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; } = string.Empty;
        public int RevieRate { get; set; }
        public string UserNick { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;
    }
}
