namespace TopitoAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Resource Resource { get; set; } = null!;
        public User Customer { get; set; } = null!;
        public OrderStatus Status { get; set; } = null!;
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
