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
using Microsoft.AspNetCore.Authorization;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class BillLinesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public BillLinesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: BillLines
        public async Task<IActionResult> Index()
        {
            var billLines = await _uow.BillLines.AllAsync();
            return View(billLines);
        }

        // GET: BillLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _uow.BillLines.FindAsync(id);

            if (billLine == null)
            {
                return NotFound();
            }

            return View(billLine);
        }

        // GET: BillLines/Create
        public async Task<IActionResult> Create()
        {
            var vm = new BillLineCreateEditViewModel();
            
            vm.BillSelectList = new SelectList(
                await _uow.BaseRepository<Bill>().AllAsync(),
                nameof(Bill.Id),
                nameof(Bill.InvoiceNr),
                vm.BillLine.BillId);

            return View(vm);
        }

        // POST: BillLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillLineCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.BillLines.AddAsync(vm.BillLine);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.BillSelectList = new SelectList(
                await _uow.BaseRepository<Bill>().AllAsync(),
                nameof(Bill.Id),
                nameof(Bill.InvoiceNr),
                vm.BillLine.BillId);


            return View(vm);
        }

        // GET: BillLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _uow.BillLines.FindAsync(id);
            if (billLine == null)
            {
                return NotFound();
            }

            var vm = new BillLineCreateEditViewModel();
            vm.BillLine = billLine;
            vm.BillSelectList = new SelectList(
                await _uow.BaseRepository<Bill>().AllAsync(),
                nameof(Bill.Id),
                nameof(Bill.InvoiceNr),
                vm.BillLine.BillId);

            return View(vm);
        }

        // POST: BillLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BillLineCreateEditViewModel vm)
        {
            if (id != vm.BillLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.BillLines.Update(vm.BillLine);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.BillSelectList = new SelectList(
                await _uow.BaseRepository<Bill>().AllAsync(),
                nameof(Bill.Id),
                nameof(Bill.InvoiceNr),
                vm.BillLine.BillId);


            return View(vm);
        }

        // GET: BillLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _uow.BillLines.FindAsync(id);
            if (billLine == null)
            {
                return NotFound();
            }

            return View(billLine);
        }

        // POST: BillLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.BillLines.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}