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
    public class ClientGroupsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        
        public ClientGroupsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: api/ClientGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.ClientGroupWithClientCount>>> GetClientGroups()
        {
           return (await _bll.ClientGroups.GetAllWithClientCountAsync())
               .Select(e =>
                   PublicApi.v1.Mappers.ClientGroupMapper.MapFromInternal(e))
               .ToList();
        }

        // GET: api/ClientGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.ClientGroup>> GetClientGroup(int id)
        {
            var clientGroup = PublicApi.v1.Mappers.ClientGroupMapper.MapFromInternal(
                await _bll.ClientGroups.FindAsync(id));

            if (clientGroup == null)
            {
                return NotFound();
            }

            return clientGroup;
        }

        // PUT: api/ClientGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientGroup(int id, PublicApi.v1.DTO.ClientGroup clientGroup)
        {
            if (id != clientGroup.Id)
            {
                return BadRequest();
            }

            _bll.ClientGroups.Update(PublicApi.v1.Mappers.ClientGroupMapper.MapFromExternal(clientGroup));
            await _bll.SaveChangesAsync();
           
            return NoContent();
        }

        // POST: api/ClientGroups
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.ClientGroup>> PostClientGroup(PublicApi.v1.DTO.ClientGroup clientGroup)
        {
            clientGroup = PublicApi.v1.Mappers.ClientGroupMapper.MapFromInternal(
                _bll.ClientGroups.Add(PublicApi.v1.Mappers.ClientGroupMapper.MapFromExternal(clientGroup)));
            
            await _bll.SaveChangesAsync();

            clientGroup = PublicApi.v1.Mappers.ClientGroupMapper.MapFromInternal(
                _bll.ClientGroups.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.ClientGroupMapper.MapFromExternal(clientGroup)));
            
            return CreatedAtAction("GetClientGroup", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = clientGroup.Id
            }, clientGroup);
        }

        // DELETE: api/ClientGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.ClientGroup>> DeleteClientGroup(int id)
        {
            var clientGroup = await _bll.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            _bll.ClientGroups.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
