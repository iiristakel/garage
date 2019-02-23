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
    public class ProductsForClientsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsForClientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductsForClients
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductsForClients.Include(p => p.Client).Include(p => p.Product).Include(p => p.WorkObject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductsForClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productForClient = await _context.ProductsForClients
                .Include(p => p.Client)
                .Include(p => p.Product)
                .Include(p => p.WorkObject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productForClient == null)
            {
                return NotFound();
            }

            return View(productForClient);
        }

        // GET: ProductsForClients/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id");
            return View();
        }

        // POST: ProductsForClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,WorkObjectId,ClientId,Count,Id")] ProductForClient productForClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productForClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", productForClient.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", productForClient.ProductId);
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", productForClient.WorkObjectId);
            return View(productForClient);
        }

        // GET: ProductsForClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productForClient = await _context.ProductsForClients.FindAsync(id);
            if (productForClient == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", productForClient.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", productForClient.ProductId);
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", productForClient.WorkObjectId);
            return View(productForClient);
        }

        // POST: ProductsForClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,WorkObjectId,ClientId,Count,Id")] ProductForClient productForClient)
        {
            if (id != productForClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productForClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductForClientExists(productForClient.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Address", productForClient.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", productForClient.ProductId);
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", productForClient.WorkObjectId);
            return View(productForClient);
        }

        // GET: ProductsForClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productForClient = await _context.ProductsForClients
                .Include(p => p.Client)
                .Include(p => p.Product)
                .Include(p => p.WorkObject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productForClient == null)
            {
                return NotFound();
            }

            return View(productForClient);
        }

        // POST: ProductsForClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productForClient = await _context.ProductsForClients.FindAsync(id);
            _context.ProductsForClients.Remove(productForClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductForClientExists(int id)
        {
            return _context.ProductsForClients.Any(e => e.Id == id);
        }
    }
}
