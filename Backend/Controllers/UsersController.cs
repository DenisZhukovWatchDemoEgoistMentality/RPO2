using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopitoAPI.Data;
using TopitoAPI.DTOs;
using TopitoAPI.Models;

namespace TopitoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Login = u.Login,
                    Mail = u.Mail,
                    Balance = u.Balance
                })
                .ToListAsync();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Login = u.Login,
                    Mail = u.Mail,
                    Balance = u.Balance
                })
                .FirstOrDefaultAsync();

            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
        {
            // Проверка уникальности логина и почты
            if (await _context.Users.AnyAsync(u => u.Login == createUserDto.Login))
                return BadRequest("Пользователь с таким логином уже существует");
            if (await _context.Users.AnyAsync(u => u.Mail == createUserDto.Mail))
                return BadRequest("Пользователь с такой почтой уже существует");

            var user = new User
            {
                Login = createUserDto.Login,
                Mail = createUserDto.Mail,
                Password = createUserDto.Password, // В реальном проекте - хэш
                Balance = createUserDto.Balance
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userDto = new UserDto
            {
                Id = user.Id,
                Login = user.Login,
                Mail = user.Mail,
                Balance = user.Balance
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userDto);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            if (!string.IsNullOrEmpty(updateUserDto.Login))
            {
                if (await _context.Users.AnyAsync(u => u.Login == updateUserDto.Login && u.Id != id))
                    return BadRequest("Логин уже занят");
                user.Login = updateUserDto.Login;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Mail))
            {
                if (await _context.Users.AnyAsync(u => u.Mail == updateUserDto.Mail && u.Id != id))
                    return BadRequest("Почта уже используется");
                user.Mail = updateUserDto.Mail;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Password))
                user.Password = updateUserDto.Password;
            if (updateUserDto.Balance.HasValue)
                user.Balance = updateUserDto.Balance.Value;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginUserDto loginDto)
        {
            var user = await _context.Users
                .Where(u => u.Login == loginDto.Login && u.Password == loginDto.Password)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Login = u.Login,
                    Mail = u.Mail,
                    Balance = u.Balance
                })
                .FirstOrDefaultAsync();

            if (user == null)
                return Unauthorized("Неверный логин или пароль");

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}