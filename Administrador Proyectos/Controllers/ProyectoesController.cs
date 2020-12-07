using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Administrador_Proyectos.Data;
using Administrador_Proyectos.Models;

namespace Administrador_Proyectos.Controllers
{
    public class ProyectoesController : Controller
    {
        private readonly Administrador_ProyectosContext _context;

        public ProyectoesController(Administrador_ProyectosContext context)
        {
            _context = context;
        }

        // GET: Proyectoes
        public async Task<IActionResult> Index()
        {
            var administrador_ProyectosContext = _context.Proyecto.Include(p => p.Compañia).Include(p => p.Responsable);
            return View(await administrador_ProyectosContext.ToListAsync());
        }

        // GET: Proyectoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyecto
                .Include(p => p.Compañia)
                .Include(p => p.Responsable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public IActionResult Create()
        {
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion");
            ViewData["ResponsableID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido");
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResponsableID,CompañiaID,PorcentajeCumplimiento,Nombre")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion", proyecto.CompañiaID);
            ViewData["ResponsableID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", proyecto.ResponsableID);
            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyecto.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion", proyecto.CompañiaID);
            ViewData["ResponsableID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", proyecto.ResponsableID);
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResponsableID,CompañiaID,PorcentajeCumplimiento,Nombre")] Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectoExists(proyecto.Id))
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
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion", proyecto.CompañiaID);
            ViewData["ResponsableID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", proyecto.ResponsableID);
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyecto
                .Include(p => p.Compañia)
                .Include(p => p.Responsable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
            _context.Proyecto.Remove(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyecto.Any(e => e.Id == id);
        }
    }
}
