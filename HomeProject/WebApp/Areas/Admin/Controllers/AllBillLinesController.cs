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
    public class AllBillLinesController : Controller
    {
        private readonly IAppBLL _bll;

        public AllBillLinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: BillLines
        public async Task<IActionResult> Index()
        {
            var billLines = await _bll.BillLines.AllAsync();
            return View(billLines);
        }

        // GET: BillLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billLine = await _bll.BillLines.FindAsync(id.Value);

            if (billLine == null)
            {
                return NotFound();
            }

            return View(billLine);
        }

        // GET: BillLines/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WebApp.Areas.Admin.ViewModels.BillLineCreateEditViewModel();
            
            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllAsync(),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

            return View(vm);
        }

        // POST: BillLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebApp.Areas.Admin.ViewModels.BillLineCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.BillLines.Add(vm.BillLine);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllAsync(),
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

            var billLine = await _bll.BillLines.FindAsync(id.Value);
            if (billLine == null)
            {
                return NotFound();
            }

            var vm = new WebApp.Areas.Admin.ViewModels.BillLineCreateEditViewModel();
            
            vm.BillLine = billLine;
            vm.BillSelectList = new SelectList(
                await _bll.Bills.AllAsync(),
                nameof(BLL.App.DTO.Bill.Id),
                nameof(BLL.App.DTO.Bill.InvoiceNr));

            return View(vm);
        }

        // POST: BillLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebApp.Areas.Admin.ViewModels.BillLineCreateEditViewModel vm)
        {
            if (id != vm.BillLine.Id)
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
                await _bll.Bills.AllAsync(),
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

            var billLine = await _bll.BillLines.FindAsync(id.Value);
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
            
            
            _bll.BillLines.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}