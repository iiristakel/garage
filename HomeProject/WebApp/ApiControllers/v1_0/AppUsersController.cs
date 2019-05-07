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
    public class AppUsersController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AppUsersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Identity.AppUser>>> GetAppUsers()
        {
            return (await _bll.AppUsers.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.AppUserMapper.MapFromInternal(e))
                .ToList();
             
        }

        // GET: api/AppUsers/5
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

        // PUT: api/AppUsers/5
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

        // POST: api/AppUsers
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

        // DELETE: api/AppUsers/5
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
