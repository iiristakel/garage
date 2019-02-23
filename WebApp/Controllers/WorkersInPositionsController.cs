using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class WorkersInPositionsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkersInPositionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkersInPositions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkersInPositions.Include(w => w.Worker).Include(w => w.WorkerPosition);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkersInPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerInPosition = await _context.WorkersInPositions
                .Include(w => w.Worker)
                .Include(w => w.WorkerPosition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workerInPosition == null)
            {
                return NotFound();
            }

            return View(workerInPosition);
        }

        // GET: WorkersInPositions/Create
        public IActionResult Create()
        {
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName");
            ViewData["WorkerPositionId"] = new SelectList(_context.WorkersPositions, "Id", "WorkerPositionValue");
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
                _context.Add(workerInPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName", workerInPosition.WorkerId);
            ViewData["WorkerPositionId"] = new SelectList(_context.WorkersPositions, "Id", "WorkerPositionValue", workerInPosition.WorkerPositionId);
            return View(workerInPosition);
        }

        // GET: WorkersInPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerInPosition = await _context.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName", workerInPosition.WorkerId);
            ViewData["WorkerPositionId"] = new SelectList(_context.WorkersPositions, "Id", "WorkerPositionValue", workerInPosition.WorkerPositionId);
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
                try
                {
                    _context.Update(workerInPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerInPositionExists(workerInPosition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName", workerInPosition.WorkerId);
            ViewData["WorkerPositionId"] = new SelectList(_context.WorkersPositions, "Id", "WorkerPositionValue", workerInPosition.WorkerPositionId);
            return View(workerInPosition);
        }

        // GET: WorkersInPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerInPosition = await _context.WorkersInPositions
                .Include(w => w.Worker)
                .Include(w => w.WorkerPosition)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var workerInPosition = await _context.WorkersInPositions.FindAsync(id);
            _context.WorkersInPositions.Remove(workerInPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerInPositionExists(int id)
        {
            return _context.WorkersInPositions.Any(e => e.Id == id);
        }
    }
}
