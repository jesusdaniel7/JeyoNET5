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
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
           // var lastIngreso = await _context.Ingresos.OrderByDescending(x => x.PacienteId).FirstOrDefaultAsync
            var applicationDbContext = _context.Pacientes.Include(p => p.Sexo).Include(x => x.Ingresos).Include(x => x.Egresos);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //var pacienteDB = await _context.Pacientes.FirstOrDefaultAsync(x => x.PacienteId == id);
            //ViewData["SexoId"] = new SelectList(_context.Sexo, "SexoId", "SexoId", paciente.SexoId);

            //ViewData["Ingresos"] = await _context.Pacientes.Include(x => x.Ingresos).FirstOrDefaultAsync(m => m.PacienteId == id);
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.Sexo)
                 .Include(p => p.Ingresos)
                 .ThenInclude(f => f.Factura)
                 .Include(p => p.Egresos)
                 .Include(p => p.HistorialClinico)
                .FirstOrDefaultAsync(m => m.PacienteId == id);
        
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["SexoId"] = new SelectList(_context.Sexo, "SexoId", "Nombre");
            return View();
        }


        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacienteId,Nombre,Apellido,FechaNacimiento,FechaIngreso,SexoId,Nacionalidad,Cedula_pasaporte,Parentesco,Seguro,Correo,Telefono,Direccion")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Ingresos", new { id = paciente.PacienteId });

            }
            ViewData["SexoId"] = new SelectList(_context.Sexo, "SexoId", "SexoId", paciente.SexoId);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["SexoId"] = new SelectList(_context.Sexo, "SexoId", "SexoId", paciente.SexoId);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacienteId,Nombre,Apellido,FechaNacimiento,FechaIngreso,SexoId,Nacionalidad,Seguro,Correo,Telefono,Direccion")] Paciente paciente)
        {
            if (id != paciente.PacienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.PacienteId))
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
            ViewData["SexoId"] = new SelectList(_context.Sexo, "SexoId", "SexoId", paciente.SexoId);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.Sexo)
                .FirstOrDefaultAsync(m => m.PacienteId == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.PacienteId == id);
        }
    }
}
