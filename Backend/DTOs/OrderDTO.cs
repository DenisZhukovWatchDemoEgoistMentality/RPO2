namespace TopitoAPI.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public string CustomerLogin { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class CreateOrderDto
    {
        public int ResourceId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; } = 1; // Ожидание
    }

    public class UpdateOrderDto
    {
        public int? StatusId { get; set; }
        public int? Quantity { get; set; }
    }
}