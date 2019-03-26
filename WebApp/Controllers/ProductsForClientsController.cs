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
    public class ProductsForClientsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ProductsForClientsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ProductsForClients
        public async Task<IActionResult> Index()
        {
            var productsForClients = await _uow.ProductsForClients.AllAsync();

            return View(productsForClients);
        }

        // GET: ProductsForClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var productForClient = await _uow.ProductsForClients
//                .Include(p => p.Client)
//                .Include(p => p.Product)
//                .Include(p => p.WorkObject)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var productForClient = await _uow.ProductsForClients.FindAsync(id);

            if (productForClient == null)
            {
                return NotFound();
            }

            return View(productForClient);
        }

        // GET: ProductsForClients/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync(),
                "Id", "Address");
            ViewData["ProductId"] = new SelectList(await _uow.BaseRepository<Product>().AllAsync(),
                "Id", "ProductName");
            ViewData["WorkObjectId"] = new SelectList(await _uow.BaseRepository<WorkObject>().AllAsync(),
                "Id", "Id");

            return View();
        }

        // POST: ProductsForClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,WorkObjectId,ClientId,Count,Id")]
            ProductForClient productForClient)
        {
            if (ModelState.IsValid)
            {
                await _uow.ProductsForClients.AddAsync(productForClient);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync(),
                "Id", "Address", productForClient.ClientId);
            ViewData["ProductId"] = new SelectList(await _uow.BaseRepository<Product>().AllAsync(),
                "Id", "ProductName", productForClient.ProductId);
            ViewData["WorkObjectId"] = new SelectList(await _uow.BaseRepository<WorkObject>().AllAsync(),
                "Id", "Id", productForClient.WorkObjectId);

            return View(productForClient);
        }

        // GET: ProductsForClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productForClient = await _uow.ProductsForClients.FindAsync(id);
            if (productForClient == null)
            {
                return NotFound();
            }

            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync(),
                "Id", "Address", productForClient.ClientId);
            ViewData["ProductId"] = new SelectList(await _uow.BaseRepository<Product>().AllAsync(),
                "Id", "ProductName", productForClient.ProductId);
            ViewData["WorkObjectId"] = new SelectList(await _uow.BaseRepository<WorkObject>().AllAsync(),
                "Id", "Id", productForClient.WorkObjectId);

            return View(productForClient);
        }

        // POST: ProductsForClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,WorkObjectId,ClientId,Count,Id")]
            ProductForClient productForClient)
        {
            if (id != productForClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.ProductsForClients.Update(productForClient);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync(),
                "Id", "Address", productForClient.ClientId);
            ViewData["ProductId"] = new SelectList(await _uow.BaseRepository<Product>().AllAsync(),
                "Id", "ProductName", productForClient.ProductId);
            ViewData["WorkObjectId"] = new SelectList(await _uow.BaseRepository<WorkObject>().AllAsync(),
                "Id", "Id", productForClient.WorkObjectId);
            
            return View(productForClient);
        }

        // GET: ProductsForClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productForClient = await _uow.ProductsForClients.FindAsync(id);
                
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
            _uow.ProductsForClients.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}