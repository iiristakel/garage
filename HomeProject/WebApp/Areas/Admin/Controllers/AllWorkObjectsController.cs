#pragma warning disable 1591
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;
using AppUserOnObject = BLL.App.DTO.AppUserOnObject;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllWorkObjectsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllWorkObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkObjects
        public async Task<IActionResult> Index()
        {
            var workObjects = await _bll.WorkObjects.AllAsync();

            foreach (var workObject in workObjects)
            {
                workObject.AppUsersOnObject = await _bll.AppUsersOnObjects.AllForWorkObjectAsync(workObject.Id);
                workObject.ProductsServices = await _bll.ProductsServices.AllForWorkObjectAsync(workObject.Id);
            }

            return View(workObjects);
        }

        // GET: WorkObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workObject = await _bll.WorkObjects.FindAsync(id);

            if (workObject == null)
            {
                return NotFound();
            }
            var vm = new WebApp.Areas.Admin.ViewModels.WorkObjectCreateEditViewModel();
            vm.WorkObject = workObject;
            vm.WorkObject.AppUsersOnObject = await _bll.AppUsersOnObjects.AllForWorkObjectAsync(workObject.Id);
            vm.WorkObject.ProductsServices = await _bll.ProductsServices.AllForWorkObjectAsync(workObject.Id);
            vm.WorkObject.Bills = await _bll.Bills.AllForWorkObjectAsync(workObject.Id);

            return View(vm);
        }

        // GET: WorkObjects/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WebApp.Areas.Admin.ViewModels.WorkObjectCreateEditViewModel
            {
                ClientSelectList = new SelectList(
                    await _bll.Clients.AllAsync(),
                    nameof(BLL.App.DTO.Client.Id),
                    nameof(BLL.App.DTO.Client.CompanyName)),
                
            };


            return View(vm);
        }

        // POST: WorkObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebApp.Areas.Admin.ViewModels.WorkObjectCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.WorkObjects.Add(vm.WorkObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id),
                nameof(BLL.App.DTO.Client.CompanyName));


            return View(vm);
        }

        // GET: WorkObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workObject = await _bll.WorkObjects.FindAsync(id);
            if (workObject == null)
            {
                return NotFound();
            }

            var vm = new WebApp.Areas.Admin.ViewModels.WorkObjectCreateEditViewModel();

            vm.WorkObject = workObject;

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id),
                nameof(BLL.App.DTO.Client.CompanyName));


            return View(vm);
        }

        // POST: WorkObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebApp.Areas.Admin.ViewModels.WorkObjectCreateEditViewModel vm)
        {
            if (id != vm.WorkObject.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _bll.WorkObjects.Update(vm.WorkObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id),
                nameof(BLL.App.DTO.Client.CompanyName));
            

            return View(vm);
        }

        // GET: WorkObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workObject = await _bll.WorkObjects.FindAsync(id);

            if (workObject == null)
            {
                return NotFound();
            }
            var vm = new WebApp.Areas.Admin.ViewModels.WorkObjectCreateEditViewModel();
            vm.WorkObject = workObject;
            vm.WorkObject.AppUsersOnObject = await _bll.AppUsersOnObjects.AllForWorkObjectAsync(workObject.Id);
            vm.WorkObject.ProductsServices = await _bll.ProductsServices.AllForWorkObjectAsync(workObject.Id);
            vm.WorkObject.Bills = await _bll.Bills.AllForWorkObjectAsync(workObject.Id);

            return View(vm);
        }

        // POST: WorkObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.WorkObjects.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}