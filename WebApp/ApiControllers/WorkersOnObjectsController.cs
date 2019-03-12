using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly AppDbContext _context;

        public WorkersOnObjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkersOnObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerOnObject>>> GetWorkersOnObjects()
        {
            return await _context.WorkersOnObjects.ToListAsync();
        }

        // GET: api/WorkersOnObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerOnObject>> GetWorkerOnObject(int id)
        {
            var workerOnObject = await _context.WorkersOnObjects.FindAsync(id);

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

            _context.Entry(workerOnObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerOnObjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkersOnObjects
        [HttpPost]
        public async Task<ActionResult<WorkerOnObject>> PostWorkerOnObject(WorkerOnObject workerOnObject)
        {
            _context.WorkersOnObjects.Add(workerOnObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkerOnObject", new { id = workerOnObject.Id }, workerOnObject);
        }

        // DELETE: api/WorkersOnObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkerOnObject>> DeleteWorkerOnObject(int id)
        {
            var workerOnObject = await _context.WorkersOnObjects.FindAsync(id);
            if (workerOnObject == null)
            {
                return NotFound();
            }

            _context.WorkersOnObjects.Remove(workerOnObject);
            await _context.SaveChangesAsync();

            return workerOnObject;
        }

        private bool WorkerOnObjectExists(int id)
        {
            return _context.WorkersOnObjects.Any(e => e.Id == id);
        }
    }
}
