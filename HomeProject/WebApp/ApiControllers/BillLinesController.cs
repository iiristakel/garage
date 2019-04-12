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
    public class BillLinesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public BillLinesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/BillLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillLineDTO>>> GetBillLines()
        {
            var res = await _uow.BillLines.GetAllAsync();
            return Ok(res);
        }

        // GET: api/BillLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillLine>> GetBillLine(int id)
        {
            var billLine = await _uow.BillLines.FindAsync(id);

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

            _uow.BillLines.Update(billLine);
            await _uow.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/BillLines
        [HttpPost]
        public async Task<ActionResult<BillLine>> PostBillLine(BillLine billLine)
        {
            await _uow.BillLines.AddAsync(billLine);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetBillLine", new {id = billLine.Id}, billLine);
        }

        // DELETE: api/BillLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillLine>> DeleteBillLine(int id)
        {
            var billLine = await _uow.BillLines.FindAsync(id);
            if (billLine == null)
            {
                return NotFound();
            }

            _uow.BillLines.Remove(billLine);
            await _uow.SaveChangesAsync();

            return billLine;
        }
    }
}