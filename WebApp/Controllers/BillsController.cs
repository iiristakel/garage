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
using Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class BillsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public BillsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var bills = await _uow.Bills.AllAsync();
            
            return View(bills);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _uow.Bills.FindAsync(id);
            
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
                await _uow.BaseRepository<Client>().AllAsync(), 
                nameof(Client.Id), 
                nameof(Client.CompanyName));
            
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
                await _uow.Bills.AddAsync(vm.Bill);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            vm.ClientSelectList = new SelectList(
                await _uow.BaseRepository<Client>().AllAsync(), 
                nameof(Client.Id), 
                nameof(Client.CompanyName));
            
            return View(vm);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _uow.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            
            var vm = new BillCreateEditViewModel();
            vm.Bill = bill;
            vm.ClientSelectList = new SelectList(
                await _uow.BaseRepository<Client>().AllAsync(), 
                nameof(Client.Id), 
                nameof(Client.CompanyName));
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

            if (ModelState.IsValid)
            {
                _uow.Bills.Update(vm.Bill);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            vm.ClientSelectList = new SelectList(
                await _uow.BaseRepository<Client>().AllAsync(), 
                nameof(Client.Id), 
                nameof(Client.CompanyName));
            
            return View(vm);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _uow.Bills.FindAsync(id);
            
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
            _uow.Bills.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
