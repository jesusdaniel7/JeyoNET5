using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jeyo.Models;
using JeyoNET5.Data;

namespace JeyoNET5.Controllers
{
    public class TipoEgresosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoEgresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoEgresos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEgresos.ToListAsync());
        }

        // GET: TipoEgresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEgreso = await _context.TipoEgresos
                .FirstOrDefaultAsync(m => m.TipoEgresoId == id);
            if (tipoEgreso == null)
            {
                return NotFound();
            }

            return View(tipoEgreso);
        }

        // GET: TipoEgresos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEgresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoEgresoId,Nombre")] TipoEgreso tipoEgreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEgreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEgreso);
        }

        // GET: TipoEgresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEgreso = await _context.TipoEgresos.FindAsync(id);
            if (tipoEgreso == null)
            {
                return NotFound();
            }
            return View(tipoEgreso);
        }

        // POST: TipoEgresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoEgresoId,Nombre")] TipoEgreso tipoEgreso)
        {
            if (id != tipoEgreso.TipoEgresoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEgreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEgresoExists(tipoEgreso.TipoEgresoId))
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
            return View(tipoEgreso);
        }

        // GET: TipoEgresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEgreso = await _context.TipoEgresos
                .FirstOrDefaultAsync(m => m.TipoEgresoId == id);
            if (tipoEgreso == null)
            {
                return NotFound();
            }

            return View(tipoEgreso);
        }

        // POST: TipoEgresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEgreso = await _context.TipoEgresos.FindAsync(id);
            _context.TipoEgresos.Remove(tipoEgreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEgresoExists(int id)
        {
            return _context.TipoEgresos.Any(e => e.TipoEgresoId == id);
        }
    }
}
