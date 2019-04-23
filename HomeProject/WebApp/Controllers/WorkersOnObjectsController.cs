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
    public class WorkersOnObjectsController : Controller
    {
        private readonly IAppBLL _bll;

        public WorkersOnObjectsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkersOnObjects
        public async Task<IActionResult> Index()
        {
            var workerOnObject = await _bll.WorkersOnObjects.AllAsync();

            return View(workerOnObject);
        }

        // GET: WorkersOnObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerOnObject = await _bll.WorkersOnObjects
//                .Include(w => w.WorkObject)
//                .Include(w => w.Worker)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerOnObject = await _bll.WorkersOnObjects.FindAsync(id);

            if (workerOnObject == null)
            {
                return NotFound();
            }

            return View(workerOnObject);
        }

        // GET: WorkersOnObjects/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WorkerOnObjectCreateEditViewModel();
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(),
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            return View(vm);
        }

        // POST: WorkersOnObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkerOnObjectCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.WorkersOnObjects.AddAsync(vm.WorkerOnObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(),
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            return View(vm);
        }

        // GET: WorkersOnObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerOnObject = await _bll.WorkersOnObjects.FindAsync(id);
            if (workerOnObject == null)
            {
                return NotFound();
            }

            var vm = new WorkerOnObjectCreateEditViewModel();
            vm.WorkerOnObject = workerOnObject;
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(),
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            return View(vm);
        }

        // POST: WorkersOnObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkerOnObjectCreateEditViewModel vm)
        {
            if (id != vm.WorkerOnObject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.WorkersOnObjects.Update(vm.WorkerOnObject);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.WorkObjectSelectList = new SelectList(
                await _bll.BaseEntityService<WorkObject>().AllAsync(),
                nameof(WorkObject.Id), 
                nameof(WorkObject.Id));
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(),
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            return View(vm);
        }

        // GET: WorkersOnObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerOnObject = await _bll.WorkersOnObjects
//                .Include(w => w.WorkObject)
//                .Include(w => w.Worker)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerOnObject = await _bll.WorkersOnObjects.FindAsync(id);
            
            if (workerOnObject == null)
            {
                return NotFound();
            }

            return View(workerOnObject);
        }

        // POST: WorkersOnObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.WorkersOnObjects.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}