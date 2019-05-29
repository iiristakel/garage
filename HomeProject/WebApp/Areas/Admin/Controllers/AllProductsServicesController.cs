#pragma warning disable 1591
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllProductsServicesController : Controller
    {
        private readonly IAppBLL _bll;

        public AllProductsServicesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: ProductsServices
        public async Task<IActionResult> Index()
        {
            var productServices = await _bll.ProductsServices.AllAsync();
            return View(productServices);
        }

        // GET: ProductsServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productService = await _bll.ProductsServices.FindAsync(id);
            if (productService == null)
            {
                return NotFound();
            }

            return View(productService);
        }

        // GET: ProductsServices/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WebApp.Areas.Admin.ViewModels.ProductServiceCreateEditViewModel();
            
            vm.ProductForClientSelectList = new SelectList(
                await _bll.ProductsForClients.AllAsync(),
                nameof(BLL.App.DTO.ProductForClient.Id),
                nameof(BLL.App.DTO.ProductForClient.Id));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id),
                nameof(BLL.App.DTO.WorkObject.Id));
            return View(vm);
        }

        // POST: ProductsServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebApp.Areas.Admin.ViewModels.ProductServiceCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.ProductsServices.Add(vm.ProductService);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.ProductForClientSelectList = new SelectList(
                await _bll.ProductsForClients.AllAsync(),
                nameof(BLL.App.DTO.ProductForClient.Id),
                nameof(BLL.App.DTO.ProductForClient.Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id),
                nameof(BLL.App.DTO.WorkObject.Client.CompanyAndAddress));
            
            return View(vm);
        }

        // GET: ProductsServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productService = await _bll.ProductsServices.FindAsync(id);
            if (productService == null)
            {
                return NotFound();
            }
            
            var vm = new WebApp.Areas.Admin.ViewModels.ProductServiceCreateEditViewModel();

            vm.ProductService = productService;
            vm.ProductForClientSelectList = new SelectList(
                await _bll.ProductsForClients.AllAsync(),
                nameof(BLL.App.DTO.ProductForClient.Id),
                nameof(BLL.App.DTO.ProductForClient.Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id),
                nameof(BLL.App.DTO.WorkObject.Client.CompanyAndAddress));
            
            return View(vm);
        }

        // POST: ProductsServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebApp.Areas.Admin.ViewModels.ProductServiceCreateEditViewModel vm)
        {
            if (id != vm.ProductService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _bll.ProductsServices.Update(vm.ProductService);
                    await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            vm.ProductForClientSelectList = new SelectList(
                await _bll.ProductsForClients.AllAsync(),
                nameof(BLL.App.DTO.ProductForClient.Id),
                nameof(BLL.App.DTO.ProductForClient.Product.ProductName));
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.WorkObjects.AllAsync(),
                nameof(BLL.App.DTO.WorkObject.Id),
                nameof(BLL.App.DTO.WorkObject.Client.CompanyAndAddress));
            
            return View(vm);
        }

        // GET: ProductsServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productService = await _bll.ProductsServices.FindAsync(id);
            
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
            _bll.ProductsServices.Remove(id);
            
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
