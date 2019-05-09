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
    /// Represents a RESTful app users on objects service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppUsersOnObjectsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Workers on objects controller.
        /// </summary>
        /// <param name="bll"></param>
        public AppUsersOnObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all workers on work objects for logged in app user.
        /// </summary>
        /// <returns>All workers on objects for logged in app user.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.AppUserOnObject>>> GetAppUsersOnObjects()
        {
            return (await _bll.AppUsersOnObjects.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromInternal(e))
                .ToList();        
        }

        /// <summary>
        /// Get single worker with work object.
        /// </summary>
        /// <param name="id">Identifier for requested worker with work object.</param>
        /// <returns>Requested worker with work object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserOnObject>> GetAppUserOnObject(int id)
        {
            var appUserOnObject = PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromInternal(
                await _bll.AppUsersOnObjects.FindForUserAsync(id, User.GetUserId()));

            if (appUserOnObject == null)
            {
                return NotFound();
            }

            return appUserOnObject;
        }

        /// <summary>
        /// Update worker and work object relation.
        /// </summary>
        /// <param name="id">Identifier for requested worker with work object.</param>
        /// <param name="appUserOnObject">Object to update.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserOnObject(int id, PublicApi.v1.DTO.AppUserOnObject appUserOnObject)
        {
            if (id != appUserOnObject.Id)
            {
                return BadRequest();
            }

            if (!await _bll.AppUsersOnObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            _bll.AppUsersOnObjects.Update(PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromExternal(appUserOnObject));
            
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Create new worker and work object relation.
        /// </summary>
        /// <param name="appUserOnObject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserOnObject>> PostAppUserOnObject(
            PublicApi.v1.DTO.AppUserOnObject appUserOnObject)
        {
            
            if (!await _bll.AppUsers.BelongsToUserAsync(appUserOnObject.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            appUserOnObject = PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromInternal(
                _bll.AppUsersOnObjects.Add(PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromExternal(appUserOnObject)));

            await _bll.SaveChangesAsync();
            
            appUserOnObject = PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromInternal(
                _bll.AppUsersOnObjects.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromExternal(appUserOnObject)));


            return CreatedAtAction("GetAppUserOnObject", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = appUserOnObject.Id
            }, appUserOnObject);
        }

        /// <summary>
        /// Deletes relation between worker and work object.
        /// </summary>
        /// <param name="id">Identifier for requested worker with work object.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AppUserOnObject>> DeleteAppUserOnObject(int id)
        {
            if (!await _bll.AppUsersOnObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.AppUsersOnObjects.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}