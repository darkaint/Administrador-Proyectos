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
    public class HistoriaUsuariosController : Controller
    {
        private readonly Administrador_ProyectosContext _context;

        public HistoriaUsuariosController(Administrador_ProyectosContext context)
        {
            _context = context;
        }

        // GET: HistoriaUsuarios
        public async Task<IActionResult> Index()
        {
            var administrador_ProyectosContext = _context.HistoriaUsuario.Include(h => h.Proyecto);
            return View(await administrador_ProyectosContext.ToListAsync());
        }

        // GET: HistoriaUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaUsuario = await _context.HistoriaUsuario
                .Include(h => h.Proyecto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historiaUsuario == null)
            {
                return NotFound();
            }

            return View(historiaUsuario);
        }

        // GET: HistoriaUsuarios/Create
        public IActionResult Create()
        {
            ViewData["ProyectoID"] = new SelectList(_context.Set<Proyecto>(), "Id", "Nombre");
            return View();
        }

        // POST: HistoriaUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProyectoID,Titulo,Descripcion")] HistoriaUsuario historiaUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historiaUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProyectoID"] = new SelectList(_context.Set<Proyecto>(), "Id", "Nombre", historiaUsuario.ProyectoID);
            return View(historiaUsuario);
        }

        // GET: HistoriaUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaUsuario = await _context.HistoriaUsuario.FindAsync(id);
            if (historiaUsuario == null)
            {
                return NotFound();
            }
            ViewData["ProyectoID"] = new SelectList(_context.Set<Proyecto>(), "Id", "Nombre", historiaUsuario.ProyectoID);
            return View(historiaUsuario);
        }

        // POST: HistoriaUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProyectoID,Titulo,Descripcion")] HistoriaUsuario historiaUsuario)
        {
            if (id != historiaUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historiaUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaUsuarioExists(historiaUsuario.Id))
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
            ViewData["ProyectoID"] = new SelectList(_context.Set<Proyecto>(), "Id", "Nombre", historiaUsuario.ProyectoID);
            return View(historiaUsuario);
        }

        // GET: HistoriaUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaUsuario = await _context.HistoriaUsuario
                .Include(h => h.Proyecto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historiaUsuario == null)
            {
                return NotFound();
            }

            return View(historiaUsuario);
        }

        // POST: HistoriaUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historiaUsuario = await _context.HistoriaUsuario.FindAsync(id);
            _context.HistoriaUsuario.Remove(historiaUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaUsuarioExists(int id)
        {
            return _context.HistoriaUsuario.Any(e => e.Id == id);
        }
    }
}
