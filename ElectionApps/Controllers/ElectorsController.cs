using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectionApps.Data;
using ElectionApps.Models;

namespace ElectionApps.Controllers
{
    [Route("Electors")]
    [Route("")]
    public class ElectorsController : Controller
    {
        private readonly ElectionContext _context;

        public ElectorsController(ElectionContext context)
        {
            _context = context;
        }

        // GET: Electors
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Electors.ToListAsync());
        }

        // GET: Electors/Details/5
        [Route("Details/{id?}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elector = await _context.Electors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (elector == null)
            {
                return NotFound();
            }

            return View(elector);
        }

        // GET: Electors/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Electors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,CinNumber,Address,Fokontany,VotePlaceName")] Elector elector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(elector);
        }

        // GET: Electors/Edit/5
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elector = await _context.Electors.SingleOrDefaultAsync(m => m.Id == id);
            if (elector == null)
            {
                return NotFound();
            }
            return View(elector);
        }

        // POST: Electors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,CinNumber,Address,Fokontany,VotePlaceName")] Elector elector)
        {
            if (id != elector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectorExists(elector.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(elector);
        }

        // GET: Electors/Delete/5
        [Route("Delete/{id?}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elector = await _context.Electors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (elector == null)
            {
                return NotFound();
            }

            return View(elector);
        }

        // POST: Electors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id?}")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var elector = await _context.Electors.SingleOrDefaultAsync(m => m.Id == id);
            _context.Electors.Remove(elector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectorExists(long id)
        {
            return _context.Electors.Any(e => e.Id == id);
        }
    }
}
