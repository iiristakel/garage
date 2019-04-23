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
    public class WorkersOnObjectsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public WorkersOnObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/WorkersOnObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerOnObject>>> GetWorkersOnObjects()
        {
            var res = await _bll.WorkersOnObjects.AllAsync();
            return Ok(res);
        }

        // GET: api/WorkersOnObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerOnObject>> GetWorkerOnObject(int id)
        {
            var workerOnObject = await _bll.WorkersOnObjects.FindAsync(id);

            if (workerOnObject == null)
            {
                return NotFound();
            }

            return workerOnObject;
        }

        // PUT: api/WorkersOnObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkerOnObject(int id, WorkerOnObject workerOnObject)
        {
            if (id != workerOnObject.Id)
            {
                return BadRequest();
            }

            _bll.WorkersOnObjects.Update(workerOnObject);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/WorkersOnObjects
        [HttpPost]
        public async Task<ActionResult<WorkerOnObject>> PostWorkerOnObject(WorkerOnObject workerOnObject)
        {
            await _bll.WorkersOnObjects.AddAsync(workerOnObject);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetWorkerOnObject", new {id = workerOnObject.Id}, workerOnObject);
        }

        // DELETE: api/WorkersOnObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkerOnObject(int id)
        {
            var workerOnObject = await _bll.WorkersOnObjects.FindAsync(id);
            if (workerOnObject == null)
            {
                return NotFound();
            }

            _bll.WorkersOnObjects.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}