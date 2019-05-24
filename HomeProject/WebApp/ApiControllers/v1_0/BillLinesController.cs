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
    /// Represents a RESTful bill lines service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BillLinesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Bill lines controller.
        /// </summary>
        /// <param name="bll"></param>
        public BillLinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all bill lines.
        /// </summary>
        /// <returns>All bill lines for user.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.BillLine>>> GetBillLines()
        {
            return (await _bll.BillLines.AllForUserAsync(User.GetUserId()))
                .Select(e =>
                    PublicApi.v1.Mappers.BillLineMapper.MapFromInternal(e))
                .ToList();
        }

        /// <summary>
        /// Get single bill line for user.
        /// </summary>
        /// <param name="id">Requested bill line identifier.</param>
        /// <returns>Requested bill line object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.BillLine>> GetBillLine(int id)
        {
            var billLine = PublicApi.v1.Mappers.BillLineMapper.MapFromInternal(
                await _bll.BillLines.FindForUserAsync(id, User.GetUserId()));

            if (billLine == null)
            {
                return NotFound();
            }

            return billLine;
        }

        
        /// <summary>
        /// Update bill line.
        /// </summary>
        /// <param name="id">Identifier for bill line.</param>
        /// <param name="billLine">Bill line object which is updated.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillLine(int id, PublicApi.v1.DTO.BillLine billLine)
        {
            if (id != billLine.Id)
            {
                return BadRequest();
            }

            if (!await _bll.BillLines.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.BillLines.Update(PublicApi.v1.Mappers.BillLineMapper.MapFromExternal(billLine));
            
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        /// <summary>
        /// Create new bill line.
        /// </summary>
        /// <param name="billLine"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.BillLine>> PostBillLine(
            PublicApi.v1.DTO.BillLine billLine)
        {
            if (!await _bll.BillLines.BelongsToUserAsync(billLine.Id, User.GetUserId()))
            {
                return NotFound();
            }
            
            billLine = PublicApi.v1.Mappers.BillLineMapper.MapFromInternal(
                _bll.BillLines.Add(PublicApi.v1.Mappers.BillLineMapper.MapFromExternal(billLine)));

            await _bll.SaveChangesAsync();
            
            billLine = PublicApi.v1.Mappers.BillLineMapper.MapFromInternal(
                _bll.BillLines.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.BillLineMapper.MapFromExternal(billLine)));


            return CreatedAtAction("GetBillLine", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = billLine.Id
            }, billLine);
        }

        /// <summary>
        /// Delete bill line.
        /// </summary>
        /// <param name="id">Identifier for bill line.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.BillLine>> DeleteBillLine(int id)
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