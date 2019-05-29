#pragma warning disable 1591
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AllClientGroupsController : Controller
    {
        private readonly IAppBLL _bll;

        public AllClientGroupsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: ClientGroups
        public async Task<IActionResult> Index()
        {
            return View(await _bll.ClientGroups.GetAllWithClientCountAsync());
        }

        // GET: ClientGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _bll.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }
            var vm = new WebApp.Areas.Admin.ViewModels.ClientGroupDetailsDeleteViewModel();
            vm.ClientGroup = clientGroup;
            vm.ClientGroup.Clients = await _bll.Clients.AllForClientGroupAsync(id);

            return View(vm);
        }

        // GET: ClientGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,DiscountPercent,Id")] 
            BLL.App.DTO.ClientGroup clientGroup)
        {
            if (ModelState.IsValid)
            {
                await _bll.ClientGroups.AddAsync(clientGroup);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientGroup);
        }

        // GET: ClientGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _bll.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }
            return View(clientGroup);
        }

        // POST: ClientGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,DiscountPercent,Id")] 
            BLL.App.DTO.ClientGroup clientGroup)
        {
            if (id != clientGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _bll.ClientGroups.Update(clientGroup);
                    await _bll.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View(clientGroup);
        }

        // GET: ClientGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _bll.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }
            
            var vm = new WebApp.Areas.Admin.ViewModels.ClientGroupDetailsDeleteViewModel();
            vm.ClientGroup = clientGroup;
            vm.ClientGroup.Clients = await _bll.Clients.AllForClientGroupAsync(id);

            return View(vm);
        }

        // POST: ClientGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.ClientGroups.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
