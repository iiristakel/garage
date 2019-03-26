using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class WorkersInPositionsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public WorkersInPositionsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: WorkersInPositions
        public async Task<IActionResult> Index()
        {
            var workersInPositions = await _uow.WorkersInPositions.AllAsync();
            return View(workersInPositions);
        }

        // GET: WorkersInPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerInPosition = await _uow.WorkersInPositions
//                .Include(w => w.Worker)
//                .Include(w => w.WorkerPosition)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerInPosition = await _uow.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }

            return View(workerInPosition);
        }

        // GET: WorkersInPositions/Create
        public async Task<IActionResult> Create()
        {
            ViewData["WorkerId"] = new SelectList(await _uow.BaseRepository<Worker>().AllAsync(), 
                "Id", "FirstName");
            ViewData["WorkerPositionId"] = new SelectList(await _uow.BaseRepository<WorkerPosition>().AllAsync(), "Id", "WorkerPositionValue");
            return View();
        }

        // POST: WorkersInPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerId,WorkerPositionId,From,Until,Id")] WorkerInPosition workerInPosition)
        {
            if (ModelState.IsValid)
            {
                await _uow.WorkersInPositions.AddAsync(workerInPosition);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkerId"] = new SelectList(await _uow.BaseRepository<Worker>().AllAsync(),
                "Id", "FirstName", workerInPosition.WorkerId);
            ViewData["WorkerPositionId"] = new SelectList(await _uow.BaseRepository<WorkerPosition>().AllAsync(),
                "Id", "WorkerPositionValue", workerInPosition.WorkerPositionId);
            return View(workerInPosition);
        }

        // GET: WorkersInPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerInPosition = await _uow.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }
            ViewData["WorkerId"] = new SelectList(await _uow.BaseRepository<Worker>().AllAsync(),
                "Id", "FirstName", workerInPosition.WorkerId);
            ViewData["WorkerPositionId"] = new SelectList(await _uow.BaseRepository<WorkerPosition>().AllAsync(),
                "Id", "WorkerPositionValue", workerInPosition.WorkerPositionId);
            return View(workerInPosition);
        }

        // POST: WorkersInPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerId,WorkerPositionId,From,Until,Id")] WorkerInPosition workerInPosition)
        {
            if (id != workerInPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _uow.WorkersInPositions.Update(workerInPosition);
                    await _uow.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkerId"] = new SelectList(await _uow.BaseRepository<Worker>().AllAsync(),
                "Id", "FirstName", workerInPosition.WorkerId);
            ViewData["WorkerPositionId"] = new SelectList(await _uow.BaseRepository<WorkerPosition>().AllAsync(),
                "Id", "WorkerPositionValue", workerInPosition.WorkerPositionId);
            return View(workerInPosition);
        }

        // GET: WorkersInPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerInPosition = await _uow.WorkersInPositions
//                .Include(w => w.Worker)
//                .Include(w => w.WorkerPosition)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerInPosition = await _uow.WorkersInPositions.FindAsync(id);
            
            if (workerInPosition == null)
            {
                return NotFound();
            }

            return View(workerInPosition);
        }

        // POST: WorkersInPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.WorkersInPositions.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
