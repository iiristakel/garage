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

    public class AppUsersInPositionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AppUsersInPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AppUsersInPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.AppUserInPosition>>> GetAppUsersInPositions()
        {
            return (await _bll.AppUsersInPositions.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.AppUserInPositionMapper.MapFromInternal(e))
                .ToList();        }

        // GET: api/AppUsersInPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserInPosition>> GetAppUserInPosition(int id)
        {
            var appUserInPosition = PublicApi.v1.Mappers.AppUserInPositionMapper.MapFromInternal(
                await _bll.AppUsersInPositions.FindForUserAsync(id, User.GetUserId()));

            if (appUserInPosition == null)
            {
                return NotFound();
            }

            return appUserInPosition;
        }

        // PUT: api/AppUsersInPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserInPosition(int id, PublicApi.v1.DTO.AppUserInPosition appUserInPosition)
        {
            if (id != appUserInPosition.Id)
            {
                return BadRequest();
            }

            if (!await _bll.AppUsersInPositions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.AppUsersInPositions.Update(PublicApi.v1.Mappers.AppUserInPositionMapper
                .MapFromExternal(appUserInPosition));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AppUsersInPositions
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserInPosition>> PostAppUserInPosition(
            PublicApi.v1.DTO.AppUserInPosition appUserInPosition)
        {
            if (!await _bll.AppUsers.BelongsToUserAsync(appUserInPosition.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            
            appUserInPosition = PublicApi.v1.Mappers.AppUserInPositionMapper.MapFromInternal(
                _bll.AppUsersInPositions.Add(PublicApi.v1.Mappers.AppUserInPositionMapper
                    .MapFromExternal(appUserInPosition)));
            
            await _bll.SaveChangesAsync();
            
            appUserInPosition = PublicApi.v1.Mappers.AppUserInPositionMapper.MapFromInternal(
                _bll.AppUsersInPositions.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.AppUserInPositionMapper.MapFromExternal(appUserInPosition)));

            return CreatedAtAction("GetAppUserInPosition", 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = appUserInPosition.Id
                }, appUserInPosition);
        }

        // DELETE: api/AppUsersInPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserInPosition>> DeleteAppUserInPosition(int id)
        {
            if (!await _bll.AppUsersInPositions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.AppUsersInPositions.Remove(id);
            
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
