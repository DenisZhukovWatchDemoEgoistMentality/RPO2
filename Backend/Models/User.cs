namespace TopitoAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // в реальном проекте хэш!
        public int Balance { get; set; }
        
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}