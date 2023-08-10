using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPicos2.Context;
using ProjetoPicos2.Models;

namespace ProjetoPicos2.Controllers
{
    public class PicoController : Controller
    {
        private readonly PicoContext _context;

        public PicoController(PicoContext context)
        {
            _context = context;
        }

        // GET: Pico
        public async Task<IActionResult> Index()
        {
              return _context.Picos != null ? 
                          View(await _context.Picos.ToListAsync()) :
                          Problem("Entity set 'PicoContext.Picos'  is null.");
        }

        // GET: Pico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Picos == null)
            {
                return NotFound();
            }

            var pico = await _context.Picos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pico == null)
            {
                return NotFound();
            }

            return View(pico);
        }

        // GET: Pico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,Rate,AccsessType,Localization,Active")] Pico pico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pico);
        }

        // GET: Pico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Picos == null)
            {
                return NotFound();
            }

            var pico = await _context.Picos.FindAsync(id);
            if (pico == null)
            {
                return NotFound();
            }
            return View(pico);
        }

        // POST: Pico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,Rate,AccsessType,Localization,Active")] Pico pico)
        {
            if (id != pico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PicoExists(pico.Id))
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
            return View(pico);
        }

        // GET: Pico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Picos == null)
            {
                return NotFound();
            }

            var pico = await _context.Picos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pico == null)
            {
                return NotFound();
            }

            return View(pico);
        }

        // POST: Pico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Picos == null)
            {
                return Problem("Entity set 'PicoContext.Picos'  is null.");
            }
            var pico = await _context.Picos.FindAsync(id);
            if (pico != null)
            {
                _context.Picos.Remove(pico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PicoExists(int id)
        {
          return (_context.Picos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
