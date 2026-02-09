namespace Api_Topito.Models
{
    public class Resourse
    {
        public int Id { get; set; }
        public int Owner_id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Status { get; set; } = 1;
    }
}
