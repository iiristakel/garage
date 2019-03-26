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
    public class PaymentsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PaymentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var payments = await _uow.Payments.AllAsync();
               
            return View(payments);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _uow.Payments.FindAsync(id);
            
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public async Task<IActionResult> Create()
        {
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr");
            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync(),
                "Id", "Address");
            ViewData["PaymentMethodId"] = new SelectList(await _uow.BaseRepository<PaymentMethod>().AllAsync(),
                "Id", "PaymentMethodValue");
            
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillId,PaymentMethodId,ClientId,Sum,PaymentTime,Id")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                await _uow.Payments.AddAsync(payment);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr", payment.BillId);
            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync(),
                "Id", "Address", payment.ClientId);
            ViewData["PaymentMethodId"] = new SelectList(await _uow.BaseRepository<PaymentMethod>().AllAsync(),
                "Id", "PaymentMethodValue", payment.PaymentMethodId);
            
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _uow.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr", payment.BillId);
            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync(),
                "Id", "Address", payment.ClientId);
            ViewData["PaymentMethodId"] = new SelectList(await _uow.BaseRepository<PaymentMethod>().AllAsync(),
                "Id", "PaymentMethodValue", payment.PaymentMethodId);
            
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,PaymentMethodId,ClientId,Sum,PaymentTime,Id")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _uow.Payments.Update(payment);
                    await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillId"] = new SelectList(await _uow.BaseRepository<Bill>().AllAsync(),
                "Id", "InvoiceNr", payment.BillId);
            ViewData["ClientId"] = new SelectList(await _uow.BaseRepository<Client>().AllAsync()
                , "Id", "Address", payment.ClientId);
            ViewData["PaymentMethodId"] = new SelectList(await _uow.BaseRepository<PaymentMethod>().AllAsync(),
                "Id", "PaymentMethodValue", payment.PaymentMethodId);
            
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _uow.Payments.FindAsync(id);
            
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Payments.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
