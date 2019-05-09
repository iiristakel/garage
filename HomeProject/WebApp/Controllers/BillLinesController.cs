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
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class BillLinesController : Controller
    {
        private readonly IAppBLL _bll;

        public BillLinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: BillLines
        public async Task<IActionResult> Index()
        {
            var billLines = await _bll.BillLines.AllForUserAsync(User.GetUserId());
            return View(billLines);
        }

        // GET: BillLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _bll.BillLines.FindForUserAsync(id.Value, User.GetUserId());

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
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

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
                _bll.BillLines.Add(vm.BillLine);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));


            return View(vm);
        }

        // GET: BillLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _bll.BillLines.FindForUserAsync(id.Value, User.GetUserId());
            if (billLine == null)
            {
                return NotFound();
            }

            var vm = new BillLineCreateEditViewModel();
            
            vm.BillLine = billLine;
            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

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
            
            if (!await _bll.BillLines.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.BillLines.Update(vm.BillLine);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));


            return View(vm);
        }

        // GET: BillLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _bll.BillLines.FindForUserAsync(id.Value, User.GetUserId());
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
            
            if (!await _bll.WorkObjects.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            _bll.BillLines.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}