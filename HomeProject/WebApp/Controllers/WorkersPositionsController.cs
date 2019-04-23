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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class WorkersPositionsController : Controller
    {
        private readonly IAppBLL _bll;

        public WorkersPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkersPositions
        public async Task<IActionResult> Index()
        {
            var workerPosition = await _bll.WorkersPositions.AllAsync();
            return View(workerPosition);
        }

        // GET: WorkersPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerPosition = await _context.WorkersPositions
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerPosition = await _bll.WorkersPositions.FindAsync(id);

            if (workerPosition == null)
            {
                return NotFound();
            }

            return View(workerPosition);
        }

        // GET: WorkersPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkersPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerPositionValue,Id")] WorkerPosition workerPosition)
        {
            if (ModelState.IsValid)
            {
                await _bll.WorkersPositions.AddAsync(workerPosition);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(workerPosition);
        }

        // GET: WorkersPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerPosition = await _bll.WorkersPositions.FindAsync(id);
            if (workerPosition == null)
            {
                return NotFound();
            }

            return View(workerPosition);
        }

        // POST: WorkersPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerPositionValue,Id")] WorkerPosition workerPosition)
        {
            if (id != workerPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.WorkersPositions.Update(workerPosition);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(workerPosition);
        }

        // GET: WorkersPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerPosition = await _context.WorkersPositions
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerPosition = await _bll.WorkersPositions.FindAsync(id);
            
            if (workerPosition == null)
            {
                return NotFound();
            }

            return View(workerPosition);
        }

        // POST: WorkersPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.WorkersPositions.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}