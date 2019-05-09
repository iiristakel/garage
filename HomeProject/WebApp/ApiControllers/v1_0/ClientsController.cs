using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    /// <summary>
    /// Represents a RESTful clients service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Clients controller.
        /// </summary>
        /// <param name="bll"></param>
        public ClientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all clients.
        /// </summary>
        /// <returns>All clients with products count.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.ClientWithProductsCount>>> GetClients()
        {
            return (await _bll.Clients.GetAllWithProductsCountAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.ClientMapper.MapFromInternal(e))
                .ToList();
        }

        /// <summary>
        /// Get single client.
        /// </summary>
        /// <param name="id">Identifier for client.</param>
        /// <returns>Requested client object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Client>> GetClient(int id)
        {
            var client = PublicApi.v1.Mappers.ClientMapper.MapFromInternal(
                await _bll.Clients.FindAsync(id));

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        /// <summary>
        /// Update client.
        /// </summary>
        /// <param name="id">Identifier for client.</param>
        /// <param name="client">Client which is updated.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, PublicApi.v1.DTO.Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _bll.Clients.Update(PublicApi.v1.Mappers.ClientMapper.MapFromExternal(client));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Client>> PostClient(PublicApi.v1.DTO.Client client)
        {
            client = PublicApi.v1.Mappers.ClientMapper.MapFromInternal(
                _bll.Clients.Add(PublicApi.v1.Mappers.ClientMapper.MapFromExternal(client)));
            
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetClient", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = client.Id
            }, client);
        }

        /// <summary>
        /// Delete client.
        /// </summary>
        /// <param name="id">Identifier for client.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Client>> DeleteClient(int id)
        {
            var client = await _bll.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _bll.Clients.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
