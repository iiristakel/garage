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
    public class WorkersInPositionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkersInPositionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkersInPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerInPosition>>> GetWorkersInPositions()
        {
            return await _context.WorkersInPositions.ToListAsync();
        }

        // GET: api/WorkersInPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerInPosition>> GetWorkerInPosition(int id)
        {
            var workerInPosition = await _context.WorkersInPositions.FindAsync(id);

            if (workerInPosition == null)
            {
                return NotFound();
            }

            return workerInPosition;
        }

        // PUT: api/WorkersInPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkerInPosition(int id, WorkerInPosition workerInPosition)
        {
            if (id != workerInPosition.Id)
            {
                return BadRequest();
            }

            _context.Entry(workerInPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerInPositionExists(id))
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

        // POST: api/WorkersInPositions
        [HttpPost]
        public async Task<ActionResult<WorkerInPosition>> PostWorkerInPosition(WorkerInPosition workerInPosition)
        {
            _context.WorkersInPositions.Add(workerInPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkerInPosition", new { id = workerInPosition.Id }, workerInPosition);
        }

        // DELETE: api/WorkersInPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkerInPosition>> DeleteWorkerInPosition(int id)
        {
            var workerInPosition = await _context.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }

            _context.WorkersInPositions.Remove(workerInPosition);
            await _context.SaveChangesAsync();

            return workerInPosition;
        }

        private bool WorkerInPositionExists(int id)
        {
            return _context.WorkersInPositions.Any(e => e.Id == id);
        }
    }
}
