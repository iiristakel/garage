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

    public class WorkersPositionsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public WorkersPositionsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/WorkersPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerPosition>>> GetWorkersPositions()
        {
            var res = await _uow.WorkersPositions.AllAsync();
            return Ok(res);
        }

        // GET: api/WorkersPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerPosition>> GetWorkerPosition(int id)
        {
            var workerPosition = await _uow.WorkersPositions.FindAsync(id);

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

            _uow.WorkersPositions.Update(workerPosition);
            await _uow.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/WorkersPositions
        [HttpPost]
        public async Task<ActionResult<WorkerPosition>> PostWorkerPosition(WorkerPosition workerPosition)
        {
            await _uow.WorkersPositions.AddAsync(workerPosition);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetWorkerPosition", new {id = workerPosition.Id}, workerPosition);
        }

        // DELETE: api/WorkersPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkerPosition>> DeleteWorkerPosition(int id)
        {
            var workerPosition = await _uow.WorkersPositions.FindAsync(id);
            if (workerPosition == null)
            {
                return NotFound();
            }

            _uow.WorkersPositions.Remove(workerPosition);
            await _uow.SaveChangesAsync();

            return workerPosition;
        }
    }
}