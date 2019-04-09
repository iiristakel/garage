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

    public class WorkersInPositionsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public WorkersInPositionsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/WorkersInPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerInPosition>>> GetWorkersInPositions()
        {
            var res = await _uow.WorkersInPositions.AllAsync();
            return Ok(res);
        }

        // GET: api/WorkersInPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerInPosition>> GetWorkerInPosition(int id)
        {
            var workerInPosition = await _uow.WorkersInPositions.FindAsync(id);

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

            _uow.WorkersInPositions.Update(workerInPosition);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/WorkersInPositions
        [HttpPost]
        public async Task<ActionResult<WorkerInPosition>> PostWorkerInPosition(WorkerInPosition workerInPosition)
        {
            await _uow.WorkersInPositions.AddAsync(workerInPosition);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetWorkerInPosition", new { id = workerInPosition.Id }, workerInPosition);
        }

        // DELETE: api/WorkersInPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkerInPosition>> DeleteWorkerInPosition(int id)
        {
            var workerInPosition = await _uow.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }

            _uow.WorkersInPositions.Remove(workerInPosition);
            await _uow.SaveChangesAsync();

            return workerInPosition;
        }
    }
}
