using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly FrancescosPizzeriaContext _context;

        public OrderItemsController(FrancescosPizzeriaContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet("order/{id}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int id)
        {
            var orders = _context.OrderItem.Where(x => x.OrderId == id);

            if(!orders.Any())
            {
                return NotFound(new { error = "No order found" });
            }

            return Ok( new { orders = orders});
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _context.OrderItem.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPatch("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
        {
            OrderItem Item = _context.OrderItem.FirstOrDefault(x => x.Id == id);

            if(Item == null)
            {
                return NotFound( new { error = "Item not found"});
            }

           /* public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? SpecialRequests { get; set; }
        public string SizeReg { get; set; }
        public string SizeSmall { get; set; }
        public decimal PriceReg { get; set; }
        public decimal PriceSmall { get; set; }
        public string Ingredients { get; set; }

        public int Quantity { get; set; }*/

            if(orderItem.Category != null)
            {
                Item.Category = orderItem.Category;
            }

            if (orderItem.Title != null)
            {
                Item.Title  = orderItem.Title;
            }

            if (orderItem.Description != null)
            {
                Item.Description = orderItem.Description;
            }

            if (orderItem.SpecialRequests != null)
            {
                Item.SpecialRequests = orderItem.SpecialRequests;
            }

            if (orderItem.SizeReg != null)
            {
                Item.SizeReg = orderItem.SizeReg;
            }

            if (orderItem.SizeSmall != null)
            {
                Item.SizeSmall = orderItem.SizeSmall;
            }

            if (orderItem.PriceReg >= 0)
            {
                Item.PriceReg = orderItem.PriceReg;
            }

            if (orderItem.PriceSmall >= 0)
            {
                Item.PriceSmall = orderItem.PriceSmall;
            }

            if (orderItem.Ingredients != null)
            {
                Item.Ingredients = orderItem.Ingredients;
            }

            if (orderItem.Quantity > 0)
            {
                Item.Quantity = orderItem.Quantity;
            }

            _context.Entry(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok( new { updated = Item});
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItem>> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItem.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItem.Remove(orderItem);
            await _context.SaveChangesAsync();

            return Ok(new { deleted = orderItem});
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItem.Any(e => e.Id == id);
        }
    }
}
