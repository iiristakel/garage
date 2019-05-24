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
    public class ProductsServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsServicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductsServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductService>>> GetProductsServices()
        {
            return await _context.ProductsServices.ToListAsync();
        }

        // GET: api/ProductsServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductService>> GetProductService(int id)
        {
            var productService = await _context.ProductsServices.FindAsync(id);

            if (productService == null)
            {
                return NotFound();
            }

            return productService;
        }

        // PUT: api/ProductsServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductService(int id, ProductService productService)
        {
            if (id != productService.Id)
            {
                return BadRequest();
            }

            _context.Entry(productService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductServiceExists(id))
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

        // POST: api/ProductsServices
        [HttpPost]
        public async Task<ActionResult<ProductService>> PostProductService(ProductService productService)
        {
            _context.ProductsServices.Add(productService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductService", new { id = productService.Id }, productService);
        }

        // DELETE: api/ProductsServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductService>> DeleteProductService(int id)
        {
            var productService = await _context.ProductsServices.FindAsync(id);
            if (productService == null)
            {
                return NotFound();
            }

            _context.ProductsServices.Remove(productService);
            await _context.SaveChangesAsync();

            return productService;
        }

        private bool ProductServiceExists(int id)
        {
            return _context.ProductsServices.Any(e => e.Id == id);
        }
    }
}
