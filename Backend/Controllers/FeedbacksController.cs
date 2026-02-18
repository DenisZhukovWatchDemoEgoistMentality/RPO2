using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopitoAPI.Data;
using TopitoAPI.DTOs;
using TopitoAPI.Models;

namespace TopitoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetFeedbacks()
        {
            var feedbacks = await _context.Feedbacks
                .Select(f => new FeedbackDto
                {
                    Id = f.Id,
                    OrderId = f.OrderId,
                    Stars = f.Stars,
                    Description = f.Description
                })
                .ToListAsync();
            return Ok(feedbacks);
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDto>> GetFeedback(int id)
        {
            var feedback = await _context.Feedbacks
                .Where(f => f.Id == id)
                .Select(f => new FeedbackDto
                {
                    Id = f.Id,
                    OrderId = f.OrderId,
                    Stars = f.Stars,
                    Description = f.Description
                })
                .FirstOrDefaultAsync();

            if (feedback == null) return NotFound();
            return Ok(feedback);
        }

        // POST: api/Feedbacks
        [HttpPost]
        public async Task<ActionResult<FeedbackDto>> CreateFeedback(CreateFeedbackDto createFeedbackDto)
        {
            var order = await _context.Orders.FindAsync(createFeedbackDto.OrderId);
            if (order == null)
                return BadRequest("Заказ не найден");
            
            // Проверка, не оставлен ли уже отзыв к этому заказу (по желанию)
            if (await _context.Feedbacks.AnyAsync(f => f.OrderId == createFeedbackDto.OrderId))
                return BadRequest("Отзыв для этого заказа уже существует");

            if (createFeedbackDto.Stars < 1 || createFeedbackDto.Stars > 5)
                return BadRequest("Оценка должна быть от 1 до 5");

            var feedback = new Feedback
            {
                OrderId = createFeedbackDto.OrderId,
                Stars = createFeedbackDto.Stars,
                Description = createFeedbackDto.Description
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            var feedbackDto = new FeedbackDto
            {
                Id = feedback.Id,
                OrderId = feedback.OrderId,
                Stars = feedback.Stars,
                Description = feedback.Description
            };

            return CreatedAtAction(nameof(GetFeedback), new { id = feedback.Id }, feedbackDto);
        }

        // PUT: api/Feedbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, UpdateFeedbackDto updateFeedbackDto)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return NotFound();

            if (updateFeedbackDto.Stars.HasValue)
            {
                if (updateFeedbackDto.Stars.Value < 1 || updateFeedbackDto.Stars.Value > 5)
                    return BadRequest("Оценка должна быть от 1 до 5");
                feedback.Stars = updateFeedbackDto.Stars.Value;
            }
            if (updateFeedbackDto.Description != null)
                feedback.Description = updateFeedbackDto.Description;

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null) return NotFound();

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}