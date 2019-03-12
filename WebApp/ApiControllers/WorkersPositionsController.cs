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
    public class WorkersPositionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkersPositionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkersPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerPosition>>> GetWorkersPositions()
        {
            return await _context.WorkersPositions.ToListAsync();
        }

        // GET: api/WorkersPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerPosition>> GetWorkerPosition(int id)
        {
            var workerPosition = await _context.WorkersPositions.FindAsync(id);

            if (workerPosition == null)
            {
                return NotFound();
            }

            return workerPosition;
        }

        // PUT: api/WorkersPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkerPosition(int id, WorkerPosition workerPosition)
        {
            if (id != workerPosition.Id)
            {
                return BadRequest();
            }

            _context.Entry(workerPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerPositionExists(id))
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

        // POST: api/WorkersPositions
        [HttpPost]
        public async Task<ActionResult<WorkerPosition>> PostWorkerPosition(WorkerPosition workerPosition)
        {
            _context.WorkersPositions.Add(workerPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkerPosition", new { id = workerPosition.Id }, workerPosition);
        }

        // DELETE: api/WorkersPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkerPosition>> DeleteWorkerPosition(int id)
        {
            var workerPosition = await _context.WorkersPositions.FindAsync(id);
            if (workerPosition == null)
            {
                return NotFound();
            }

            _context.WorkersPositions.Remove(workerPosition);
            await _context.SaveChangesAsync();

            return workerPosition;
        }

        private bool WorkerPositionExists(int id)
        {
            return _context.WorkersPositions.Any(e => e.Id == id);
        }
    }
}
