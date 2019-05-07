using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<ActionResult<IEnumerable<
            PublicApi.v1.DTO.PaymentMethodWithPaymentsCount>>> GetPaymentMethods()
        {
            return (await _bll.PaymentMethods.GetAllWithPaymentsCountAsync())
                .Select(e =>
                    PublicApi.v1.Mappers.PaymentMethodMapper.MapFromInternal(e))
                .ToList();
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.PaymentMethod>> GetPaymentMethod(int id)
        {
            var paymentMethod = PublicApi.v1.Mappers.PaymentMethodMapper.MapFromInternal(
                await _bll.PaymentMethods.FindAsync(id));

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return paymentMethod;
        }

        // PUT: api/PaymentMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, 
            PublicApi.v1.DTO.PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return BadRequest();
            }

            _bll.PaymentMethods.Update(PublicApi.v1.Mappers.PaymentMethodMapper.MapFromExternal(paymentMethod));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/PaymentMethods
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.PaymentMethod>> PostPaymentMethod(
            PublicApi.v1.DTO.PaymentMethod paymentMethod)
        {
            paymentMethod = PublicApi.v1.Mappers.PaymentMethodMapper.MapFromInternal(
                _bll.PaymentMethods.Add(PublicApi.v1.Mappers.PaymentMethodMapper.MapFromExternal(paymentMethod)));

            await _bll.SaveChangesAsync();
            
            paymentMethod = PublicApi.v1.Mappers.PaymentMethodMapper.MapFromInternal(
                _bll.PaymentMethods.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.PaymentMethodMapper.MapFromExternal(paymentMethod)));


            return CreatedAtAction("GetPaymentMethod", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = paymentMethod.Id
            }, paymentMethod);
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.PaymentMethod>> DeletePaymentMethod(int id)
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
