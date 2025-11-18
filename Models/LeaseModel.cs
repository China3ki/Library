namespace Library.Models
{
    public class LeaseModel
    {
        public int LeaseId { get; set; }
        public int UserId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string BookCover { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}