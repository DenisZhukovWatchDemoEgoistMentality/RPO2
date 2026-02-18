namespace TopitoAPI.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Stars { get; set; }
        public string? Description { get; set; }
    }

    public class CreateFeedbackDto
    {
        public int OrderId { get; set; }
        public int Stars { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateFeedbackDto
    {
        public int? Stars { get; set; }
        public string? Description { get; set; }
    }
}