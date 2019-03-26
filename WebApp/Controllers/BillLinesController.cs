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
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr");
            ViewData["ProductForClientId"] = new SelectList(await _uow.BaseRepository<ProductForClient>().AllAsync(),
                "Id", "Id");
            return View();
        }

        // POST: BillLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillId,ProductForObjectId,Sum,Amount,DiscountPercent,SumWithDiscount,TaxPercent,FinalSum,Id")] BillLine billLine)
        {
            if (ModelState.IsValid)
            {
                await _uow.BillLines.AddAsync(billLine);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr", billLine.BillId);
            ViewData["ProductForObjectId"] = new SelectList(await _uow.BaseRepository<ProductForClient>().AllAsync(),
                "Id", "Id", billLine.ProductForClientId);
            
            return View(billLine);
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
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr", billLine.BillId);
            ViewData["ProductForObjectId"] = new SelectList(await _uow.BaseRepository<ProductForClient>().AllAsync(),
                "Id", "Id", billLine.ProductForClientId);
            
            return View(billLine);
        }

        // POST: BillLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,ProductForObjectId,Sum,Amount,DiscountPercent,SumWithDiscount,TaxPercent,FinalSum,Id")] BillLine billLine)
        {
            if (id != billLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _uow.BillLines.Update(billLine);
                    await _uow.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr", billLine.BillId);
            ViewData["ProductForObjectId"] = new SelectList(await _uow.BaseRepository<ProductForClient>().AllAsync(),
                "Id", "Id", billLine.ProductForClientId);
            
            return View(billLine);
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
