using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newsapplibrary.Data;
using Newsapplibrary.Models;

namespace newsAPP.Controllers
{
    public class FuentesController : Controller
    {
        private readonly newsappContext _context;

        public FuentesController(newsappContext context)
        {
            _context = context;
        }

        // GET: Fuentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fuentes.ToListAsync());
        }

        // GET: Fuentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuente = await _context.Fuentes
                .FirstOrDefaultAsync(m => m.Idfuente == id);
            if (fuente == null)
            {
                return NotFound();
            }

            return View(fuente);
        }

        // GET: Fuentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fuentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfuente,Nombrefuente")] Fuente fuente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuente);
        }

        // GET: Fuentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuente = await _context.Fuentes.FindAsync(id);
            if (fuente == null)
            {
                return NotFound();
            }
            return View(fuente);
        }

        // POST: Fuentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfuente,Nombrefuente")] Fuente fuente)
        {
            if (id != fuente.Idfuente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuenteExists(fuente.Idfuente))
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
            return View(fuente);
        }

        // GET: Fuentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuente = await _context.Fuentes
                .FirstOrDefaultAsync(m => m.Idfuente == id);
            if (fuente == null)
            {
                return NotFound();
            }

            return View(fuente);
        }

        // POST: Fuentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuente = await _context.Fuentes.FindAsync(id);
            _context.Fuentes.Remove(fuente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuenteExists(int id)
        {
            return _context.Fuentes.Any(e => e.Idfuente == id);
        }
    }
}
