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
using BillLine = DAL.App.DTO.BillLine;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillLinesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public BillLinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/BillLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillLine>>> GetBillLines()
        {
            var res = await _bll.BillLines.GetAllAsync();
            return Ok(res);
        }

        // GET: api/BillLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.BillLine>> GetBillLine(int id)
        {
            var billLine = await _bll.BillLines.FindAsync(id);

            if (billLine == null)
            {
                return NotFound();
            }

            return billLine;
        }

        // PUT: api/BillLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillLine(int id, Domain.BillLine billLine)
        {
            if (id != billLine.Id)
            {
                return BadRequest();
            }

            _bll.BillLines.Update(billLine);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/BillLines
        [HttpPost]
        public async Task<ActionResult<Domain.BillLine>> PostBillLine(Domain.BillLine billLine)
        {
            await _bll.BillLines.AddAsync(billLine);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetBillLine", new {id = billLine.Id}, billLine);
        }

        // DELETE: api/BillLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBillLine(int id)
        {
            var billLine = await _bll.BillLines.FindAsync(id);
            if (billLine == null)
            {
                return NotFound();
            }

            _bll.BillLines.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}