using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.ProductForClient>>> GetProductsForClients()
        {
            return (await _bll.ProductsForClients.AllAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.ProductForClientMapper.MapFromInternal(e))
                .ToList();
        }

        // GET: api/ProductsForClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.ProductForClient>> GetProductForClient(int id)
        {
            var productForClient = PublicApi.v1.Mappers.ProductForClientMapper.MapFromInternal(
                await _bll.ProductsForClients.FindAsync(id));

            if (productForClient == null)
            {
                return NotFound();
            }

            return productForClient;
        }

        // PUT: api/ProductsForClients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductForClient(int id, 
            PublicApi.v1.DTO.ProductForClient productForClient)
        {
            if (id != productForClient.Id)
            {
                return BadRequest();
            }

            _bll.ProductsForClients.Update(PublicApi.v1.Mappers.ProductForClientMapper.MapFromExternal(productForClient));
             await _bll.SaveChangesAsync();
           

            return NoContent();
        }

        // POST: api/ProductsForClients
        [HttpPost]
        public async Task<ActionResult<ProductForClient>> PostProductForClient(
            PublicApi.v1.DTO.ProductForClient productForClient)
        {
            productForClient = PublicApi.v1.Mappers.ProductForClientMapper.MapFromInternal(
                await _bll.ProductsForClients.AddAsync(PublicApi.v1.Mappers.ProductForClientMapper.MapFromExternal(
                    productForClient)));
            
            await _bll.SaveChangesAsync();
            
            productForClient = PublicApi.v1.Mappers.ProductForClientMapper.MapFromInternal(
                _bll.ProductsForClients.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.ProductForClientMapper.MapFromExternal(productForClient)));

            return CreatedAtAction("GetProductForClient", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = productForClient.Id
            }, productForClient);
        }

        // DELETE: api/ProductsForClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.ProductForClient>> DeleteProductForClient(int id)
        {
            var productForClient = await _bll.ProductsForClients.FindAsync(id);
            if (productForClient == null)
            {
                return NotFound();
            }

            _bll.ProductsForClients.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
