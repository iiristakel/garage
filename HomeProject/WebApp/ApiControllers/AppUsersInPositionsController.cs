using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.AppUserInPosition>>> GetAppUsersInPositions()
        {
            return await _bll.AppUsersInPositions.AllForUserAsync(User.GetUserId());
        }

        // GET: api/AppUsersInPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.AppUserInPosition>> GetAppUserInPosition(int id)
        {
            var appUserInPosition = await _bll.AppUsersInPositions.FindForUserAsync(id, User.GetUserId());

            if (appUserInPosition == null)
            {
                return NotFound();
            }

            return appUserInPosition;
        }

        // PUT: api/AppUsersInPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserInPosition(int id, BLL.App.DTO.AppUserInPosition appUserInPosition)
        {
            if (id != appUserInPosition.Id)
            {
                return BadRequest();
            }

            if (!await _bll.AppUsersInPositions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.AppUsersInPositions.Update(appUserInPosition);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AppUsersInPositions
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.AppUserInPosition>> PostAppUserInPosition(
            BLL.App.DTO.AppUserInPosition appUserInPosition)
        {
            if (!await _bll.AppUsers.BelongsToUserAsync(appUserInPosition.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.AppUsersInPositions.Add(appUserInPosition);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAppUserInPosition", 
                new { id = appUserInPosition.Id }, appUserInPosition);
        }

        // DELETE: api/AppUsersInPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.AppUserInPosition>> DeleteAppUserInPosition(int id)
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
