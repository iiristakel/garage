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
using Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ClientsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await _uow.Clients.AllAsync();

            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var client = await _context.Clients
//                .Include(c => c.ClientGroup)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var client = await _uow.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ClientGroupId"] = new SelectList(
                await _uow.BaseRepository<ClientGroup>().AllAsync(),
                "Id", "Name");

            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientGroupId,CompanyName,Address,Phone,ContactPerson,Id")]
            Client client)
        {
            if (ModelState.IsValid)
            {
                await _uow.Clients.AddAsync(client);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClientGroupId"] = new SelectList(
                await _uow.BaseRepository<ClientGroup>().AllAsync(),
                "Id", "Name", client.ClientGroupId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _uow.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            ViewData["ClientGroupId"] = new SelectList(
                await _uow.BaseRepository<ClientGroup>().AllAsync(),
                "Id", "Name", client.ClientGroupId);

            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientGroupId,CompanyName,Address,Phone,ContactPerson,Id")]
            Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Clients.Update(client);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClientGroupId"] = new SelectList(
                await _uow.BaseRepository<ClientGroup>().AllAsync(), 
                "Id", "Name", client.ClientGroupId);
            
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var client = await _context.Clients
//                .Include(c => c.ClientGroup)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var client = await _uow.Clients.FindAsync(id);
            
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
            _uow.Clients.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}