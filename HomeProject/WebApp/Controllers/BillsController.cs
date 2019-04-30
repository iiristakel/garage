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
using Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class BillsController : Controller
    {
        private readonly IAppBLL _bll;

        public BillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var bills = await _bll.Bills.AllForUserAsync(User.GetUserId());
            
            return View(bills);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _bll.Bills.FindForUserAsync(id.Value, User.GetUserId());
            
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public async Task<IActionResult> Create()
        {
            var vm = new BillCreateEditViewModel();
            
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(), 
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            return View(vm);
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Bills.AddAsync(vm.Bill);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(), 
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            return View(vm);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _bll.Bills.FindForUserAsync(id.Value, User.GetUserId());
            if (bill == null)
            {
                return NotFound();
            }
            
            var vm = new BillCreateEditViewModel();
            
            vm.Bill = bill;
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(), 
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            return View(vm);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BillCreateEditViewModel vm)
        {
            if (id != vm.Bill.Id)
            {
                return NotFound();
            }
            
            if (!await _bll.Bills.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Bills.Update(vm.Bill);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(), 
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            return View(vm);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _bll.Bills.FindForUserAsync(id.Value, User.GetUserId());
            
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await _bll.Bills.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Bills.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
