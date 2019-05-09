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
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly IAppBLL _bll;

        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var payments = await _bll.Payments.AllForUserAsync(User.GetUserId());

            return View(payments);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FindForUserAsync(id.Value, User.GetUserId());

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PaymentCreateEditViewModel();

            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id),
                nameof(BLL.App.DTO.Client.CompanyName));

            vm.PaymentMethodSelectList = new SelectList(
                await _bll.PaymentMethods.AllAsync(),
                nameof(BLL.App.DTO.PaymentMethod.Id),
                nameof(BLL.App.DTO.PaymentMethod.PaymentMethodValue));

            return View(vm);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Payments.AddAsync(vm.Payment);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id),
                nameof(BLL.App.DTO.Client.CompanyName));

            vm.PaymentMethodSelectList = new SelectList(
                await _bll.PaymentMethods.AllAsync(),
                nameof(BLL.App.DTO.PaymentMethod.Id),
                nameof(BLL.App.DTO.PaymentMethod.PaymentMethodValue));
            return View(vm);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FindForUserAsync(id.Value, User.GetUserId());
            if (payment == null)
            {
                return NotFound();
            }

            var vm = new PaymentCreateEditViewModel();
            vm.Payment = payment;

            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id),
                nameof(BLL.App.DTO.Client.CompanyName));

            vm.PaymentMethodSelectList = new SelectList(
                await _bll.PaymentMethods.AllAsync(),
                nameof(BLL.App.DTO.PaymentMethod.Id),
                nameof(BLL.App.DTO.PaymentMethod.PaymentMethodValue));

            return View(vm);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentCreateEditViewModel vm)
        {
            if (id != vm.Payment.Id)
            {
                return NotFound();
            }

            if (!await _bll.Payments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Payments.Update(vm.Payment);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
      
            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(),
                nameof(BLL.App.DTO.Client.Id),
                nameof(BLL.App.DTO.Client.CompanyName));

            vm.PaymentMethodSelectList = new SelectList(
                await _bll.PaymentMethods.AllAsync(),
                nameof(BLL.App.DTO.PaymentMethod.Id),
                nameof(BLL.App.DTO.PaymentMethod.PaymentMethodValue));

            return View(vm);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FindForUserAsync(id.Value, User.GetUserId());

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
            if (!await _bll.Payments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Payments.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}