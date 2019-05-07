using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProductsForClientsController : Controller
    {
        private readonly IAppBLL _bll;

        public ProductsForClientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: ProductsForClients
        public async Task<IActionResult> Index()
        {
            var productsForClients = await _bll.ProductsForClients.AllAsync();

            return View(productsForClients);
        }

        // GET: ProductsForClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var productForClient = await _bll.ProductsForClients.FindAsync(id);

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
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.ProductSelectList = new SelectList(
                await _bll.Products.AllAsync(),
                nameof(BLL.App.DTO.Product.Id), 
                nameof(BLL.App.DTO.Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id));

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
                _bll.ProductsForClients.Add(vm.ProductForClient);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.ProductSelectList = new SelectList(
                await _bll.Products.AllAsync(),
                nameof(BLL.App.DTO.Product.Id), 
                nameof(BLL.App.DTO.Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id));

            return View(vm);
        }

        // GET: ProductsForClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productForClient = await _bll.ProductsForClients.FindAsync(id);
            if (productForClient == null)
            {
                return NotFound();
            }

            var vm = new ProductsForClientsCreateEditViewModel();
            vm.ProductForClient = productForClient;
            
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.ProductSelectList = new SelectList(
                await _bll.Products.AllAsync(),
                nameof(BLL.App.DTO.Product.Id), 
                nameof(BLL.App.DTO.Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id));

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
                _bll.ProductsForClients.Update(vm.ProductForClient);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.ProductSelectList = new SelectList(
                await _bll.Products.AllAsync(),
                nameof(BLL.App.DTO.Product.Id), 
                nameof(BLL.App.DTO.Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.WorkObject.Id), 
                nameof(BLL.App.DTO.WorkObject.Id));

            return View(vm);
        }

        // GET: ProductsForClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productForClient = await _bll.ProductsForClients.FindAsync(id);
                
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
            _bll.ProductsForClients.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}