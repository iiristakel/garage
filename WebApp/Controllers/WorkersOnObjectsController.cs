using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class WorkersOnObjectsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkersOnObjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkersOnObjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkersOnObjects.Include(w => w.WorkObject).Include(w => w.Worker);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkersOnObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerOnObject = await _context.WorkersOnObjects
                .Include(w => w.WorkObject)
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workerOnObject == null)
            {
                return NotFound();
            }

            return View(workerOnObject);
        }

        // GET: WorkersOnObjects/Create
        public IActionResult Create()
        {
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id");
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName");
            return View();
        }

        // POST: WorkersOnObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerId,WorkObjectId,From,Until,Id")] WorkerOnObject workerOnObject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workerOnObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", workerOnObject.WorkObjectId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName", workerOnObject.WorkerId);
            return View(workerOnObject);
        }

        // GET: WorkersOnObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerOnObject = await _context.WorkersOnObjects.FindAsync(id);
            if (workerOnObject == null)
            {
                return NotFound();
            }
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", workerOnObject.WorkObjectId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName", workerOnObject.WorkerId);
            return View(workerOnObject);
        }

        // POST: WorkersOnObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerId,WorkObjectId,From,Until,Id")] WorkerOnObject workerOnObject)
        {
            if (id != workerOnObject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workerOnObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerOnObjectExists(workerOnObject.Id))
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
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", workerOnObject.WorkObjectId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "FirstName", workerOnObject.WorkerId);
            return View(workerOnObject);
        }

        // GET: WorkersOnObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerOnObject = await _context.WorkersOnObjects
                .Include(w => w.WorkObject)
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workerOnObject == null)
            {
                return NotFound();
            }

            return View(workerOnObject);
        }

        // POST: WorkersOnObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workerOnObject = await _context.WorkersOnObjects.FindAsync(id);
            _context.WorkersOnObjects.Remove(workerOnObject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerOnObjectExists(int id)
        {
            return _context.WorkersOnObjects.Any(e => e.Id == id);
        }
    }
}
