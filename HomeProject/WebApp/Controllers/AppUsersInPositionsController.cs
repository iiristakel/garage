#pragma warning disable 1591
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
using Identity;
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
            var appUsersInPositions = await _bll.AppUsersInPositions.AllForUserAsync(User.GetUserId());
            return View(appUsersInPositions);
        }

        // GET: AppUsersInPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserInPosition = await _bll.AppUsersInPositions.FindForUserAsync(id.Value, User.GetUserId());
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
            var vm = new AppUserInPositionCreateEditViewModel();
            
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
        public async Task<IActionResult> Create(AppUserInPositionCreateEditViewModel vm)
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

        // GET: AppUsersInPositions/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserInPosition = await _bll.AppUsersInPositions.FindForUserAsync(id.Value, User.GetUserId());
            if (appUserInPosition == null)
            {
                return NotFound();
            }
            
            var vm = new AppUserInPositionCreateEditViewModel();
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
        public async Task<IActionResult> Edit(int id, AppUserInPositionCreateEditViewModel vm)
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

            var appUserInPosition = await _bll.AppUsersInPositions.FindForUserAsync(id.Value, User.GetUserId());
            
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
