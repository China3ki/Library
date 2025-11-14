using System.Text.Json.Serialization;

namespace Library.Models
{
    public class SessionModel
    {
        public int UserId { get; set; }
        public string UserNick { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;
    }
}
