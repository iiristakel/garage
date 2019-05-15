#pragma warning disable 1591
using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllAppUsersController : Controller
    {
        private readonly IAppBLL _bll;

        public AllAppUsersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: AppUsers
        public async Task<IActionResult> Index()
        {
            var appUsers = await _bll.AppUsers.AllAsync();

            return View(appUsers);
        }

        // GET: AppUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _bll.AppUsers.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

//        // GET: AppUsers/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: AppUsers/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("FirstName,LastName,HiringDate,LeftJob,PhoneNr,Email,Id")]
//            AppUser appUser)
//        {
//            appUser.AppUserId = User.GetUserId();
//
//            
//            if (ModelState.IsValid)
//            {
//                _bll.AppUsers.Add(appUser);
//                await _bll.SaveChangesAsync();
//
//                return RedirectToAction(nameof(Index));
//            }
//
//            return View(appUser);
//        }

        // GET: AppUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _bll.AppUsers.FindAsync(id);
            
            if (appUser == null)
            {
                return NotFound();
            }

            var vm = new Areas.Admin.ViewModels.AppUserCreateEditViewModel();

            vm.AppUserPositionSelectList = new MultiSelectList(
                await _bll.AppUsersPositions.AllAsync(),
                nameof(BLL.App.DTO.AppUserPosition.Id),
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            

            return View(vm);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Areas.Admin.ViewModels.AppUserCreateEditViewModel vm)
        {

            if (id != vm.AppUser.Id) 
            {
                return NotFound();
            }
            
            

            if (ModelState.IsValid)
            {
                _bll.AppUsers.Update(vm.AppUser);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            //TODO: not working
            vm.AppUserPositionSelectList = new MultiSelectList(
                await _bll.AppUsersPositions.AllAsync(),
                nameof(BLL.App.DTO.AppUserPosition.Id),
                nameof(BLL.App.DTO.AppUserPosition.AppUserPositionValue));
            
            
            return View(vm);
        }

        // GET: AppUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _bll.AppUsers.FindAsync(id);
                
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            _bll.AppUsers.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}