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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class WorkersInPositionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public WorkersInPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/WorkersInPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerInPosition>>> GetWorkersInPositions()
        {
            var res = await _bll.WorkersInPositions.AllAsync();
            return Ok(res);
        }

        // GET: api/WorkersInPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerInPosition>> GetWorkerInPosition(int id)
        {
            var workerInPosition = await _bll.WorkersInPositions.FindAsync(id);

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

            _bll.WorkersInPositions.Update(workerInPosition);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/WorkersInPositions
        [HttpPost]
        public async Task<ActionResult<WorkerInPosition>> PostWorkerInPosition(WorkerInPosition workerInPosition)
        {
            await _bll.WorkersInPositions.AddAsync(workerInPosition);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetWorkerInPosition", new { id = workerInPosition.Id }, workerInPosition);
        }

        // DELETE: api/WorkersInPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkerInPosition(int id)
        {
            var workerInPosition = await _bll.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }

            _bll.WorkersInPositions.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
