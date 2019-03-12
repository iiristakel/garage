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
    public class ClientGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientGroup>>> GetClientGroups()
        {
            return await _context.ClientGroups.ToListAsync();
        }

        // GET: api/ClientGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientGroup>> GetClientGroup(int id)
        {
            var clientGroup = await _context.ClientGroups.FindAsync(id);

            if (clientGroup == null)
            {
                return NotFound();
            }

            return clientGroup;
        }

        // PUT: api/ClientGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientGroup(int id, ClientGroup clientGroup)
        {
            if (id != clientGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientGroupExists(id))
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

        // POST: api/ClientGroups
        [HttpPost]
        public async Task<ActionResult<ClientGroup>> PostClientGroup(ClientGroup clientGroup)
        {
            _context.ClientGroups.Add(clientGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientGroup", new { id = clientGroup.Id }, clientGroup);
        }

        // DELETE: api/ClientGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientGroup>> DeleteClientGroup(int id)
        {
            var clientGroup = await _context.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            _context.ClientGroups.Remove(clientGroup);
            await _context.SaveChangesAsync();

            return clientGroup;
        }

        private bool ClientGroupExists(int id)
        {
            return _context.ClientGroups.Any(e => e.Id == id);
        }
    }
}
