#pragma warning disable 1591
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity;
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
            var workObjects = await _bll.WorkObjects.AllForUserAsync(User.GetUserId());

            return View(workObjects);
        }

        // GET: WorkObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workObject = await _bll.WorkObjects.FindForUserAsync(id.Value, User.GetUserId());

            if (workObject == null)
            {
                return NotFound();
            }

            return View(workObject);
        }

        // GET: WorkObjects/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WorkObjectCreateEditViewModel
            {
                ClientSelectList = new SelectList(
                    await _bll.Clients.AllAsync(),
                    nameof(BLL.App.DTO.Client.Id),
                    nameof(BLL.App.DTO.Client.CompanyName))
            };


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

            var workObject = await _bll.WorkObjects.FindForUserAsync(id.Value, User.GetUserId());
            if (workObject == null)
            {
                return NotFound();
            }

            var vm = new WorkObjectCreateEditViewModel();
            
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
        public async Task<IActionResult> Edit(int id, WorkObjectCreateEditViewModel vm)
        {
            if (id != vm.WorkObject.Id)
            {
                return NotFound();
            }
            
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
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

            var workObject = await _bll.WorkObjects.FindForUserAsync(id.Value, User.GetUserId());
            
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
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.WorkObjects.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}