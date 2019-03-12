using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsForClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsForClientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductsForClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductForClient>>> GetProductsForClients()
        {
            return await _context.ProductsForClients.ToListAsync();
        }

        // GET: api/ProductsForClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductForClient>> GetProductForClient(int id)
        {
            var productForClient = await _context.ProductsForClients.FindAsync(id);

            if (productForClient == null)
            {
                return NotFound();
            }

            return productForClient;
        }

        // PUT: api/ProductsForClients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductForClient(int id, ProductForClient productForClient)
        {
            if (id != productForClient.Id)
            {
                return BadRequest();
            }

            _context.Entry(productForClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductForClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductsForClients
        [HttpPost]
        public async Task<ActionResult<ProductForClient>> PostProductForClient(ProductForClient productForClient)
        {
            _context.ProductsForClients.Add(productForClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductForClient", new { id = productForClient.Id }, productForClient);
        }

        // DELETE: api/ProductsForClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductForClient>> DeleteProductForClient(int id)
        {
            var productForClient = await _context.ProductsForClients.FindAsync(id);
            if (productForClient == null)
            {
                return NotFound();
            }

            _context.ProductsForClients.Remove(productForClient);
            await _context.SaveChangesAsync();

            return productForClient;
        }

        private bool ProductForClientExists(int id)
        {
            return _context.ProductsForClients.Any(e => e.Id == id);
        }
    }
}
