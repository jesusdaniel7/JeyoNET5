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
    public class HistorialClinicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistorialClinicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HistorialClinico
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HistorialClinico.Include(h => h.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HistorialClinico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialClinico = await _context.HistorialClinico
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.HistorialClinicoId == id);
            if (historialClinico == null)
            {
                return NotFound();
            }

            return View(historialClinico);
        }

        // GET: HistorialClinico/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId");
            return View();
        }

        // POST: HistorialClinico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistorialClinicoId,PacienteId,Detallles")] HistorialClinico historialClinico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialClinico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", historialClinico.PacienteId);
            return View(historialClinico);
        }

        // GET: HistorialClinico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialClinico = await _context.HistorialClinico.FindAsync(id);
            if (historialClinico == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", historialClinico.PacienteId);
            return View(historialClinico);
        }

        // POST: HistorialClinico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistorialClinicoId,PacienteId,Detallles")] HistorialClinico historialClinico)
        {
            if (id != historialClinico.HistorialClinicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialClinico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialClinicoExists(historialClinico.HistorialClinicoId))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", historialClinico.PacienteId);
            return View(historialClinico);
        }

        // GET: HistorialClinico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialClinico = await _context.HistorialClinico
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.HistorialClinicoId == id);
            if (historialClinico == null)
            {
                return NotFound();
            }

            return View(historialClinico);
        }

        // POST: HistorialClinico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialClinico = await _context.HistorialClinico.FindAsync(id);
            _context.HistorialClinico.Remove(historialClinico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialClinicoExists(int id)
        {
            return _context.HistorialClinico.Any(e => e.HistorialClinicoId == id);
        }
    }
}
