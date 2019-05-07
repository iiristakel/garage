using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProductsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ProductsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Product>>> GetProducts()
        {
            return (await _bll.Products.AllAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.ProductMapper.MapFromInternal(e))
                .ToList();
        }

        // GET: api/Products/5
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

        // PUT: api/Products/5
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

        // POST: api/Products
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

        // DELETE: api/Products/5
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
