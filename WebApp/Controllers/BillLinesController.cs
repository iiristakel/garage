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
    public class BillLinesController : Controller
    {
        private readonly AppDbContext _context;

        public BillLinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BillLines
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BillLines.Include(b => b.Bill).Include(b => b.ProductForObject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BillLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _context.BillLines
                .Include(b => b.Bill)
                .Include(b => b.ProductForObject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billLine == null)
            {
                return NotFound();
            }

            return View(billLine);
        }

        // GET: BillLines/Create
        public IActionResult Create()
        {
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id");
            ViewData["ProductForObjectId"] = new SelectList(_context.ProductsForClients, "Id", "Id");
            return View();
        }

        // POST: BillLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillId,ProductForObjectId,Sum,Amount,DiscountPercent,Id")] BillLine billLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", billLine.BillId);
            ViewData["ProductForObjectId"] = new SelectList(_context.ProductsForClients, "Id", "Id", billLine.ProductForObjectId);
            return View(billLine);
        }

        // GET: BillLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _context.BillLines.FindAsync(id);
            if (billLine == null)
            {
                return NotFound();
            }
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", billLine.BillId);
            ViewData["ProductForObjectId"] = new SelectList(_context.ProductsForClients, "Id", "Id", billLine.ProductForObjectId);
            return View(billLine);
        }

        // POST: BillLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,ProductForObjectId,Sum,Amount,DiscountPercent,Id")] BillLine billLine)
        {
            if (id != billLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillLineExists(billLine.Id))
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
            ViewData["BillId"] = new SelectList(_context.Bills, "Id", "Id", billLine.BillId);
            ViewData["ProductForObjectId"] = new SelectList(_context.ProductsForClients, "Id", "Id", billLine.ProductForObjectId);
            return View(billLine);
        }

        // GET: BillLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _context.BillLines
                .Include(b => b.Bill)
                .Include(b => b.ProductForObject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billLine == null)
            {
                return NotFound();
            }

            return View(billLine);
        }

        // POST: BillLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billLine = await _context.BillLines.FindAsync(id);
            _context.BillLines.Remove(billLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillLineExists(int id)
        {
            return _context.BillLines.Any(e => e.Id == id);
        }
    }
}
