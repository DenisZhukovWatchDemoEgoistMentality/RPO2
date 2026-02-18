using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopitoAPI.Data;
using TopitoAPI.DTOs;

namespace TopitoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Status/resource-statuses
        [HttpGet("resource-statuses")]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetResourceStatuses()
        {
            var statuses = await _context.ResourceStatuses
                .Select(s => new StatusDto { Id = s.Id, Name = s.Name })
                .ToListAsync();
            return Ok(statuses);
        }

        // GET: api/Status/conditions
        [HttpGet("conditions")]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetConditions()
        {
            var conditions = await _context.Conditions
                .Select(c => new StatusDto { Id = c.Id, Name = c.Name })
                .ToListAsync();
            return Ok(conditions);
        }

        // GET: api/Status/order-statuses
        [HttpGet("order-statuses")]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetOrderStatuses()
        {
            var statuses = await _context.OrderStatuses
                .Select(s => new StatusDto { Id = s.Id, Name = s.Name })
                .ToListAsync();
            return Ok(statuses);
        }
    }
}