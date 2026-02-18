namespace TopitoAPI.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // хэш
        
    }
}