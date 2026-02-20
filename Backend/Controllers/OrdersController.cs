using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopitoAPI.Data;
using TopitoAPI.DTOs;
using TopitoAPI.Models;

namespace TopitoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Resource)
                .Include(o => o.Customer)
                .Include(o => o.Status)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    ResourceId = o.ResourceId,
                    ResourceName = o.Resource.Name,
                    CustomerId = o.CustomerId,
                    CustomerLogin = o.Customer.Login,
                    Quantity = o.Quantity,
                    StatusId = o.StatusId,
                    StatusName = o.Status.Name,
                    CreatedAt = o.CreatedAt
                })
                .ToListAsync();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Resource)
                .Include(o => o.Customer)
                .Include(o => o.Status)
                .Where(o => o.Id == id)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    ResourceId = o.ResourceId,
                    ResourceName = o.Resource.Name,
                    CustomerId = o.CustomerId,
                    CustomerLogin = o.Customer.Login,
                    Quantity = o.Quantity,
                    StatusId = o.StatusId,
                    StatusName = o.Status.Name,
                    CreatedAt = o.CreatedAt
                })
                .FirstOrDefaultAsync();

            if (order == null) return NotFound();
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderDto createOrderDto)
        {
            // Проверяем наличие ресурса и его статус (возможно, нужно проверять, не продан ли он)
            var resource = await _context.Resources.FindAsync(createOrderDto.ResourceId);
            if (resource == null)
                return BadRequest("Ресурс не найден");
            if (resource.StatusId == 2) // Продан
                return BadRequest("Ресурс уже продан");

            var order = new Order
            {
                ResourceId = createOrderDto.ResourceId,
                CustomerId = createOrderDto.CustomerId,
                Quantity = createOrderDto.Quantity,
                StatusId = createOrderDto.StatusId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderDto = new OrderDto
            {
                Id = order.Id,
                ResourceId = order.ResourceId,
                CustomerId = order.CustomerId,
                Quantity = order.Quantity,
                StatusId = order.StatusId,
                CreatedAt = order.CreatedAt
            };

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, orderDto);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            if (updateOrderDto.StatusId.HasValue)
                order.StatusId = updateOrderDto.StatusId.Value;
            if (updateOrderDto.Quantity.HasValue)
                order.Quantity = updateOrderDto.Quantity.Value;

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}