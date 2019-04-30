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
    public class WorkObjectsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public WorkObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/WorkObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.WorkObject>>> GetWorkObjects()
        {
            return await _bll.WorkObjects.AllForUserAsync(User.GetUserId());
        }

        // GET: api/WorkObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.WorkObject>> GetWorkObject(int id)
        {
            var workObject = await _bll.WorkObjects.FindForUserAsync(id, User.GetUserId());

            if (workObject == null)
            {
                return NotFound();
            }

            return workObject;
        }

        // PUT: api/WorkObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkObject(int id, BLL.App.DTO.WorkObject workObject)
        {
            if (id != workObject.Id)
            {
                return BadRequest();
            }
            
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.WorkObjects.Update(workObject);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/WorkObjects
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.WorkObject>> PostWorkObject(
            BLL.App.DTO.WorkObject workObject)
        {
            //TODO: is it correct? or should be through appusers
            if (!await _bll.WorkObjects.BelongsToUserAsync(workObject.Id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.WorkObjects.Add(workObject);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetWorkObject", new {id = workObject.Id}, workObject);
        }

        // DELETE: api/WorkObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.WorkObject>> DeleteWorkObject(int id)
        {
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.WorkObjects.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}