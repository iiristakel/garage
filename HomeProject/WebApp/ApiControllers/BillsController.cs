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
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BillsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public BillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.Bill>>> GetBills()
        {
            return await _bll.Bills.AllForUserAsync(User.GetUserId());
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Bill>> GetBill(int id)
        {
            var bill = await _bll.Bills.FindForUserAsync(id, User.GetUserId());

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, BLL.App.DTO.Bill bill)
        {
            if (id != bill.Id)
            {
                return BadRequest();
            }

            
            if (!await _bll.Bills.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Bills.Update(bill);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Bills
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.Bill>> PostBill(BLL.App.DTO.Bill bill)
        {
            if (!await _bll.AppUsers.BelongsToUserAsync(bill.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            _bll.Bills.Add(bill);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Bill>> DeleteBill(int id)
        {
            if (!await _bll.Bills.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Bills.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
