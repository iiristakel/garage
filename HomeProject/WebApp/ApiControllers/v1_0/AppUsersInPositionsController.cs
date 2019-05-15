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
    /// <summary>
    /// Represents a RESTful app users in positions service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppUsersInPositionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// App users in positions controller.
        /// </summary>
        /// <param name="bll"></param>
        public AppUsersInPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all app users with positions for logged in user.
        /// </summary>
        /// <returns>All app users with positions for current user.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.AppUserInPosition>>> GetAppUsersInPositions()
        {
            return (await _bll.AppUsersInPositions.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.AppUserInPositionMapper.MapFromInternal(e))
                .ToList();        }

        /// <summary>
        /// Get single app user with its position.
        /// </summary>
        /// <param name="id">Identifier for requested user with position.</param>
        /// <returns>Requested app user with its position.</returns>
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

        /// <summary>
        /// Update single app user's position.
        /// </summary>
        /// <param name="id">Identifier for requested user with position.</param>
        /// <param name="appUserInPosition">Object to update.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gives app user a new position.
        /// </summary>
        /// <param name="appUserInPosition"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Removes position from app user.
        /// </summary>
        /// <param name="id">Identifier for requested user with position.</param>
        /// <returns></returns>
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
