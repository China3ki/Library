using Newtonsoft.Json;

namespace Library.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string BookDescription { get; set; } = string.Empty;
        public int BookCategoryId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorSurname { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public short BookReleaseDate { get; set; }
        public string BookCover { get; set; } = string.Empty;
        public int BookAmount { get; set; }
        public float? AverageRate { get; set; }
    }
}
