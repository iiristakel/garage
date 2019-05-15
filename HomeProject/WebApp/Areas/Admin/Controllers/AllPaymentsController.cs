#pragma warning disable 1591
using System.Threading.Tasks;
using Contracts.BLL.App;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllPaymentsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllPaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var payments = await _bll.Payments.AllAsync();

            return View(payments);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FindAsync(id.Value, User.GetUserId());

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
                await _bll.Bills.AllAsync(),
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
                await _bll.Bills.AllAsync(),
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

            var payment = await _bll.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            var vm = new PaymentCreateEditViewModel();
            vm.Payment = payment;

            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllAsync(),
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

           

            if (ModelState.IsValid)
            {
                _bll.Payments.Update(vm.Payment);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
      
            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllAsync(),
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

            var payment = await _bll.Payments.FindAsync(id);

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
           
            
            _bll.Payments.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}