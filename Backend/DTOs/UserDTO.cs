namespace TopitoAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public int Balance { get; set; }
    }

    public class CreateUserDto
    {
        public string Login { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Balance { get; set; } = 0;
    }

    public class UpdateUserDto
    {
        public string? Login { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public int? Balance { get; set; }
    }

    public class LoginUserDto
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}