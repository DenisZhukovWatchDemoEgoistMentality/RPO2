namespace TopitoAPI.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int ConditionId { get; set; }
        public int StatusId { get; set; }

        public User Owner { get; set; } = null!;
        public Condition Condition { get; set; } = null!;
        public ResourceStatus Status { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}