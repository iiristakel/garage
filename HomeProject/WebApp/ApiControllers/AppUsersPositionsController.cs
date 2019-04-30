using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.DTO;
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

    public class AppUsersPositionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AppUsersPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AppUsersPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.AppUserPositionWithAppUsersCount>>> GetAppUsersPositions()
        {
            return await _bll.AppUsersPositions.GetAllWithAppUsersCountAsync();
        }

        // GET: api/AppUsersPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.AppUserPosition>> GetAppUserPosition(int id)
        {
            var appUserPosition = await _bll.AppUsersPositions.FindAsync(id);

            if (appUserPosition == null)
            {
                return NotFound();
            }

            return appUserPosition;
        }

        // PUT: api/AppUsersPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserPosition(int id, 
            BLL.App.DTO.AppUserPosition appUserPosition)
        {
            if (id != appUserPosition.Id)
            {
                return BadRequest();
            }

            _bll.AppUsersPositions.Update(appUserPosition);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/AppUsersPositions
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.AppUserPosition>> PostAppUserPosition(
            BLL.App.DTO.AppUserPosition appUserPosition)
        {
            await _bll.AppUsersPositions.AddAsync(appUserPosition);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAppUserPosition", new {id = appUserPosition.Id}, appUserPosition);
        }

        // DELETE: api/AppUsersPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.AppUserPosition>> DeleteAppUserPosition(int id)
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