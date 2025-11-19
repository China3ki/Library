namespace Library.Models
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorSurname { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }
}
