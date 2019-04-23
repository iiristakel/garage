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
    public class WorkersInPositionsController : Controller
    {
        private readonly IAppBLL _bll;

        public WorkersInPositionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: WorkersInPositions
        public async Task<IActionResult> Index()
        {
            var workersInPositions = await _bll.WorkersInPositions.AllAsync();
            return View(workersInPositions);
        }

        // GET: WorkersInPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerInPosition = await _bll.WorkersInPositions
//                .Include(w => w.Worker)
//                .Include(w => w.WorkerPosition)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerInPosition = await _bll.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }

            return View(workerInPosition);
        }

        // GET: WorkersInPositions/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WorkerInPositionCreateEditViewModel();
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(), 
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            vm.WorkerPositionSelectList = new SelectList(
                await _bll.BaseEntityService<WorkerPosition>().AllAsync(), 
                nameof(WorkerPosition.Id), 
                nameof(WorkerPosition.WorkerPositionValue));
            
            return View(vm);
        }

        // POST: WorkersInPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkerInPositionCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.WorkersInPositions.AddAsync(vm.WorkerInPosition);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(), 
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            vm.WorkerPositionSelectList = new SelectList(
                await _bll.BaseEntityService<WorkerPosition>().AllAsync(), 
                nameof(WorkerPosition.Id), 
                nameof(WorkerPosition.WorkerPositionValue));
            
            return View(vm);
        }

        // GET: WorkersInPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerInPosition = await _bll.WorkersInPositions.FindAsync(id);
            if (workerInPosition == null)
            {
                return NotFound();
            }
            
            var vm = new WorkerInPositionCreateEditViewModel();
            vm.WorkerInPosition = workerInPosition;
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(), 
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            vm.WorkerPositionSelectList = new SelectList(
                await _bll.BaseEntityService<WorkerPosition>().AllAsync(), 
                nameof(WorkerPosition.Id), 
                nameof(WorkerPosition.WorkerPositionValue));
            
            return View(vm);
        }

        // POST: WorkersInPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkerInPositionCreateEditViewModel vm)
        {
            if (id != vm.WorkerInPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _bll.WorkersInPositions.Update(vm.WorkerInPosition);
                    await _bll.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            }
            
            vm.WorkerSelectList = new SelectList(
                await _bll.BaseEntityService<Worker>().AllAsync(), 
                nameof(Worker.Id), 
                nameof(Worker.FirstLastName));
            
            vm.WorkerPositionSelectList = new SelectList(
                await _bll.BaseEntityService<WorkerPosition>().AllAsync(), 
                nameof(WorkerPosition.Id), 
                nameof(WorkerPosition.WorkerPositionValue));
            
            return View(vm);
        }

        // GET: WorkersInPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var workerInPosition = await _bll.WorkersInPositions
//                .Include(w => w.Worker)
//                .Include(w => w.WorkerPosition)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var workerInPosition = await _bll.WorkersInPositions.FindAsync(id);
            
            if (workerInPosition == null)
            {
                return NotFound();
            }

            return View(workerInPosition);
        }

        // POST: WorkersInPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.WorkersInPositions.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
