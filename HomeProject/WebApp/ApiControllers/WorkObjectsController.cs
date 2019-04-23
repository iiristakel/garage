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
    public class WorkObjectsController : ControllerBase
    {
//        private readonly IAppUnitOfWork _bll;
        private readonly IAppBLL _bll;

        public WorkObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/WorkObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkObject>>> GetWorkObjects()
        {
            return Ok(await _bll.WorkObjects.GetAllAsync());
        }

        // GET: api/WorkObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkObject>> GetWorkObject(int id)
        {
            var workObject = await _bll.WorkObjects.FindAsync(id);

            if (workObject == null)
            {
                return NotFound();
            }

            return workObject;
        }

        // PUT: api/WorkObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkObject(int id, WorkObject workObject)
        {
            if (id != workObject.Id)
            {
                return BadRequest();
            }

            _bll.WorkObjects.Update(workObject);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/WorkObjects
        [HttpPost]
        public async Task<ActionResult<WorkObject>> PostWorkObject(WorkObject workObject)
        {
            await _bll.WorkObjects.AddAsync(workObject);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetWorkObject", new {id = workObject.Id}, workObject);
        }

        // DELETE: api/WorkObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkObject(int id)
        {
            var workObject = await _bll.WorkObjects.FindAsync(id);
            if (workObject == null)
            {
                return NotFound();
            }

            _bll.WorkObjects.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}