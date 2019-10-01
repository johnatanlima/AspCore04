using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCore04.Data;
using AspCore04.Models;

namespace AspCore04.Controllers
{
    public class PatrocinadorController : Controller
    {
        private readonly EventoDbContext _context;

        public PatrocinadorController(EventoDbContext context)
        {
            _context = context;
        }

        // GET: Patrocinador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patrocinadores.ToListAsync());
        }

        // GET: Patrocinador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadores
                .FirstOrDefaultAsync(m => m.PatrocinadorId == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // GET: Patrocinador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patrocinador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatrocinadorId,Nome,Telefone")] Patrocinador patrocinador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrocinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patrocinador);
        }

        // GET: Patrocinador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadores.FindAsync(id);
            if (patrocinador == null)
            {
                return NotFound();
            }
            return View(patrocinador);
        }

        // POST: Patrocinador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatrocinadorId,Nome,Telefone")] Patrocinador patrocinador)
        {
            if (id != patrocinador.PatrocinadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrocinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrocinadorExists(patrocinador.PatrocinadorId))
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
            return View(patrocinador);
        }

        // GET: Patrocinador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinador = await _context.Patrocinadores
                .FirstOrDefaultAsync(m => m.PatrocinadorId == id);
            if (patrocinador == null)
            {
                return NotFound();
            }

            return View(patrocinador);
        }

        // POST: Patrocinador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patrocinador = await _context.Patrocinadores.FindAsync(id);
            _context.Patrocinadores.Remove(patrocinador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrocinadorExists(int id)
        {
            return _context.Patrocinadores.Any(e => e.PatrocinadorId == id);
        }
    }
}
