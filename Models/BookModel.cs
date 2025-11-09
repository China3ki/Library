namespace Library.Models
{
    public class BookModel
    {
        public int BookdId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string BookDescription { get; set; } = string.Empty;
        public int BookCategoryId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorSurname { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public short BookReleaseDate { get; set; }
        public string BookCover { get; set; } = string.Empty;
        public float AverageRate { get; set; }
    }
}
