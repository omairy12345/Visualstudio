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
    public class ArticuloesController : Controller
    {
        private readonly newsappContext _context;

        public ArticuloesController(newsappContext context)
        {
            _context = context;
        }

        // GET: Articuloes
        public async Task<IActionResult> Index()
        {
            var newsappContext = _context.Articulos.Include(a => a.IdcategoryNavigation).Include(a => a.IdfuenteNavigation).Include(a => a.IdpaisNavigation);
            return View(await newsappContext.ToListAsync());
        }

        // GET: Articuloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.IdcategoryNavigation)
                .Include(a => a.IdfuenteNavigation)
                .Include(a => a.IdpaisNavigation)
                .FirstOrDefaultAsync(m => m.Idarticulo == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articuloes/Create
        public IActionResult Create()
        {
            ViewData["Idcategory"] = new SelectList(_context.Categories, "Idcategory", "Idcategory");
            ViewData["Idfuente"] = new SelectList(_context.Fuentes, "Idfuente", "Idfuente");
            ViewData["Idpais"] = new SelectList(_context.Paises, "Idpais", "Idpais");
            return View();
        }

        // POST: Articuloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idarticulo,Titulo,Contenido,ImagenUrl,Descripcion,Autor,Fechapublicacion,Idcategory,Idpais,Idfuente")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategory"] = new SelectList(_context.Categories, "Idcategory", "Idcategory", articulo.Idcategory);
            ViewData["Idfuente"] = new SelectList(_context.Fuentes, "Idfuente", "Idfuente", articulo.Idfuente);
            ViewData["Idpais"] = new SelectList(_context.Paises, "Idpais", "Idpais", articulo.Idpais);
            return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["Idcategory"] = new SelectList(_context.Categories, "Idcategory", "Idcategory", articulo.Idcategory);
            ViewData["Idfuente"] = new SelectList(_context.Fuentes, "Idfuente", "Idfuente", articulo.Idfuente);
            ViewData["Idpais"] = new SelectList(_context.Paises, "Idpais", "Idpais", articulo.Idpais);
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idarticulo,Titulo,Contenido,ImagenUrl,Descripcion,Autor,Fechapublicacion,Idcategory,Idpais,Idfuente")] Articulo articulo)
        {
            if (id != articulo.Idarticulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.Idarticulo))
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
            ViewData["Idcategory"] = new SelectList(_context.Categories, "Idcategory", "Idcategory", articulo.Idcategory);
            ViewData["Idfuente"] = new SelectList(_context.Fuentes, "Idfuente", "Idfuente", articulo.Idfuente);
            ViewData["Idpais"] = new SelectList(_context.Paises, "Idpais", "Idpais", articulo.Idpais);
            return View(articulo);
        }

        // GET: Articuloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.IdcategoryNavigation)
                .Include(a => a.IdfuenteNavigation)
                .Include(a => a.IdpaisNavigation)
                .FirstOrDefaultAsync(m => m.Idarticulo == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.Idarticulo == id);
        }
    }
}
