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
    public class PaymentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.Payment>>> GetPayments()
        {
            return await _bll.Payments.AllForUserAsync(User.GetUserId());
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Payment>> GetPayment(int id)
        {
            var payment = await _bll.Payments.FindForUserAsync(id, User.GetUserId());

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, BLL.App.DTO.Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }
            
            if (!await _bll.Payments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Payments.Update(payment);
            await _bll.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.Payment>> PostPayment(BLL.App.DTO.Payment payment)
        {
            if (!await _bll.AppUsers.BelongsToUserAsync(payment.Bill.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Payments.Add(payment);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(int id)
        {
            if (!await _bll.Payments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Payments.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
