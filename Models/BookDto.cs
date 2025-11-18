namespace Library.Models
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public short ReleaseDate { get; set; }
        public int Amount { get; set; }
        public IFormFile Image { get; set; }
    }
}
