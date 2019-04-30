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
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppUsersOnObjectsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AppUsersOnObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AppUsersOnObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.AppUserOnObject>>> GetAppUsersOnObjects()
        {
            return await _bll.AppUsersOnObjects.AllForUserAsync(User.GetUserId());
        }

        // GET: api/AppUsersOnObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.AppUserOnObject>> GetAppUserOnObject(int id)
        {
            var appUserOnObject = await _bll.AppUsersOnObjects.FindForUserAsync(id, User.GetUserId());

            if (appUserOnObject == null)
            {
                return NotFound();
            }

            return appUserOnObject;
        }

        // PUT: api/AppUsersOnObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserOnObject(int id, BLL.App.DTO.AppUserOnObject appUserOnObject)
        {
            if (id != appUserOnObject.Id)
            {
                return BadRequest();
            }

            if (!await _bll.AppUsersOnObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            _bll.AppUsersOnObjects.Update(appUserOnObject);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AppUsersOnObjects
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.AppUserOnObject>> PostAppUserOnObject(
            BLL.App.DTO.AppUserOnObject appUserOnObject)
        {
            
            if (!await _bll.AppUsers.BelongsToUserAsync(appUserOnObject.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            _bll.AppUsersOnObjects.Add(appUserOnObject);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAppUserOnObject", new {id = appUserOnObject.Id}, appUserOnObject);
        }

        // DELETE: api/AppUsersOnObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.AppUserOnObject>> DeleteAppUserOnObject(int id)
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