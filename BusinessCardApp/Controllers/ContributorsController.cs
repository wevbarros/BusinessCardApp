using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessCardApp.Models;
using VirtualCard.Models;

namespace BusinessCardApp.Controllers
{
    public class ContributorsController : Controller
    {
        private readonly Context _context;

        public ContributorsController(Context context)
        {
            _context = context;
        }

        // GET: Contributors
        public async Task<IActionResult> Index()
        {
              return View(await _context.contributors.ToListAsync());
        }

        // GET: Contributors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.contributors == null)
            {
                return NotFound();
            }

            var contributor = await _context.contributors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contributor == null)
            {
                return NotFound();
            }

            return View(contributor);
        }

        // GET: Contributors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contributors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SurName,Office,Telephone")] Contributor contributor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contributor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contributor);
        }

        // GET: Contributors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.contributors == null)
            {
                return NotFound();
            }

            var contributor = await _context.contributors.FindAsync(id);
            if (contributor == null)
            {
                return NotFound();
            }
            return View(contributor);
        }

        // POST: Contributors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SurName,Office,Telephone")] Contributor contributor)
        {
            if (id != contributor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contributor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContributorExists(contributor.Id))
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
            return View(contributor);
        }

        // GET: Contributors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.contributors == null)
            {
                return NotFound();
            }

            var contributor = await _context.contributors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contributor == null)
            {
                return NotFound();
            }

            return View(contributor);
        }

        // POST: Contributors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.contributors == null)
            {
                return Problem("Entity set 'Context.contributors'  is null.");
            }
            var contributor = await _context.contributors.FindAsync(id);
            if (contributor != null)
            {
                _context.contributors.Remove(contributor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContributorExists(int id)
        {
          return _context.contributors.Any(e => e.Id == id);
        }
    }
}
