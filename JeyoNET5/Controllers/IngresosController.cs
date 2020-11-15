﻿using System;
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
    public class IngresosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ingresos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ingresos.Include(i => i.Paciente).Include(i => i.TipoIngreso).Include(i => i.Unidad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ingresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingresos
                .Include(i => i.Paciente)
                .Include(i => i.TipoIngreso)
                .Include(i => i.Unidad)
                .FirstOrDefaultAsync(m => m.IngresoId == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

        // GET: Ingresos/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId");
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "TipoIngresoId", "TipoIngresoId");
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "Id");
            return View();
        }

        // POST: Ingresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngresoId,FechaIngreso,TipoIngresoId,PacienteId,UnidadId,estado")] Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", ingreso.PacienteId);
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "TipoIngresoId", "TipoIngresoId", ingreso.TipoIngresoId);
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "Id", ingreso.UnidadId);
            return View(ingreso);
        }

        // GET: Ingresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingresos.FindAsync(id);
            if (ingreso == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", ingreso.PacienteId);
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "TipoIngresoId", "TipoIngresoId", ingreso.TipoIngresoId);
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "Id", ingreso.UnidadId);
            return View(ingreso);
        }

        // POST: Ingresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngresoId,FechaIngreso,TipoIngresoId,PacienteId,UnidadId,estado")] Ingreso ingreso)
        {
            if (id != ingreso.IngresoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngresoExists(ingreso.IngresoId))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "PacienteId", ingreso.PacienteId);
            ViewData["TipoIngresoId"] = new SelectList(_context.TipoIngresos, "TipoIngresoId", "TipoIngresoId", ingreso.TipoIngresoId);
            ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "Id", ingreso.UnidadId);
            return View(ingreso);
        }

        // GET: Ingresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingresos
                .Include(i => i.Paciente)
                .Include(i => i.TipoIngreso)
                .Include(i => i.Unidad)
                .FirstOrDefaultAsync(m => m.IngresoId == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingreso = await _context.Ingresos.FindAsync(id);
            _context.Ingresos.Remove(ingreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(e => e.IngresoId == id);
        }
    }
}
