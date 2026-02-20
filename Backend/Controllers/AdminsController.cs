using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopitoAPI.Data;
using TopitoAPI.DTOs;
using TopitoAPI.Models;

namespace TopitoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAdmins()
        {
            var admins = await _context.Admins
                .Select(a => new AdminDto
                {
                    Id = a.Id,
                    Login = a.Login
                })
                .ToListAsync();
            return Ok(admins);
        }

        // POST: api/Admins
        [HttpPost]
        public async Task<ActionResult<AdminDto>> CreateAdmin(CreateAdminDto createAdminDto)
        {
            if (await _context.Admins.AnyAsync(a => a.Login == createAdminDto.Login))
                return BadRequest("Администратор с таким логином уже существует");

            var admin = new Admin
            {
                Login = createAdminDto.Login,
                Password = createAdminDto.Password
            };

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            var adminDto = new AdminDto { Id = admin.Id, Login = admin.Login };
            return CreatedAtAction(nameof(GetAdmins), new { id = admin.Id }, adminDto);
        }

        // POST: api/Admins/login
        [HttpPost("login")]
        public async Task<ActionResult<AdminDto>> Login(LoginAdminDto loginDto)
        {
            var admin = await _context.Admins
                .Where(a => a.Login == loginDto.Login && a.Password == loginDto.Password)
                .Select(a => new AdminDto { Id = a.Id, Login = a.Login })
                .FirstOrDefaultAsync();

            if (admin == null)
                return Unauthorized("Неверный логин или пароль администратора");

            return Ok(admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null) return NotFound();

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}