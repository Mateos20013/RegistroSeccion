using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroSeccion.Data;
using RegistroSeccion.Models;

namespace RegistroSeccion.Controllers
{
    public class AsignacionsController : Controller
    {
        private readonly RegistroSeccionContext _context;

        public AsignacionsController(RegistroSeccionContext context)
        {
            _context = context;
        }

        // GET: Asignacions
        public async Task<IActionResult> Index()
        {
            var registroSeccionContext = _context.Asignacion.Include(a => a.Carrera);
            return View(await registroSeccionContext.ToListAsync());
        }

        // GET: Asignacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: Asignacions/Create
        public IActionResult Create()
        {
            ViewData["IdCarrera"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "Nombre");
            return View();
        }

        // POST: Asignacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,Nombre,IdCarrera")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarrera"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "Nombre", asignacion.IdCarrera);
            return View(asignacion);
        }

        // GET: Asignacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["IdCarrera"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "Nombre", asignacion.IdCarrera);
            return View(asignacion);
        }

        // POST: Asignacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,Nombre,IdCarrera")] Asignacion asignacion)
        {
            if (id != asignacion.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.IdAsignacion))
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
            ViewData["IdCarrera"] = new SelectList(_context.Set<Carrera>(), "IdCarrera", "Nombre", asignacion.IdCarrera);
            return View(asignacion);
        }

        // GET: Asignacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignacion.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignacion.Remove(asignacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignacion.Any(e => e.IdAsignacion == id);
        }
    }
}
