#pragma warning disable 1591
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllClientsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllClientsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await _bll.Clients.AllAsync();

            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _bll.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public async Task<IActionResult> Create()
        {
            var vm = new Areas.Admin.ViewModels.ClientCreateEditViewModel
            {
                ClientGroupSelectList = new SelectList(
                    await _bll.ClientGroups.AllAsync(),
                    nameof(BLL.App.DTO.ClientGroup.Id),
                    nameof(BLL.App.DTO.ClientGroup.Name))
            };


            return View(vm);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Areas.Admin.ViewModels.ClientCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Clients.Add(vm.Client);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.ClientGroupSelectList = new SelectList(
                await _bll.ClientGroups.AllAsync(),
                nameof(BLL.App.DTO.ClientGroup.Id), 
                nameof(BLL.App.DTO.ClientGroup.Name));

            return View(vm);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _bll.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var vm = new Areas.Admin.ViewModels.ClientCreateEditViewModel();
            
            vm.Client = client;
            vm.ClientGroupSelectList = new SelectList(
                await _bll.ClientGroups.AllAsync(),
                nameof(BLL.App.DTO.ClientGroup.Id), 
                nameof(BLL.App.DTO.ClientGroup.Name));

            return View(vm);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Areas.Admin.ViewModels.ClientCreateEditViewModel vm)
        {
            if (id != vm.Client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Clients.Update(vm.Client);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.ClientGroupSelectList = new SelectList(
                await _bll.ClientGroups.AllAsync(),
                nameof(BLL.App.DTO.ClientGroup.Id), 
                nameof(BLL.App.DTO.ClientGroup.Name));

            return View(vm);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _bll.Clients.FindAsync(id);
            
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Clients.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}