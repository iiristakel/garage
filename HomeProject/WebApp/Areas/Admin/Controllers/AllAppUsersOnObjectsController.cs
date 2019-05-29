#pragma warning disable 1591
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllAppUsersOnObjectsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllAppUsersOnObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: AppUsersOnObjects
        public async Task<IActionResult> Index()
        {
            var appUserOnObject = await _bll.AppUsersOnObjects.AllAsync();

            return View(appUserOnObject);
        }

        // GET: AppUsersOnObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserOnObject = await _bll.AppUsersOnObjects.FindAsync(id);

            if (appUserOnObject == null)
            {
                return NotFound();
            }

            return View(appUserOnObject);
        }

        // GET: AppUsersOnObjects/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WebApp.Areas.Admin.ViewModels.AppUserOnObjectCreateEditViewModel();
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            return View(vm);
        }

        // POST: AppUsersOnObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebApp.Areas.Admin.ViewModels.AppUserOnObjectCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.AppUsersOnObjects.Add(vm.AppUserOnObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            return View(vm);
        }
        
//        public async Task<IActionResult> ChooseForWorkObject(int workobjectid)
//        {
//
//            var vm = new Areas.Admin.ViewModels.AppUserOnObjectCreateEditViewModel();
//
//            vm.WorkObjectId = workobjectid;
//
//            vm.AppUserSelectList = new SelectList(
//                await _bll.AppUsers.AllAsync(),
//                nameof(BLL.App.DTO.Identity.AppUser.Id),
//                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
//
//
//            return View(vm);
//        }
//        
//        [HttpPost]
//        public async Task<IActionResult> ChooseForWorkObject(int workobjectid, 
//            WebApp.Areas.Admin.ViewModels.AppUserOnObjectCreateEditViewModel vm)
//        {
//            if (workobjectid != vm.WorkObjectId)
//            {
//                return NotFound();
//            }
//            
//            if (ModelState.IsValid)
//            {
//                _bll.AppUsersOnObjects.Add(vm.AppUserOnObject);
//                await _bll.SaveChangesAsync();
//
//                return RedirectToAction(nameof(Index));
//            }
//
//            vm.WorkObjectId = workobjectid;
//            
//            vm.AppUserSelectList = new SelectList(
//                await _bll.AppUsers.AllAsync(),
//                nameof(BLL.App.DTO.Identity.AppUser.Id), 
//                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
//            
//            return View(vm);
//        }

        // GET: AppUsersOnObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserOnObject = await _bll.AppUsersOnObjects.FindAsync(id);
            if (appUserOnObject == null)
            {
                return NotFound();
            }

            var vm = new WebApp.Areas.Admin.ViewModels.AppUserOnObjectCreateEditViewModel();
            vm.AppUserOnObject = appUserOnObject;
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            return View(vm);
        }

        // POST: AppUsersOnObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebApp.Areas.Admin.ViewModels.AppUserOnObjectCreateEditViewModel vm)
        {
            if (id != vm.AppUserOnObject.Id)
            {
                return NotFound();
            }
            
           

            if (ModelState.IsValid)
            {
                _bll.AppUsersOnObjects.Update(vm.AppUserOnObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id ));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            return View(vm);
        }

        // GET: AppUsersOnObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserOnObject = await _bll.AppUsersOnObjects.FindAsync(id);
            
            if (appUserOnObject == null)
            {
                return NotFound();
            }

            return View(appUserOnObject);
        }

        // POST: AppUsersOnObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            
            _bll.AppUsersOnObjects.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}