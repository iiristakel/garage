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
    public class AppUsersInPositionsController : Controller
    {
        private readonly IAppBLL _bll;

        public AppUsersInPositionsController(IAppBLL bll)
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

//            var appUserInPosition = await _bll.AppUsersInPositions
//                .Include(w => w.AppUser)
//                .Include(w => w.AppUserPosition)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id);
            if (appUserInPosition == null)
            {
                return NotFound();
            }

            return View(appUserInPosition);
        }

        // GET: AppUsersInPositions/Create
        public async Task<IActionResult> Create()
        {
            var vm = new AppUserInPositionCreateEditViewModel();
            
            vm.AppUserSelectList = new SelectList(
                await _bll.BaseEntityService<AppUser>().AllAsync(), 
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.BaseEntityService<AppUserPosition>().AllAsync(), 
                nameof(AppUserPosition.Id), 
                nameof(AppUserPosition.PositionValue));
            
            return View(vm);
        }

        // POST: AppUsersInPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserInPositionCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.AppUsersInPositions.AddAsync(vm.AppUserInPosition);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(
                await _bll.BaseEntityService<AppUser>().AllAsync(), 
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.BaseEntityService<AppUserPosition>().AllAsync(), 
                nameof(AppUserPosition.Id), 
                nameof(AppUserPosition.PositionValue));
            
            return View(vm);
        }

        // GET: AppUsersInPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id);
            if (appUserInPosition == null)
            {
                return NotFound();
            }
            
            var vm = new AppUserInPositionCreateEditViewModel();
            vm.AppUserInPosition = appUserInPosition;
            
            vm.AppUserSelectList = new SelectList(
                await _bll.BaseEntityService<AppUser>().AllAsync(), 
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.BaseEntityService<AppUserPosition>().AllAsync(), 
                nameof(AppUserPosition.Id), 
                nameof(AppUserPosition.PositionValue));
            
            return View(vm);
        }

        // POST: AppUsersInPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppUserInPositionCreateEditViewModel vm)
        {
            if (id != vm.AppUserInPosition.Id)
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
                await _bll.BaseEntityService<AppUser>().AllAsync(), 
                nameof(AppUser.Id), 
                nameof(AppUser.FirstLastName));
            
            vm.AppUserPositionSelectList = new SelectList(
                await _bll.BaseEntityService<AppUserPosition>().AllAsync(), 
                nameof(AppUserPosition.Id), 
                nameof(AppUserPosition.PositionValue));
            
            return View(vm);
        }

        // GET: AppUsersInPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var appUserInPosition = await _bll.AppUsersInPositions
//                .Include(w => w.AppUser)
//                .Include(w => w.AppUserPosition)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var appUserInPosition = await _bll.AppUsersInPositions.FindAsync(id);
            
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
