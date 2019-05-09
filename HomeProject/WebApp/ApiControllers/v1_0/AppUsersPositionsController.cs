using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    /// <summary>
    /// Represents a RESTful app user positions/workers service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AppUsersPositionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Positions controller.
        /// </summary>
        /// <param name="bll"></param>
        public AppUsersPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all positions with app users count.
        /// </summary>
        /// <returns>All positions with app users count.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.AppUserPositionWithAppUsersCount>>> GetAppUsersPositions()
        {
            return (await _bll.AppUsersPositions.GetAllWithAppUsersCountAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.AppUserPositionMapper.MapFromInternal(e))
                .ToList();
        }

        /// <summary>
        /// Get single position.
        /// </summary>
        /// <param name="id">Requested position identifier.</param>
        /// <returns>Requested position.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserPosition>> GetAppUserPosition(int id)
        {
            var appUserPosition = PublicApi.v1.Mappers.AppUserPositionMapper.MapFromInternal(
                await _bll.AppUsersPositions.FindAsync(id));

            if (appUserPosition == null)
            {
                return NotFound();
            }

            return appUserPosition;
        }

        /// <summary>
        /// Update position.
        /// </summary>
        /// <param name="id">Identifier for position. </param>
        /// <param name="appUserPosition">Object which is updated.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserPosition(int id, 
            PublicApi.v1.DTO.AppUserPosition appUserPosition)
        {
            if (id != appUserPosition.Id)
            {
                return BadRequest();
            }

            _bll.AppUsersPositions.Update(PublicApi.v1.Mappers.AppUserPositionMapper.MapFromExternal(appUserPosition));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        /// <summary>
        /// Create new position.
        /// </summary>
        /// <param name="appUserPosition"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserPosition>> PostAppUserPosition(
            PublicApi.v1.DTO.AppUserPosition appUserPosition)
        {
            appUserPosition = PublicApi.v1.Mappers.AppUserPositionMapper.MapFromInternal(
                _bll.AppUsersPositions.Add(PublicApi.v1.Mappers.AppUserPositionMapper.MapFromExternal(appUserPosition)));

            await _bll.SaveChangesAsync();
            
            appUserPosition = PublicApi.v1.Mappers.AppUserPositionMapper.MapFromInternal(
                _bll.AppUsersPositions.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.AppUserPositionMapper.MapFromExternal(appUserPosition)));


            return CreatedAtAction("GetAppUserPosition", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = appUserPosition.Id
            }, appUserPosition);
        }

        /// <summary>
        /// Delete position.
        /// </summary>
        /// <param name="id">Identifier for position.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserPosition>> DeleteAppUserPosition(int id)
        {
            var appUserPosition = await _bll.AppUsersPositions.FindAsync(id);
            if (appUserPosition == null)
            {
                return NotFound();
            }

            _bll.AppUsersPositions.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}