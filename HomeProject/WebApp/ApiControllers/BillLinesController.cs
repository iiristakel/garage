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
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using BillLine = DAL.App.DTO.BillLine;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BillLinesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public BillLinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/BillLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.BillLine>>> GetBillLines()
        {
            return await _bll.BillLines.AllForUserAsync(User.GetUserId());
        }

        // GET: api/BillLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.BillLine>> GetBillLine(int id)
        {
            var billLine = await _bll.BillLines.FindForUserAsync(id, User.GetUserId());

            if (billLine == null)
            {
                return NotFound();
            }

            return billLine;
        }

        // PUT: api/BillLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillLine(int id, BLL.App.DTO.BillLine billLine)
        {
            if (id != billLine.Id)
            {
                return BadRequest();
            }

            if (!await _bll.BillLines.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.BillLines.Update(billLine);
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/BillLines
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.BillLine>> PostBillLine(
            BLL.App.DTO.BillLine billLine)
        {
            if (!await _bll.AppUsers.BelongsToUserAsync(billLine.Bill.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.BillLines.Add(billLine);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetBillLine", new {id = billLine.Id}, billLine);
        }

        // DELETE: api/BillLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.BillLine>> DeleteBillLine(int id)
        {
            if (!await _bll.BillLines.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.BillLines.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}