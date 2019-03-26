using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
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
        private readonly IAppUnitOfWork _uow;

        public ProductsForClientsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ProductsForClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductForClient>>> GetProductsForClients()
        {
            var res = await _uow.ProductsForClients.AllAsync();
            return Ok(res);
        }

        // GET: api/ProductsForClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductForClient>> GetProductForClient(int id)
        {
            var productForClient = await _uow.ProductsForClients.FindAsync(id);

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

            _uow.ProductsForClients.Update(productForClient);
             await _uow.SaveChangesAsync();
           

            return NoContent();
        }

        // POST: api/ProductsForClients
        [HttpPost]
        public async Task<ActionResult<ProductForClient>> PostProductForClient(ProductForClient productForClient)
        {
            await _uow.ProductsForClients.AddAsync(productForClient);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetProductForClient", new { id = productForClient.Id }, productForClient);
        }

        // DELETE: api/ProductsForClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductForClient>> DeleteProductForClient(int id)
        {
            var productForClient = await _uow.ProductsForClients.FindAsync(id);
            if (productForClient == null)
            {
                return NotFound();
            }

            _uow.ProductsForClients.Remove(productForClient);
            await _uow.SaveChangesAsync();

            return productForClient;
        }

    }
}
