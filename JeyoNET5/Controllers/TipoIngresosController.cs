﻿using System;
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
    public class TipoIngresosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoIngresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoIngresos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoIngresos.ToListAsync());
        }

        // GET: TipoIngresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TipoIngresos
                .FirstOrDefaultAsync(m => m.TipoIngresoId == id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // GET: TipoIngresos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIngresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoIngresoId,Nombre")] TipoIngreso tipoIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIngreso);
        }

        // GET: TipoIngresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TipoIngresos.FindAsync(id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }
            return View(tipoIngreso);
        }

        // POST: TipoIngresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoIngresoId,Nombre")] TipoIngreso tipoIngreso)
        {
            if (id != tipoIngreso.TipoIngresoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIngresoExists(tipoIngreso.TipoIngresoId))
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
            return View(tipoIngreso);
        }

        // GET: TipoIngresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TipoIngresos
                .FirstOrDefaultAsync(m => m.TipoIngresoId == id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // POST: TipoIngresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoIngreso = await _context.TipoIngresos.FindAsync(id);
            _context.TipoIngresos.Remove(tipoIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIngresoExists(int id)
        {
            return _context.TipoIngresos.Any(e => e.TipoIngresoId == id);
        }
    }
}
