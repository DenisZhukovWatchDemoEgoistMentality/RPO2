namespace TopitoAPI.DTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
    }

    public class CreateAdminDto
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginAdminDto
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}