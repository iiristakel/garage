#pragma warning disable 1591
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

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllProductsForClientsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllProductsForClientsController(IAppBLL bll)
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
            
            var vm = new WebApp.Areas.Admin.ViewModels.ProductsForClientsCreateEditViewModel();
            vm.ProductForClient = productForClient;
            vm.ProductForClient.ProductServices = await _bll.ProductsServices.AllForClientProductAsync(id);

            return View(vm);
        }

        // GET: ProductsForClients/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WebApp.Areas.Admin.ViewModels.ProductsForClientsCreateEditViewModel();
            
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.ProductSelectList = new SelectList(
                await _bll.Products.AllAsync(),
                nameof(BLL.App.DTO.Product.Id), 
                nameof(BLL.App.DTO.Product.ProductName));
            

            return View(vm);
        }

        // POST: ProductsForClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebApp.Areas.Admin.ViewModels.ProductsForClientsCreateEditViewModel vm)
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

            var vm = new WebApp.Areas.Admin.ViewModels.ProductsForClientsCreateEditViewModel();
            vm.ProductForClient = productForClient;
            
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.ProductSelectList = new SelectList(
                await _bll.Products.AllAsync(),
                nameof(BLL.App.DTO.Product.Id), 
                nameof(BLL.App.DTO.Product.ProductName));
            

            return View(vm);
        }

        // POST: ProductsForClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebApp.Areas.Admin.ViewModels.ProductsForClientsCreateEditViewModel vm)
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
            var vm = new WebApp.Areas.Admin.ViewModels.ProductsForClientsCreateEditViewModel();
            vm.ProductForClient = productForClient;
            vm.ProductForClient.ProductServices = await _bll.ProductsServices.AllForClientProductAsync(id);

            return View(vm);
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