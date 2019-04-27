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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AppUsersInPositionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AppUsersInPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AppUsersInPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserInPosition>>> GetAppUsersInPositions()
        {
            var res = await _bll.AppUsersInPositions.AllAsync();
            return Ok(res);
        }

        // GET: api/AppUsersInPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserInPosition>> GetAppUserInPosition(int id)
        {
            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id);

            if (appUserInPosition == null)
            {
                return NotFound();
            }

            return appUserInPosition;
        }

        // PUT: api/AppUsersInPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserInPosition(int id, AppUserInPosition appUserInPosition)
        {
            if (id != appUserInPosition.Id)
            {
                return BadRequest();
            }

            _bll.AppUsersInPositions.Update(appUserInPosition);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AppUsersInPositions
        [HttpPost]
        public async Task<ActionResult<AppUserInPosition>> PostAppUserInPosition(AppUserInPosition appUserInPosition)
        {
            await _bll.AppUsersInPositions.AddAsync(appUserInPosition);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAppUserInPosition", new { id = appUserInPosition.Id }, appUserInPosition);
        }

        // DELETE: api/AppUsersInPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppUserInPosition(int id)
        {
            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id);
            if (appUserInPosition == null)
            {
                return NotFound();
            }

            _bll.AppUsersInPositions.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
