namespace TopitoAPI.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
    }
}