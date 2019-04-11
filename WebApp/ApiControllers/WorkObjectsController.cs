using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IAppUnitOfWork _uow;

        public WorkObjectsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/WorkObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkObject>>> GetWorkObjects()
        {
            return Ok(await _uow.WorkObjects.GetAllAsync());
        }

        // GET: api/WorkObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkObject>> GetWorkObject(int id)
        {
            var workObject = await _uow.WorkObjects.FindAsync(id);

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

            _uow.WorkObjects.Update(workObject);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/WorkObjects
        [HttpPost]
        public async Task<ActionResult<WorkObject>> PostWorkObject(WorkObject workObject)
        {
            await _uow.WorkObjects.AddAsync(workObject);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetWorkObject", new {id = workObject.Id}, workObject);
        }

        // DELETE: api/WorkObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkObject>> DeleteWorkObject(int id)
        {
            var workObject = await _uow.WorkObjects.FindAsync(id);
            if (workObject == null)
            {
                return NotFound();
            }

            _uow.WorkObjects.Remove(workObject);
            await _uow.SaveChangesAsync();

            return workObject;
        }
    }
}