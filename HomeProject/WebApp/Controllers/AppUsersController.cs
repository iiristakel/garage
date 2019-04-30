using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class AppUsersController : Controller
    {
        private readonly IAppBLL _bll;

        public AppUsersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: AppUsers
        public async Task<IActionResult> Index()
        {
//            var appUsers = await _bll.AppUsers
//                .Include(p => p.AppUser)
//                .Where(p => p.AppUserId == User.GetUserId()).ToListAsync();
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
//                await _bll.AppUsers.AddAsync(appUser);
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

            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,HiringDate,LeftJob,PhoneNr,Email,Id")]
            AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.AppUsers.Update(appUser);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            return View(appUser);
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