using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using DAL.App.DTO;
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
        private readonly IAppUnitOfWork _uow;

        public ClientGroupsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ClientGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientGroupDTO>>> GetClientGroups()
        {
            var res = await _uow.ClientGroups.GetAllWithClientCountAsync();
            return Ok(res);
        }

        // GET: api/ClientGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientGroup>> GetClientGroup(int id)
        {
            var clientGroup = await _uow.ClientGroups.FindAsync(id);

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

            _uow.ClientGroups.Update(clientGroup);
            await _uow.SaveChangesAsync();
           
            return NoContent();
        }

        // POST: api/ClientGroups
        [HttpPost]
        public async Task<ActionResult<ClientGroup>> PostClientGroup(ClientGroup clientGroup)
        {
            await _uow.ClientGroups.AddAsync(clientGroup);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetClientGroup", new { id = clientGroup.Id }, clientGroup);
        }

        // DELETE: api/ClientGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientGroup>> DeleteClientGroup(int id)
        {
            var clientGroup = await _uow.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            _uow.ClientGroups.Remove(clientGroup);
            await _uow.SaveChangesAsync();

            return clientGroup;
        }

    }
}
