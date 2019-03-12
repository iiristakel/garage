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
    public class WorkObjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkObjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkObject>>> GetWorkObjects()
        {
            return await _context.WorkObjects.ToListAsync();
        }

        // GET: api/WorkObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkObject>> GetWorkObject(int id)
        {
            var workObject = await _context.WorkObjects.FindAsync(id);

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

            _context.Entry(workObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkObjectExists(id))
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

        // POST: api/WorkObjects
        [HttpPost]
        public async Task<ActionResult<WorkObject>> PostWorkObject(WorkObject workObject)
        {
            _context.WorkObjects.Add(workObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkObject", new { id = workObject.Id }, workObject);
        }

        // DELETE: api/WorkObjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkObject>> DeleteWorkObject(int id)
        {
            var workObject = await _context.WorkObjects.FindAsync(id);
            if (workObject == null)
            {
                return NotFound();
            }

            _context.WorkObjects.Remove(workObject);
            await _context.SaveChangesAsync();

            return workObject;
        }

        private bool WorkObjectExists(int id)
        {
            return _context.WorkObjects.Any(e => e.Id == id);
        }
    }
}
