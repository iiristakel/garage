using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
        private readonly IAppBLL _bll;

        public ProductsForClientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ProductsForClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.ProductForClient>>> GetProductsForClients()
        {
            return await _bll.ProductsForClients.AllAsync();
        }

        // GET: api/ProductsForClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.ProductForClient>> GetProductForClient(int id)
        {
            var productForClient = await _bll.ProductsForClients.FindAsync(id);

            if (productForClient == null)
            {
                return NotFound();
            }

            return productForClient;
        }

        // PUT: api/ProductsForClients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductForClient(int id, 
            BLL.App.DTO.ProductForClient productForClient)
        {
            if (id != productForClient.Id)
            {
                return BadRequest();
            }

            _bll.ProductsForClients.Update(productForClient);
             await _bll.SaveChangesAsync();
           

            return NoContent();
        }

        // POST: api/ProductsForClients
        [HttpPost]
        public async Task<ActionResult<ProductForClient>> PostProductForClient(
            BLL.App.DTO.ProductForClient productForClient)
        {
            await _bll.ProductsForClients.AddAsync(productForClient);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductForClient", new { id = productForClient.Id }, productForClient);
        }

        // DELETE: api/ProductsForClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.ProductForClient>> DeleteProductForClient(int id)
        {
            var productForClient = await _bll.ProductsForClients.FindAsync(id);
            if (productForClient == null)
            {
                return NotFound();
            }

            _bll.ProductsForClients.Remove(productForClient);
            await _bll.SaveChangesAsync();

            return productForClient;
        }

    }
}
