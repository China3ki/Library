using System.Text.Json.Serialization;

namespace Library.Models
{
    public class LoginDto
    {
        public string LoginEmail { get; set; } = string.Empty;
        public string LoginPassword { get; set; } = string.Empty;
    }
}
