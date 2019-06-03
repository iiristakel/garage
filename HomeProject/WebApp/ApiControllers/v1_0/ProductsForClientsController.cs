using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    /// <summary>
    /// Represents a RESTful products for clients service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProductsForClientsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Products for clients controller.
        /// </summary>
        /// <param name="bll"></param>
        public ProductsForClientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all products for clients.
        /// </summary>
        /// <returns>All products for clients.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.ProductForClient>>> GetProductsForClients()
        {
            return (await _bll.ProductsForClients.AllAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.ProductForClientMapper.MapFromInternal(e))
                .ToList();
        }

        /// <summary>
        /// Get single product for client.
        /// </summary>
        /// <param name="id">Identifier for product for client.</param>
        /// <returns>Requested product for client.</returns>
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

        /// <summary>
        /// Update client's product.
        /// </summary>
        /// <param name="id">Identifier for product for client.</param>
        /// <param name="productForClient">Product for client which is updated.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Add new product for client.
        /// </summary>
        /// <param name="productForClient"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Remove product from client.
        /// </summary>
        /// <param name="id">Identifier for product for client.</param>
        /// <returns></returns>
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
