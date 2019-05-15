#pragma warning disable 1591
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllBillsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllBillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var bills = await _bll.Bills.AllAsync();
            
            return View(bills);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _bll.Bills.FindAsync(id);
            
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public async Task<IActionResult> Create()
        {
            var vm = new WebApp.Areas.Admin.ViewModels.BillCreateEditViewModel();
            
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(), 
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));

            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            return View(vm);
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebApp.Areas.Admin.ViewModels.BillCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Bills.Add(vm.Bill);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(), 
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));

            return View(vm);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _bll.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            
            var vm = new WebApp.Areas.Admin.ViewModels.BillCreateEditViewModel();
            
            vm.Bill = bill;
            vm.ClientSelectList = new SelectList(
                await _bll.Clients.AllAsync(), 
                nameof(BLL.App.DTO.Client.Id), 
                nameof(BLL.App.DTO.Client.CompanyName));
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            return View(vm);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WebApp.Areas.Admin.ViewModels.BillCreateEditViewModel vm)
        {
            if (id != vm.Bill.Id)
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
            
            vm.AppUserSelectList = new SelectList(
                await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.FirstLastName));
            
            return View(vm);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _bll.Bills.FindAsync(id);
            
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
            
            _bll.Bills.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
