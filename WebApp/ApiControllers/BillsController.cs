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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public BillsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            var res =  await _uow.Bills.GetAllWithPaymentsCountAsync();
            return Ok(res);
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            var bill = await _uow.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, Bill bill)
        {
            if (id != bill.Id)
            {
                return BadRequest();
            }

            _uow.Bills.Update(bill);
           
                await _uow.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Bills
        [HttpPost]
        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            await _uow.Bills.AddAsync(bill);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(int id)
        {
            var bill = await _uow.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            _uow.Bills.Remove(bill);
            await _uow.SaveChangesAsync();

            return bill;
        }

    }
}
