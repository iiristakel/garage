using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Areas.Admin.Controllers
{
    public class AllProductsServicesController : Controller
    {
        private readonly AppDbContext _context;

        public AllProductsServicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductsServices
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductsServices.Include(p => p.ProductForClient).Include(p => p.WorkObject);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductsServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productService = await _context.ProductsServices
                .Include(p => p.ProductForClient)
                .Include(p => p.WorkObject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productService == null)
            {
                return NotFound();
            }

            return View(productService);
        }

        // GET: ProductsServices/Create
        public IActionResult Create()
        {
            ViewData["ProductForClientId"] = new SelectList(_context.ProductsForClients, "Id", "Id");
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id");
            return View();
        }

        // POST: ProductsServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductForClientId,WorkObjectId,Id")] ProductService productService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductForClientId"] = new SelectList(_context.ProductsForClients, "Id", "Id", productService.ProductForClientId);
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", productService.WorkObjectId);
            return View(productService);
        }

        // GET: ProductsServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productService = await _context.ProductsServices.FindAsync(id);
            if (productService == null)
            {
                return NotFound();
            }
            ViewData["ProductForClientId"] = new SelectList(_context.ProductsForClients, "Id", "Id", productService.ProductForClientId);
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", productService.WorkObjectId);
            return View(productService);
        }

        // POST: ProductsServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductForClientId,WorkObjectId,Id")] ProductService productService)
        {
            if (id != productService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductServiceExists(productService.Id))
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
            ViewData["ProductForClientId"] = new SelectList(_context.ProductsForClients, "Id", "Id", productService.ProductForClientId);
            ViewData["WorkObjectId"] = new SelectList(_context.WorkObjects, "Id", "Id", productService.WorkObjectId);
            return View(productService);
        }

        // GET: ProductsServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productService = await _context.ProductsServices
                .Include(p => p.ProductForClient)
                .Include(p => p.WorkObject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productService == null)
            {
                return NotFound();
            }

            return View(productService);
        }

        // POST: ProductsServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productService = await _context.ProductsServices.FindAsync(id);
            _context.ProductsServices.Remove(productService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductServiceExists(int id)
        {
            return _context.ProductsServices.Any(e => e.Id == id);
        }
    }
}
