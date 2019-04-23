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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class WorkersPositionsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public WorkersPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/WorkersPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerPositionDTO>>> GetWorkersPositions()
        {
            return Ok(await _bll.WorkersPositions.GetAllWithWorkersCountAsync());
        }

        // GET: api/WorkersPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerPosition>> GetWorkerPosition(int id)
        {
            var workerPosition = await _bll.WorkersPositions.FindAsync(id);

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

            _bll.WorkersPositions.Update(workerPosition);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/WorkersPositions
        [HttpPost]
        public async Task<ActionResult<WorkerPosition>> PostWorkerPosition(WorkerPosition workerPosition)
        {
            await _bll.WorkersPositions.AddAsync(workerPosition);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetWorkerPosition", new {id = workerPosition.Id}, workerPosition);
        }

        // DELETE: api/WorkersPositions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkerPosition(int id)
        {
            var workerPosition = await _bll.WorkersPositions.FindAsync(id);
            if (workerPosition == null)
            {
                return NotFound();
            }

            _bll.WorkersPositions.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}