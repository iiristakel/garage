using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    /// <summary>
    /// Represents a RESTful products service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProductsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Products controller.
        /// </summary>
        /// <param name="bll"></param>
        public ProductsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>All products.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Product>>> GetProducts()
        {
            return (await _bll.Products.AllAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.ProductMapper.MapFromInternal(e))
                .ToList();
        }

        /// <summary>
        /// Get single product.
        /// </summary>
        /// <param name="id">Identifier for product.</param>
        /// <returns>Requested product.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Product>> GetProduct(int id)
        {
            var product = PublicApi.v1.Mappers.ProductMapper.MapFromInternal(
                await _bll.Products.FindAsync(id));

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Update product information.
        /// </summary>
        /// <param name="id">Identifier for product.</param>
        /// <param name="product">Product which is updated.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, PublicApi.v1.DTO.Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _bll.Products.Update(PublicApi.v1.Mappers.ProductMapper.MapFromExternal(product));
            await _bll.SaveChangesAsync();
           
            return NoContent();
        }

        /// <summary>
        /// Create new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Product>> PostProduct(PublicApi.v1.DTO.Product product)
        {
            product = PublicApi.v1.Mappers.ProductMapper.MapFromInternal(
                _bll.Products.Add(PublicApi.v1.Mappers.ProductMapper.MapFromExternal(product)));
            
            await _bll.SaveChangesAsync();

            product = PublicApi.v1.Mappers.ProductMapper.MapFromInternal(
                _bll.Products.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.ProductMapper.MapFromExternal(product)));

            return CreatedAtAction("GetProduct", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = product.Id
            }, product);
        }

        /// <summary>
        /// Delete product.
        /// </summary>
        /// <param name="id">Identifier for product.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Product>> DeleteProduct(int id)
        {
            var product = await _bll.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _bll.Products.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
