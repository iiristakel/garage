using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WorkObjectsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public WorkObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/WorkObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.WorkObject>>> GetWorkObjects()
        {
            return (await _bll.WorkObjects.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(e))
                .ToList();        }

        // GET: api/WorkObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.WorkObject>> GetWorkObject(int id)
        {
            var workObject = PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(
                await _bll.WorkObjects.FindForUserAsync(id, User.GetUserId()));
            
            if (workObject == null)
            {
                return NotFound();
            }

            return workObject;
        }

        // PUT: api/WorkObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkObject(int id, PublicApi.v1.DTO.WorkObject workObject)
        {
            if (id != workObject.Id)
            {
                return BadRequest();
            }
            
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.WorkObjects.Update(PublicApi.v1.Mappers.WorkObjectMapper.MapFromExternal(workObject));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/WorkObjects
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.WorkObject>> PostWorkObject(
            PublicApi.v1.DTO.WorkObject workObject)
        {
            if (!await _bll.WorkObjects.BelongsToUserAsync(workObject.Id, User.GetUserId()))
            {
                return NotFound();
            }

            workObject = PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(
                _bll.WorkObjects.Add(PublicApi.v1.Mappers.WorkObjectMapper.MapFromExternal(workObject)));

            await _bll.SaveChangesAsync();
            
            workObject = PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(
                _bll.WorkObjects.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.WorkObjectMapper.MapFromExternal(workObject)));

            return CreatedAtAction("GetWorkObject", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = workObject.Id
            }, workObject);
        }

        // DELETE: api/WorkObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.WorkObject>> DeleteWorkObject(int id)
        {
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.WorkObjects.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}