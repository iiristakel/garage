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
    /// Represents a RESTful bills service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BillsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Bills controller.
        /// </summary>
        /// <param name="bll"></param>
        public BillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all bills for current user.
        /// </summary>
        /// <returns>All bills for current user.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Bill>>> GetBills()
        {
            return (await _bll.Bills.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.BillMapper.MapFromInternal(e))
                .ToList();
        }

        /// <summary>
        /// Get single bill.
        /// </summary>
        /// <param name="id">Identifier for requested bill.</param>
        /// <returns>Requested bill.</returns>
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

        /// <summary>
        /// Update bill.
        /// </summary>
        /// <param name="id">Identifier for bill.</param>
        /// <param name="bill">Bill which is updated.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Create new bill.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Bill>> PostBill(PublicApi.v1.DTO.Bill bill)
        {
            if (!await _bll.Bills.BelongsToUserAsync(bill.Id, User.GetUserId()))
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

        /// <summary>
        /// Delete bill.
        /// </summary>
        /// <param name="id">Identifier for bill.</param>
        /// <returns></returns>
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
