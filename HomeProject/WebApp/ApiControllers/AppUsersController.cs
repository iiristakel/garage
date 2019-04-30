using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.Identity.AppUser>>> GetAppUsers()
        {
            return await _bll.AppUsers.AllForUserAsync(User.GetUserId());
             
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Identity.AppUser>> GetAppUser(int id)
        {
            var appUser = await _bll.AppUsers.FindForUserAsync(id, User.GetUserId());

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, BLL.App.DTO.Identity.AppUser appUser)
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
            
            _bll.AppUsers.Update(appUser);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AppUsers
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.Identity.AppUser>> 
            PostAppUser(BLL.App.DTO.Identity.AppUser appUser)
        {
            appUser.Id = User.GetUserId();
            
            _bll.AppUsers.Add(appUser);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
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
