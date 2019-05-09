using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    /// <summary>
    /// Represents a RESTful payments service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Payments controller.
        /// </summary>
        /// <param name="bll"></param>
        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all payments.
        /// </summary>
        /// <returns>All payments for current user.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Payment>>> GetPayments()
        {
            return (await _bll.Payments.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.PaymentMapper.MapFromInternal(e))
                .ToList();
        }

        /// <summary>
        /// Get single payment.
        /// </summary>
        /// <param name="id">Identifier for payment.</param>
        /// <returns>Requested payment.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Payment>> GetPayment(int id)
        {
            var payment = PublicApi.v1.Mappers.PaymentMapper.MapFromInternal(
                await _bll.Payments.FindForUserAsync(id, User.GetUserId()));

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        /// <summary>
        /// Update payment.
        /// </summary>
        /// <param name="id">Identifier for payment.</param>
        /// <param name="payment">Payment which is updated.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, PublicApi.v1.DTO.Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }
            
            if (!await _bll.Payments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Payments.Update(PublicApi.v1.Mappers.PaymentMapper.MapFromExternal(payment));
            await _bll.SaveChangesAsync();
            

            return NoContent();
        }

        /// <summary>
        /// Create new payment.
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Payment>> PostPayment(PublicApi.v1.DTO.Payment payment)
        {
            if (!await _bll.Payments.BelongsToUserAsync(payment.Bill.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            
            payment = PublicApi.v1.Mappers.PaymentMapper.MapFromInternal(
                _bll.Payments.Add(PublicApi.v1.Mappers.PaymentMapper.MapFromExternal(payment)));

            await _bll.SaveChangesAsync();
            
            payment = PublicApi.v1.Mappers.PaymentMapper.MapFromInternal(
                _bll.Payments.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.PaymentMapper.MapFromExternal(payment)));


            return CreatedAtAction("GetPayment", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = payment.Id
            }, payment);
        }

        /// <summary>
        /// Delete payment.
        /// </summary>
        /// <param name="id">Identifier for payment.</param>
        /// <returns></returns>
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
