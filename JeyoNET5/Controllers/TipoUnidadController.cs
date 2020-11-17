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
    public class TipoUnidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoUnidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoUnidads
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoUnidad.ToListAsync());
        }

        // GET: TipoUnidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUnidad = await _context.TipoUnidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoUnidad == null)
            {
                return NotFound();
            }

            return View(tipoUnidad);
        }

        // GET: TipoUnidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUnidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoUnidad tipoUnidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUnidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUnidad);
        }

        // GET: TipoUnidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUnidad = await _context.TipoUnidad.FindAsync(id);
            if (tipoUnidad == null)
            {
                return NotFound();
            }
            return View(tipoUnidad);
        }

        // POST: TipoUnidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoUnidad tipoUnidad)
        {
            if (id != tipoUnidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUnidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUnidadExists(tipoUnidad.Id))
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
            return View(tipoUnidad);
        }

        // GET: TipoUnidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUnidad = await _context.TipoUnidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoUnidad == null)
            {
                return NotFound();
            }

            return View(tipoUnidad);
        }

        // POST: TipoUnidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoUnidad = await _context.TipoUnidad.FindAsync(id);
            _context.TipoUnidad.Remove(tipoUnidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUnidadExists(int id)
        {
            return _context.TipoUnidad.Any(e => e.Id == id);
        }
    }
}
