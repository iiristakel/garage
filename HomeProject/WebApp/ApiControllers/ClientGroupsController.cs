using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
        private readonly IAppBLL _bll;
        
        public ClientGroupsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: api/ClientGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.ClientGroupWithClientCount>>> GetClientGroups()
        {
           return await _bll.ClientGroups.GetAllWithClientCountAsync();
        }

        // GET: api/ClientGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.ClientGroup>> GetClientGroup(int id)
        {
            var clientGroup = await _bll.ClientGroups.FindAsync(id);

            if (clientGroup == null)
            {
                return NotFound();
            }

            return clientGroup;
        }

        // PUT: api/ClientGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientGroup(int id, BLL.App.DTO.ClientGroup clientGroup)
        {
            if (id != clientGroup.Id)
            {
                return BadRequest();
            }

            _bll.ClientGroups.Update(clientGroup);
            await _bll.SaveChangesAsync();
           
            return NoContent();
        }

        // POST: api/ClientGroups
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.ClientGroup>> PostClientGroup(BLL.App.DTO.ClientGroup clientGroup)
        {
            await _bll.ClientGroups.AddAsync(clientGroup);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetClientGroup", new { id = clientGroup.Id }, clientGroup);
        }

        // DELETE: api/ClientGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.ClientGroup>> DeleteClientGroup(int id)
        {
            var clientGroup = await _bll.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            _bll.ClientGroups.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
