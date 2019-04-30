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
    public class ClientsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ClientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.ClientWithProductsCount>>> GetClients()
        {
            return await _bll.Clients.GetAllWithProductsCountAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Client>> GetClient(int id)
        {
            var client = await _bll.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, BLL.App.DTO.Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _bll.Clients.Update(client);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.Client>> PostClient(BLL.App.DTO.Client client)
        {
            await _bll.Clients.AddAsync(client);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Client>> DeleteClient(int id)
        {
            var client = await _bll.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _bll.Clients.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
