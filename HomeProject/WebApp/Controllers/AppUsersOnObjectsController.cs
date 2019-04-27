using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class AppUsersOnObjectsController : Controller
    {
        private readonly IAppBLL _bll;

        public AppUsersOnObjectsController(IAppBLL bll)
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

//            var appUserOnObject = await _bll.AppUsersOnObjects
//                .Include(w => w.WorkObject)
//                .Include(w => w.AppUser)
//                .FirstOrDefaultAsync(m => m.Id == id);
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
            var vm = new AppUserOnObjectCreateEditViewModel();
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.BaseEntityService<AppUser>().AllAsync(),
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            return View(vm);
        }

        // POST: AppUsersOnObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserOnObjectCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.AppUsersOnObjects.AddAsync(vm.AppUserOnObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.BaseEntityService<AppUser>().AllAsync(),
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            return View(vm);
        }

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

            var vm = new AppUserOnObjectCreateEditViewModel();
            vm.AppUserOnObject = appUserOnObject;
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.BaseEntityService<AppUser>().AllAsync(),
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            return View(vm);
        }

        // POST: AppUsersOnObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppUserOnObjectCreateEditViewModel vm)
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
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.BaseEntityService<AppUser>().AllAsync(),
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            return View(vm);
        }

        // GET: AppUsersOnObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var appUserOnObject = await _bll.AppUsersOnObjects
//                .Include(w => w.WorkObject)
//                .Include(w => w.AppUser)
//                .FirstOrDefaultAsync(m => m.Id == id);
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