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
    public class BillLinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BillLinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BillLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillLine>>> GetBillLines()
        {
            return await _context.BillLines.ToListAsync();
        }

        // GET: api/BillLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillLine>> GetBillLine(int id)
        {
            var billLine = await _context.BillLines.FindAsync(id);

            if (billLine == null)
            {
                return NotFound();
            }

            return billLine;
        }

        // PUT: api/BillLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillLine(int id, BillLine billLine)
        {
            if (id != billLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(billLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillLineExists(id))
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

        // POST: api/BillLines
        [HttpPost]
        public async Task<ActionResult<BillLine>> PostBillLine(BillLine billLine)
        {
            _context.BillLines.Add(billLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillLine", new { id = billLine.Id }, billLine);
        }

        // DELETE: api/BillLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillLine>> DeleteBillLine(int id)
        {
            var billLine = await _context.BillLines.FindAsync(id);
            if (billLine == null)
            {
                return NotFound();
            }

            _context.BillLines.Remove(billLine);
            await _context.SaveChangesAsync();

            return billLine;
        }

        private bool BillLineExists(int id)
        {
            return _context.BillLines.Any(e => e.Id == id);
        }
    }
}
