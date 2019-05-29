#pragma warning disable 1591
using System.Threading.Tasks;
using Contracts.BLL.App;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllAppUsersInPositionsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllAppUsersInPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: AppUsersInPositions
        public async Task<IActionResult> Index()
        {
            var appUsersInPositions = await _bll.AppUsersInPositions.AllAsync();
            return View(appUsersInPositions);
        }

        // GET: AppUsersInPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id.Value);
            if (appUserInPosition == null)
            {
                return NotFound();
            }

            return View(appUserInPosition);
        }

        // GET: AppUsersInPositions/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var vm = new WebApp.Areas.Admin.ViewModels.AppUserInPositionCreateEditViewModel();
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.AppUsersPositions.AllAsync(), 
                nameof(BLL.App.DTO.AppUserPosition.Id), 
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            
            return View(vm);
        }
        
        

        // POST: AppUsersInPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(WebApp.Areas.Admin.ViewModels.AppUserInPositionCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.AppUsersInPositions.Add(vm.AppUserInPosition);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.AppUsersPositions.AllAsync(), 
                nameof(BLL.App.DTO.AppUserPosition.Id), 
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            
            return View(vm);
        }
        
        // AppUsersInPositions/AddForWorker
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddForAppUser(int appUserId)
        {
            var vm = new WebApp.Areas.Admin.ViewModels.AppUserInPositionCreateEditViewModel();

            vm.AppUser = await  _bll.AppUsers.FindAsync(appUserId); 
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.AppUsersPositions.AllAsync(), 
                nameof(BLL.App.DTO.AppUserPosition.Id), 
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddForAppUser(int appUserId, 
            WebApp.Areas.Admin.ViewModels.AppUserInPositionCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.AppUsersInPositions.Add(vm.AppUserInPosition);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUser = await  _bll.AppUsers.FindAsync(appUserId); 
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.AppUsersPositions.AllAsync(), 
                nameof(BLL.App.DTO.AppUserPosition.Id), 
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            
            return View(vm);
        }

        // GET: AppUsersInPositions/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id.Value);
            if (appUserInPosition == null)
            {
                return NotFound();
            }
            
            var vm = new WebApp.Areas.Admin.ViewModels.AppUserInPositionCreateEditViewModel();
            vm.AppUserInPosition = appUserInPosition;
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.AppUsersPositions.AllAsync(), 
                nameof(BLL.App.DTO.AppUserPosition.Id), 
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            
            return View(vm);
        }

        // POST: AppUsersInPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, WebApp.Areas.Admin.ViewModels.AppUserInPositionCreateEditViewModel vm)
        {
            if (id != vm.AppUserInPosition.Id)
            {
                return NotFound();
            }
            
            if (!await _bll.AppUsersInPositions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _bll.AppUsersInPositions.Update(vm.AppUserInPosition);
                    await _bll.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.AppUsersPositions.AllAsync(), 
                nameof(BLL.App.DTO.AppUserPosition.Id), 
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            
            return View(vm);
        }

        // GET: AppUsersInPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id.Value);
            
            if (appUserInPosition == null)
            {
                return NotFound();
            }

            return View(appUserInPosition);
        }

        // POST: AppUsersInPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.AppUsersInPositions.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
