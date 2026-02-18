using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopitoAPI.Data;
using TopitoAPI.DTOs;
using TopitoAPI.Models;

namespace TopitoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Resources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResources()
        {
            var resources = await _context.Resources
                .Include(r => r.Owner)
                .Include(r => r.Condition)
                .Include(r => r.Status)
                .Select(r => new ResourceDto
                {
                    Id = r.Id,
                    OwnerId = r.OwnerId,
                    OwnerLogin = r.Owner.Login,
                    Name = r.Name,
                    Description = r.Description,
                    Price = r.Price,
                    ConditionId = r.ConditionId,
                    ConditionName = r.Condition.Name,
                    StatusId = r.StatusId,
                    StatusName = r.Status.Name
                })
                .ToListAsync();
            return Ok(resources);
        }

        // GET: api/Resources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceDto>> GetResource(int id)
        {
            var resource = await _context.Resources
                .Include(r => r.Owner)
                .Include(r => r.Condition)
                .Include(r => r.Status)
                .Where(r => r.Id == id)
                .Select(r => new ResourceDto
                {
                    Id = r.Id,
                    OwnerId = r.OwnerId,
                    OwnerLogin = r.Owner.Login,
                    Name = r.Name,
                    Description = r.Description,
                    Price = r.Price,
                    ConditionId = r.ConditionId,
                    ConditionName = r.Condition.Name,
                    StatusId = r.StatusId,
                    StatusName = r.Status.Name
                })
                .FirstOrDefaultAsync();

            if (resource == null) return NotFound();
            return Ok(resource);
        }

        // POST: api/Resources
        [HttpPost]
        public async Task<ActionResult<ResourceDto>> CreateResource(CreateResourceDto createResourceDto)
        {
            var resource = new Resource
            {
                OwnerId = createResourceDto.OwnerId,
                Name = createResourceDto.Name,
                Description = createResourceDto.Description,
                Price = createResourceDto.Price,
                ConditionId = createResourceDto.ConditionId,
                StatusId = createResourceDto.StatusId
            };

            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();

            var resourceDto = new ResourceDto
            {
                Id = resource.Id,
                OwnerId = resource.OwnerId,
                Name = resource.Name,
                Description = resource.Description,
                Price = resource.Price,
                ConditionId = resource.ConditionId,
                StatusId = resource.StatusId
            };

            return CreatedAtAction(nameof(GetResource), new { id = resource.Id }, resourceDto);
        }

        // PUT: api/Resources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResource(int id, UpdateResourceDto updateResourceDto)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null) return NotFound();

            if (!string.IsNullOrEmpty(updateResourceDto.Name))
                resource.Name = updateResourceDto.Name;
            if (updateResourceDto.Description != null)
                resource.Description = updateResourceDto.Description;
            if (updateResourceDto.Price.HasValue)
                resource.Price = updateResourceDto.Price.Value;
            if (updateResourceDto.ConditionId.HasValue)
                resource.ConditionId = updateResourceDto.ConditionId.Value;
            if (updateResourceDto.StatusId.HasValue)
                resource.StatusId = updateResourceDto.StatusId.Value;

            _context.Entry(resource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Resources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null) return NotFound();

            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ResourceExists(int id)
        {
            return _context.Resources.Any(e => e.Id == id);
        }
    }
}