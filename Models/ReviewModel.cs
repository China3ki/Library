namespace Library.Models
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; } = string.Empty;
        public int ReviewRate { get; set; }
        public int ReviewBookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string UserNick { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;
    }
}
