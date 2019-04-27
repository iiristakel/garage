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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersOnObjectsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AppUsersOnObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AppUsersOnObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserOnObject>>> GetAppUsersOnObjects()
        {
            var res = await _bll.AppUsersOnObjects.AllAsync();
            return Ok(res);
        }

        // GET: api/AppUsersOnObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserOnObject>> GetAppUserOnObject(int id)
        {
            var appUserOnObject = await _bll.AppUsersOnObjects.FindAsync(id);

            if (appUserOnObject == null)
            {
                return NotFound();
            }

            return appUserOnObject;
        }

        // PUT: api/AppUsersOnObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserOnObject(int id, AppUserOnObject appUserOnObject)
        {
            if (id != appUserOnObject.Id)
            {
                return BadRequest();
            }

            _bll.AppUsersOnObjects.Update(appUserOnObject);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AppUsersOnObjects
        [HttpPost]
        public async Task<ActionResult<AppUserOnObject>> PostAppUserOnObject(AppUserOnObject appUserOnObject)
        {
            await _bll.AppUsersOnObjects.AddAsync(appUserOnObject);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAppUserOnObject", new {id = appUserOnObject.Id}, appUserOnObject);
        }

        // DELETE: api/AppUsersOnObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppUserOnObject(int id)
        {
            var appUserOnObject = await _bll.AppUsersOnObjects.FindAsync(id);
            if (appUserOnObject == null)
            {
                return NotFound();
            }

            _bll.AppUsersOnObjects.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}