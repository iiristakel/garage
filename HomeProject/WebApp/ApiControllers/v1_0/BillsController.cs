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
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Bill>>> GetBills()
        {
            return (await _bll.Bills.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.BillMapper.MapFromInternal(e))
                .ToList();
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Bill>> GetBill(int id)
        {
            var bill = PublicApi.v1.Mappers.BillMapper.MapFromInternal(
                await _bll.Bills.FindForUserAsync(id, User.GetUserId()));

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }

        // PUT: api/Bills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, PublicApi.v1.DTO.Bill bill)
        {
            if (id != bill.Id)
            {
                return BadRequest();
            }

            
            if (!await _bll.Bills.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Bills.Update(PublicApi.v1.Mappers.BillMapper.MapFromExternal(bill));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Bills
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Bill>> PostBill(PublicApi.v1.DTO.Bill bill)
        {
            if (!await _bll.AppUsers.BelongsToUserAsync(bill.AppUserId, User.GetUserId()))
            {
                return NotFound();
            }
            
            bill = PublicApi.v1.Mappers.BillMapper.MapFromInternal(
                _bll.Bills.Add(PublicApi.v1.Mappers.BillMapper.MapFromExternal(bill)));
            
            await _bll.SaveChangesAsync();

            bill = PublicApi.v1.Mappers.BillMapper.MapFromInternal(
                _bll.Bills.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.BillMapper.MapFromExternal(bill)));
            
            return CreatedAtAction("GetBill", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = bill.Id
            }, bill);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Bill>> DeleteBill(int id)
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
