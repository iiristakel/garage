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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PaymentMethodsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodDTO>>> GetPaymentMethods()
        {
            var res = await _bll.PaymentMethods.GetAllWithPaymentsCountAsync();
            return Ok(res);
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(int id)
        {
            var paymentMethod = await _bll.PaymentMethods.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return paymentMethod;
        }

        // PUT: api/PaymentMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return BadRequest();
            }

            _bll.PaymentMethods.Update(paymentMethod);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/PaymentMethods
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethod(PaymentMethod paymentMethod)
        {
            await _bll.PaymentMethods.AddAsync(paymentMethod);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPaymentMethod", new { id = paymentMethod.Id }, paymentMethod);
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaymentMethod(int id)
        {
            var paymentMethod = await _bll.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            _bll.PaymentMethods.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
