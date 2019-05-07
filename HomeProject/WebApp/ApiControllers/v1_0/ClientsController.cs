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
    public class ClientsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ClientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.ClientWithProductsCount>>> GetClients()
        {
            return (await _bll.Clients.GetAllWithProductsCountAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.ClientMapper.MapFromInternal(e))
                .ToList();
        }

        // GET: api/Clients/5
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

        // PUT: api/Clients/5
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

        // POST: api/Clients
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

        // DELETE: api/Clients/5
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
