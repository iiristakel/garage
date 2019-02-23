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
    public class WorkObjectsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkObjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkObjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkObjects.Include(w => w.Client);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workObject = await _context.WorkObjects
                .Include(w => w.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workObject == null)
            {
                return NotFound();
            }

            return View(workObject);
        }

        // GET: WorkObjects/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address");
            return View();
        }

        // POST: WorkObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,From,Until,Id")] WorkObject workObject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", workObject.ClientId);
            return View(workObject);
        }

        // GET: WorkObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workObject = await _context.WorkObjects.FindAsync(id);
            if (workObject == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", workObject.ClientId);
            return View(workObject);
        }

        // POST: WorkObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,From,Until,Id")] WorkObject workObject)
        {
            if (id != workObject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkObjectExists(workObject.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", workObject.ClientId);
            return View(workObject);
        }

        // GET: WorkObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workObject = await _context.WorkObjects
                .Include(w => w.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workObject == null)
            {
                return NotFound();
            }

            return View(workObject);
        }

        // POST: WorkObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workObject = await _context.WorkObjects.FindAsync(id);
            _context.WorkObjects.Remove(workObject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkObjectExists(int id)
        {
            return _context.WorkObjects.Any(e => e.Id == id);
        }
    }
}
