using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JeyoNET5.Data;
using JeyoNET5.Models;

namespace JeyoNET5.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Facturas.Include(f => f.Ingreso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Ingreso)
                .FirstOrDefaultAsync(m => m.FacturaId == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public async Task<IActionResult> Create(int? id)
        {
            var exists = await _context.Facturas.AnyAsync(x => x.IngresoId == id);
            if (exists) { return NotFound("La factura ya existe"); }

            ViewBag.Ingreso = await _context.Ingresos.Include(x => x.Paciente).FirstOrDefaultAsync(x => x.IngresoId == id);
            ViewBag.Monto = _context.Servicios.Where(x => x.IngresoId == id).Sum(x => x.Monto);

            if (id == null) { return NotFound("No has ingresado el ingreso"); }
            ViewBag.id = id;
            ViewData["IngresoId"] = new SelectList(_context.Ingresos, "IngresoId", "IngresoId");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacturaId,Fecha,Monto,Descuento,IngresoId")] Factura factura)
        {
            factura.Codigo = $"jeyo{factura.IngresoId}{factura.Fecha}";
            factura.Estado = true;
            var exists = await _context.Facturas.AnyAsync(x => x.IngresoId == factura.IngresoId);
            if (exists) { return NotFound("La factura ya existe"); }
            factura.Total = factura.Monto - (factura.Monto * factura.Descuento / 100);

           
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngresoId"] = new SelectList(_context.Ingresos, "IngresoId", "IngresoId", factura.IngresoId);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IngresoId"] = new SelectList(_context.Ingresos, "IngresoId", "IngresoId", factura.IngresoId);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacturaId,Codigo,Fecha,Monto,Descuento,Total,Estado,IngresoId")] Factura factura)
        {
            if (id != factura.FacturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.FacturaId))
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
            ViewData["IngresoId"] = new SelectList(_context.Ingresos, "IngresoId", "IngresoId", factura.IngresoId);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.Ingreso)
                .FirstOrDefaultAsync(m => m.FacturaId == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.FacturaId == id);
        }
    }
}
