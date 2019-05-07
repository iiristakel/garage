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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class AppUsersPositionsController : Controller
    {
        private readonly IAppBLL _bll;

        public AppUsersPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: AppUsersPositions
        public async Task<IActionResult> Index()
        {
            var appUserPosition = await _bll.AppUsersPositions.GetAllWithAppUsersCountAsync();
            return View(appUserPosition);
        }

        // GET: AppUsersPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var appUserPosition = await _context.AppUsersPositions
//                .FirstOrDefaultAsync(m => m.Id == id);
            var appUserPosition = await _bll.AppUsersPositions.FindAsync(id);

            if (appUserPosition == null)
            {
                return NotFound();
            }

            return View(appUserPosition);
        }

        // GET: AppUsersPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUsersPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppUserPositionValue,Id")] 
            BLL.App.DTO.AppUserPosition appUserPosition)
        {
            if (ModelState.IsValid)
            {
                await _bll.AppUsersPositions.AddAsync(appUserPosition);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(appUserPosition);
        }

        // GET: AppUsersPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserPosition = await _bll.AppUsersPositions.FindAsync(id);
            if (appUserPosition == null)
            {
                return NotFound();
            }

            return View(appUserPosition);
        }

        // POST: AppUsersPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppUserPositionValue,Id")] 
            BLL.App.DTO.AppUserPosition appUserPosition)
        {
            if (id != appUserPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.AppUsersPositions.Update(appUserPosition);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(appUserPosition);
        }

        // GET: AppUsersPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var appUserPosition = await _context.AppUsersPositions
//                .FirstOrDefaultAsync(m => m.Id == id);
            var appUserPosition = await _bll.AppUsersPositions.FindAsync(id);
            
            if (appUserPosition == null)
            {
                return NotFound();
            }

            return View(appUserPosition);
        }

        // POST: AppUsersPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.AppUsersPositions.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}