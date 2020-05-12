using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace FrancescosPizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly FrancescosPizzeriaContext _context;

        public OrdersController(FrancescosPizzeriaContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            Order order = _context.Order.FirstOrDefault(x => x.UserId == int.Parse(User.Identity.Name) && x.OrderComplete == false);

            if( order == null)
            {
                return NotFound( new { error = "No order was found"});
            }

            return Ok( new { order = order});
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // Patch: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchOrder(int id, Order order)
        {
            Order currentOrder = _context.Order.FirstOrDefault(x => x.Id == id);

            if(order.PointsEarned > 0)
            {
                currentOrder.PointsEarned = order.PointsEarned;
            }

            if(order.OrderType != null)
            {
                currentOrder.OrderType = order.OrderType;
            }

            if (order.Time != null)
            {
                currentOrder.Time = order.Time;
            }

            if (order.Address != null)
            {
                currentOrder.Address = order.Address;
            }

            if(order.MobileNumber != null)
            {
                currentOrder.MobileNumber = order.MobileNumber;
            }

            if(order.OrderComplete == true)
            {
                currentOrder.OrderComplete = order.OrderComplete;
            }

            _context.Entry(currentOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok( new { patched = currentOrder});
        }

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            Order newOrder = order;
            newOrder.DateCreated = DateTime.Now;

            _context.Order.Add(newOrder);

            await _context.SaveChangesAsync();

            return Ok(new { createdOrder = newOrder});
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
