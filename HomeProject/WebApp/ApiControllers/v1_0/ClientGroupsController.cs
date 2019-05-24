using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    /// <summary>
    /// Represents a RESTful client groups service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ClientGroupsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        
        /// <summary>
        /// Client groups controller.
        /// </summary>
        /// <param name="bll"></param>
        public ClientGroupsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        /// <summary>
        /// Get all client groups.
        /// </summary>
        /// <returns>All client groups with clients count.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.ClientGroupWithClientCount>>> GetClientGroups()
        {
           return (await _bll.ClientGroups.GetAllWithClientCountAsync())
               .Select(e =>
                   PublicApi.v1.Mappers.ClientGroupMapper.MapFromInternal(e))
               .ToList();
        }

        /// <summary>
        /// Gets single client group.
        /// </summary>
        /// <param name="id">Identifier for client group.</param>
        /// <returns>Requested client group.</returns>
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

        /// <summary>
        /// Updates client group.
        /// </summary>
        /// <param name="id">Identifier for client group.</param>
        /// <param name="clientGroup">Client group which is updated.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Create new client group.
        /// </summary>
        /// <param name="clientGroup"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete client group.
        /// </summary>
        /// <param name="id">Identifier for client group.</param>
        /// <returns></returns>
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
