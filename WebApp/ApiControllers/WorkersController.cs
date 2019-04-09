using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WorkersController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public WorkersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
        {
            var res = await _uow.Workers.AllAsync();
            return Ok(res);
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
            var worker = await _uow.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        // PUT: api/Workers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, Worker worker)
        {
            if (id != worker.Id)
            {
                return BadRequest();
            }

            _uow.Workers.Update(worker);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Workers
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(Worker worker)
        {
            await _uow.Workers.AddAsync(worker);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetWorker", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> DeleteWorker(int id)
        {
            var worker = await _uow.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _uow.Workers.Remove(worker);
            await _uow.SaveChangesAsync();

            return worker;
        }
    }
}
