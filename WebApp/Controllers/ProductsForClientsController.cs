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
using WebApp.ViewModels;

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
            var vm = new ProductsForClientsCreateEditViewModel();
            
            vm.ClientSelectList = new SelectList(
                await _uow.BaseRepository<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.Address));
            
            vm.ProductSelectList = new SelectList(
                await _uow.BaseRepository<Product>().AllAsync(),
                nameof(Product.Id), 
                nameof(Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _uow.BaseRepository<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));

            return View(vm);
        }

        // POST: ProductsForClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductsForClientsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.ProductsForClients.AddAsync(vm.ProductForClient);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.ClientSelectList = new SelectList(
                await _uow.BaseRepository<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.Address));
            
            vm.ProductSelectList = new SelectList(
                await _uow.BaseRepository<Product>().AllAsync(),
                nameof(Product.Id), 
                nameof(Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _uow.BaseRepository<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));

            return View(vm);
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

            var vm = new ProductsForClientsCreateEditViewModel();
            vm.ProductForClient = productForClient;
            
            vm.ClientSelectList = new SelectList(
                await _uow.BaseRepository<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.Address));
            
            vm.ProductSelectList = new SelectList(
                await _uow.BaseRepository<Product>().AllAsync(),
                nameof(Product.Id), 
                nameof(Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _uow.BaseRepository<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));

            return View(vm);
        }

        // POST: ProductsForClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ProductsForClientsCreateEditViewModel vm)
        {
            if (id != vm.ProductForClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.ProductsForClients.Update(vm.ProductForClient);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.ClientSelectList = new SelectList(
                await _uow.BaseRepository<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.Address));
            
            vm.ProductSelectList = new SelectList(
                await _uow.BaseRepository<Product>().AllAsync(),
                nameof(Product.Id), 
                nameof(Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _uow.BaseRepository<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));

            return View(vm);
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