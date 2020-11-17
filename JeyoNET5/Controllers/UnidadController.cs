using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JeyoNET5.Models;
using JeyoNET5.Data;

namespace JeyoNET5.Controllers
{
    public class UnidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Unidads
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Unidades.Include(u => u.TipoUnidad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Unidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades
                .Include(u => u.TipoUnidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidads/Create
        public IActionResult Create()
        {
            ViewData["TipoUnidadId"] = new SelectList(_context.TipoUnidad, "Id", "Id");
            return View();
        }

        // POST: Unidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Piso,NumeroHabitacion,TipoUnidadId")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoUnidadId"] = new SelectList(_context.TipoUnidad, "Id", "Id", unidad.TipoUnidadId);
            return View(unidad);
        }

        // GET: Unidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }
            ViewData["TipoUnidadId"] = new SelectList(_context.TipoUnidad, "Id", "Id", unidad.TipoUnidadId);
            return View(unidad);
        }

        // POST: Unidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Piso,NumeroHabitacion,TipoUnidadId")] Unidad unidad)
        {
            if (id != unidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.Id))
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
            ViewData["TipoUnidadId"] = new SelectList(_context.TipoUnidad, "Id", "Id", unidad.TipoUnidadId);
            return View(unidad);
        }

        // GET: Unidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades
                .Include(u => u.TipoUnidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidad = await _context.Unidades.FindAsync(id);
            _context.Unidades.Remove(unidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
            return _context.Unidades.Any(e => e.Id == id);
        }
    }
}
