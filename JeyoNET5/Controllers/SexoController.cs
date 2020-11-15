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
    public class SexoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SexoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sexo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sexo.ToListAsync());
        }

        // GET: Sexo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexo
                .FirstOrDefaultAsync(m => m.SexoId == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // GET: Sexo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SexoId,Nombre")] Sexo sexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sexo);
        }

        // GET: Sexo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexo.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }
            return View(sexo);
        }

        // POST: Sexo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SexoId,Nombre")] Sexo sexo)
        {
            if (id != sexo.SexoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexoExists(sexo.SexoId))
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
            return View(sexo);
        }

        // GET: Sexo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexo = await _context.Sexo
                .FirstOrDefaultAsync(m => m.SexoId == id);
            if (sexo == null)
            {
                return NotFound();
            }

            return View(sexo);
        }

        // POST: Sexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sexo = await _context.Sexo.FindAsync(id);
            _context.Sexo.Remove(sexo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexoExists(int id)
        {
            return _context.Sexo.Any(e => e.SexoId == id);
        }
    }
}
