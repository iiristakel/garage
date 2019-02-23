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
    public class WorkersPositionsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkersPositionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkersPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkersPositions.ToListAsync());
        }

        // GET: WorkersPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerPosition = await _context.WorkersPositions
                .FirstOrDefaultAsync(m => m.Id == id);
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
                _context.Add(workerPosition);
                await _context.SaveChangesAsync();
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

            var workerPosition = await _context.WorkersPositions.FindAsync(id);
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
                try
                {
                    _context.Update(workerPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerPositionExists(workerPosition.Id))
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
            return View(workerPosition);
        }

        // GET: WorkersPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerPosition = await _context.WorkersPositions
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var workerPosition = await _context.WorkersPositions.FindAsync(id);
            _context.WorkersPositions.Remove(workerPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerPositionExists(int id)
        {
            return _context.WorkersPositions.Any(e => e.Id == id);
        }
    }
}
