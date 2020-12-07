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
    public class CompañiaUsuarioController : Controller
    {
        private readonly Administrador_ProyectosContext _context;

        public CompañiaUsuarioController(Administrador_ProyectosContext context)
        {
            _context = context;
        }

        // GET: CompañiaUsuario
        public async Task<IActionResult> Index()
        {
            var administrador_ProyectosContext = _context.CompañiaUsuario.Include(c => c.Compañia).Include(c => c.Usuario);
            return View(await administrador_ProyectosContext.ToListAsync());
        }

        // GET: CompañiaUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañiaUsuario = await _context.CompañiaUsuario
                .Include(c => c.Compañia)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compañiaUsuario == null)
            {
                return NotFound();
            }

            return View(compañiaUsuario);
        }

        // GET: CompañiaUsuario/Create
        public IActionResult Create()
        {
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion");
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido");
            return View();
        }

        // POST: CompañiaUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompañiaID,UsuarioID,FechaAsignacion")] CompañiaUsuario compañiaUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compañiaUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion", compañiaUsuario.CompañiaID);
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", compañiaUsuario.UsuarioID);
            return View(compañiaUsuario);
        }

        // GET: CompañiaUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañiaUsuario = await _context.CompañiaUsuario.FindAsync(id);
            if (compañiaUsuario == null)
            {
                return NotFound();
            }
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion", compañiaUsuario.CompañiaID);
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", compañiaUsuario.UsuarioID);
            return View(compañiaUsuario);
        }

        // POST: CompañiaUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompañiaID,UsuarioID,FechaAsignacion")] CompañiaUsuario compañiaUsuario)
        {
            if (id != compañiaUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compañiaUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompañiaUsuarioExists(compañiaUsuario.Id))
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
            ViewData["CompañiaID"] = new SelectList(_context.Compañia, "Id", "Direccion", compañiaUsuario.CompañiaID);
            ViewData["UsuarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", compañiaUsuario.UsuarioID);
            return View(compañiaUsuario);
        }

        // GET: CompañiaUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañiaUsuario = await _context.CompañiaUsuario
                .Include(c => c.Compañia)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compañiaUsuario == null)
            {
                return NotFound();
            }

            return View(compañiaUsuario);
        }

        // POST: CompañiaUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compañiaUsuario = await _context.CompañiaUsuario.FindAsync(id);
            _context.CompañiaUsuario.Remove(compañiaUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompañiaUsuarioExists(int id)
        {
            return _context.CompañiaUsuario.Any(e => e.Id == id);
        }
    }
}
