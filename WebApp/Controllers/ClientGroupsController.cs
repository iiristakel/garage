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
    public class ClientGroupsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ClientGroupsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ClientGroups
        public async Task<IActionResult> Index()
        {
            return View(await _uow.ClientGroups.AllAsync());
        }

        // GET: ClientGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _uow.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
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
        public async Task<IActionResult> Create([Bind("Name,Description,DiscountPercent,Id")] ClientGroup clientGroup)
        {
            if (ModelState.IsValid)
            {
                await _uow.ClientGroups.AddAsync(clientGroup);
                await _uow.SaveChangesAsync();
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

            var clientGroup = await _uow.ClientGroups.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,DiscountPercent,Id")] ClientGroup clientGroup)
        {
            if (id != clientGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _uow.ClientGroups.Update(clientGroup);
                    await _uow.SaveChangesAsync();
               
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

            var clientGroup = await _uow.ClientGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
        }

        // POST: ClientGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.ClientGroups.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
