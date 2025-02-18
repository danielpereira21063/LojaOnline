using LojaOnline.OrderApi.Context;
using LojaOnline.OrderApi.Messages;
using LojaOnline.OrderApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace LojaOnline.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderController(AppDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            order.Id = Guid.NewGuid();
            //_context.Orders.Add(order);
            //await _context.SaveChangesAsync();

            await _publishEndpoint.Publish(new OrderCreated(order.Id, order.CustomerName, order.TotalAmount));

            return Ok();
        }
    }
}
