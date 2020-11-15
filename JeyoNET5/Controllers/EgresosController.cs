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
    public class EgresosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EgresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Egresos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Egreso.Include(e => e.Pacientes).Include(e => e.TipoEgresos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Egresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egreso
                .Include(e => e.Pacientes)
                .Include(e => e.TipoEgresos)
                .FirstOrDefaultAsync(m => m.EgresoId == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // GET: Egresos/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId");
            ViewData["TipoEgresoId"] = new SelectList(_context.TipoEgresos, "TipoEgresoId", "TipoEgresoId");
            return View();
        }

        // POST: Egresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EgresoId,FechaEgreso,TipoEgresoId,PacienteId,estado")] Egreso egreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", egreso.PacienteId);
            ViewData["TipoEgresoId"] = new SelectList(_context.TipoEgresos, "TipoEgresoId", "TipoEgresoId", egreso.TipoEgresoId);
            return View(egreso);
        }

        // GET: Egresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egreso.FindAsync(id);
            if (egreso == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", egreso.PacienteId);
            ViewData["TipoEgresoId"] = new SelectList(_context.TipoEgresos, "TipoEgresoId", "TipoEgresoId", egreso.TipoEgresoId);
            return View(egreso);
        }

        // POST: Egresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EgresoId,FechaEgreso,TipoEgresoId,PacienteId,estado")] Egreso egreso)
        {
            if (id != egreso.EgresoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgresoExists(egreso.EgresoId))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", egreso.PacienteId);
            ViewData["TipoEgresoId"] = new SelectList(_context.TipoEgresos, "TipoEgresoId", "TipoEgresoId", egreso.TipoEgresoId);
            return View(egreso);
        }

        // GET: Egresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egreso
                .Include(e => e.Pacientes)
                .Include(e => e.TipoEgresos)
                .FirstOrDefaultAsync(m => m.EgresoId == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // POST: Egresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var egreso = await _context.Egreso.FindAsync(id);
            _context.Egreso.Remove(egreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgresoExists(int id)
        {
            return _context.Egreso.Any(e => e.EgresoId == id);
        }
    }
}
