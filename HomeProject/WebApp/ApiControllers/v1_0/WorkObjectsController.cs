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
    /// Represents a RESTful app users service.
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WorkObjectsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Work objects controller.
        /// </summary>
        /// <param name="bll"></param>
        public WorkObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get all work objects.
        /// </summary>
        /// <returns>All work objects for current user.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.WorkObject>>> GetWorkObjects()
        {
            var  workObjects = (await _bll.WorkObjects.AllForUserAsync(User.GetUserId())) 
                .Select(e => PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(e))
                .ToList();

            foreach (var workObject in workObjects)
            {
                workObject.AppUsersOnObject = (await _bll.AppUsersOnObjects.AllForWorkObjectAsync(workObject.Id))
                    .Select(e => PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromInternal(e))
                    .ToList();
                workObject.ProductsServices = (await _bll.ProductsServices.AllForWorkObjectAsync(workObject.Id))
                    .Select(e => PublicApi.v1.Mappers.ProductServiceMapper.MapFromInternal(e))
                    .ToList();;
            }

            return workObjects;
        }

        /// <summary>
        /// Get single work object.
        /// </summary>
        /// <param name="id">Identifier for product.</param>
        /// <returns>Requested product.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.WorkObject>> GetWorkObject(int id)
        {
            var workObject = PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(
                await _bll.WorkObjects.FindForUserAsync(id, User.GetUserId()));
            
            if (workObject == null)
            {
                return NotFound();
            }
            
            workObject.AppUsersOnObject = (await _bll.AppUsersOnObjects.AllForWorkObjectAsync(workObject.Id))
                .Select(e => PublicApi.v1.Mappers.AppUserOnObjectMapper.MapFromInternal(e))
                .ToList();
            workObject.ProductsServices = (await _bll.ProductsServices.AllForWorkObjectAsync(workObject.Id))
                .Select(e => PublicApi.v1.Mappers.ProductServiceMapper.MapFromInternal(e))
                .ToList();
            workObject.Bills = (await _bll.Bills.AllForWorkObjectAsync(workObject.Id))
                .Select(e => PublicApi.v1.Mappers.BillMapper.MapFromInternal(e))
                .ToList();

            return workObject;
        }

        /// <summary>
        /// Update information about work object.
        /// </summary>
        /// <param name="id">Identifier for work object.</param>
        /// <param name="workObject">Object which is updated.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkObject(int id, PublicApi.v1.DTO.WorkObject workObject)
        {
           
            
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.WorkObjects.Update(PublicApi.v1.Mappers.WorkObjectMapper.MapFromExternal(workObject));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Create new work object.
        /// </summary>
        /// <param name="workObject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.WorkObject>> PostWorkObject(
            PublicApi.v1.DTO.WorkObject workObject)
        {
//            if (!await _bll.WorkObjects.BelongsToUserAsync(workObject.Id, User.GetUserId()))
//            {
//                return NotFound();
//            }

            workObject = PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(
                _bll.WorkObjects.Add(PublicApi.v1.Mappers.WorkObjectMapper.MapFromExternal(workObject)));

            await _bll.SaveChangesAsync();
            
            workObject = PublicApi.v1.Mappers.WorkObjectMapper.MapFromInternal(
                _bll.WorkObjects.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.WorkObjectMapper.MapFromExternal(workObject)));

            return CreatedAtAction("GetWorkObject", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = workObject.Id
            }, workObject);
        }

        /// <summary>
        /// Delete work object.
        /// </summary>
        /// <param name="id">Identifier for work object.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.WorkObject>> DeleteWorkObject(int id)
        {
          
            
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.WorkObjects.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}