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
    /// Represents a RESTful app users service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// App users controller.
        /// </summary>
        /// <param name="bll"></param>
        public AppUsersController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all app users for logged in user.
        /// </summary>
        /// <returns> All app users for current user. </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Identity.AppUser>>> GetAppUsers()
        {
            return (await _bll.AppUsers.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.AppUserMapper.MapFromInternal(e))
                .ToList();
             
        }

        /// <summary>
        /// Get single user.
        /// </summary>
        /// <param name="id">Requested user identifier.</param>
        /// <returns> Requested person.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Identity.AppUser>> GetAppUser(int id)
        {
            var appUser = PublicApi.v1.Mappers.AppUserMapper.MapFromInternal(
                await _bll.AppUsers.FindForUserAsync(id, User.GetUserId()));

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        /// <summary>
        /// Update app user.
        /// </summary>
        /// <param name="id">Requested user identifier.</param>
        /// <param name="appUser">App user to update.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, PublicApi.v1.DTO.Identity.AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            if (!await _bll.AppUsers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

//            appUser.Id = User.GetUserId();
            
            _bll.AppUsers.Update(PublicApi.v1.Mappers.AppUserMapper.MapFromExternal(appUser));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Creates new app user.
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Identity.AppUser>> 
            PostAppUser(PublicApi.v1.DTO.Identity.AppUser appUser)
        {
//            appUser.Id = User.GetUserId();
            
            appUser = PublicApi.v1.Mappers.AppUserMapper.MapFromInternal(
                _bll.AppUsers.Add(PublicApi.v1.Mappers.AppUserMapper.MapFromExternal(appUser)));

            await _bll.SaveChangesAsync();
            
            appUser = PublicApi.v1.Mappers.AppUserMapper.MapFromInternal(
                _bll.AppUsers.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.AppUserMapper.MapFromExternal(appUser)));

            return CreatedAtAction("GetAppUser", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = appUser.Id
            }, appUser);
        }

        /// <summary>
        /// Deletes app user.
        /// </summary>
        /// <param name="id">Requested user identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppUser(int id)
        {
            if (!await _bll.AppUsers.BelongsToUserAsync(id, 
                User.GetUserId()))
            {
                return NotFound();
            }

            _bll.AppUsers.Remove(id);
            
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
