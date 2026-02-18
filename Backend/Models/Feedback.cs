namespace TopitoAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Stars { get; set; }
        public string? Description { get; set; }

        public Order Order { get; set; } = null!;
    }
}