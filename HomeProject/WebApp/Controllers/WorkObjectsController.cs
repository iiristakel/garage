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
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class WorkObjectsController : Controller
    {
        private readonly IAppBLL _bll;

        public WorkObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkObjects
        public async Task<IActionResult> Index()
        {
            var workObjects = await _bll.WorkObjects.AllAsync();

            return View(workObjects);
        }

        // GET: WorkObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workObject = await _bll.WorkObjects
//                .Include(w => w.Client)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workObject = await _bll.WorkObjects.FindAsync(id);

            if (workObject == null)
            {
                return NotFound();
            }

            return View(workObject);
        }

        // GET: WorkObjects/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WorkObjectCreateEditViewModel();
            
            vm.ClientSelectList = new SelectList(
                await _bll.BaseEntityService<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.CompanyName));
            
            return View(vm);
        }

        // POST: WorkObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkObjectCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.WorkObjects.AddAsync(vm.WorkObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.ClientSelectList = new SelectList(
                await _bll.BaseEntityService<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.CompanyName));
            
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

            var vm = new WorkObjectCreateEditViewModel();
            vm.WorkObject = workObject;
            
            vm.ClientSelectList = new SelectList(
                await _bll.BaseEntityService<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.CompanyName));
            
            return View(vm);
        }

        // POST: WorkObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkObjectCreateEditViewModel vm)
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
                await _bll.BaseEntityService<Client>().AllAsync(),
                nameof(Client.Id), 
                nameof(Client.CompanyName));
            
            return View(vm);
        }

        // GET: WorkObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workObject = await _bll.WorkObjects
//                .Include(w => w.Client)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workObject = await _bll.WorkObjects.FindAsync(id);
            
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
            _bll.WorkObjects.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}