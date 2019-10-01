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
    public class PatrocinadorEventoController : Controller
    {
        private readonly EventoDbContext _context;

        public PatrocinadorEventoController(EventoDbContext context)
        {
            _context = context;
        }

        // GET: PatrocinadorEvento
        public async Task<IActionResult> Index()
        {
            var eventoDbContext = _context.PatrocinadorEventos.Include(p => p.EventoVirtual).Include(p => p.PatrocinadorVirtual);
            return View(await eventoDbContext.ToListAsync());
        }

        // GET: PatrocinadorEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinadorEvento = await _context.PatrocinadorEventos
                .Include(p => p.EventoVirtual)
                .Include(p => p.PatrocinadorVirtual)
                .FirstOrDefaultAsync(m => m.PatrocinadorValorId == id);
            if (patrocinadorEvento == null)
            {
                return NotFound();
            }

            return View(patrocinadorEvento);
        }

        // GET: PatrocinadorEvento/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Descricao");
            ViewData["PatrocinadorId"] = new SelectList(_context.Patrocinadores, "PatrocinadorId", "Nome");
            return View();
        }

        // POST: PatrocinadorEvento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatrocinadorValorId,ValorPatrocinado,EventoId,PatrocinadorId")] PatrocinadorEvento patrocinadorEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrocinadorEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Descricao", patrocinadorEvento.EventoId);
            ViewData["PatrocinadorId"] = new SelectList(_context.Patrocinadores, "PatrocinadorId", "Nome", patrocinadorEvento.PatrocinadorId);
            return View(patrocinadorEvento);
        }

        // GET: PatrocinadorEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinadorEvento = await _context.PatrocinadorEventos.FindAsync(id);
            if (patrocinadorEvento == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Descricao", patrocinadorEvento.EventoId);
            ViewData["PatrocinadorId"] = new SelectList(_context.Patrocinadores, "PatrocinadorId", "Nome", patrocinadorEvento.PatrocinadorId);
            return View(patrocinadorEvento);
        }

        // POST: PatrocinadorEvento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatrocinadorValorId,ValorPatrocinado,EventoId,PatrocinadorId")] PatrocinadorEvento patrocinadorEvento)
        {
            if (id != patrocinadorEvento.PatrocinadorValorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrocinadorEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrocinadorEventoExists(patrocinadorEvento.PatrocinadorValorId))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Descricao", patrocinadorEvento.EventoId);
            ViewData["PatrocinadorId"] = new SelectList(_context.Patrocinadores, "PatrocinadorId", "Nome", patrocinadorEvento.PatrocinadorId);
            return View(patrocinadorEvento);
        }

        // GET: PatrocinadorEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinadorEvento = await _context.PatrocinadorEventos
                .Include(p => p.EventoVirtual)
                .Include(p => p.PatrocinadorVirtual)
                .FirstOrDefaultAsync(m => m.PatrocinadorValorId == id);
            if (patrocinadorEvento == null)
            {
                return NotFound();
            }

            return View(patrocinadorEvento);
        }

        // POST: PatrocinadorEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patrocinadorEvento = await _context.PatrocinadorEventos.FindAsync(id);
            _context.PatrocinadorEventos.Remove(patrocinadorEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrocinadorEventoExists(int id)
        {
            return _context.PatrocinadorEventos.Any(e => e.PatrocinadorValorId == id);
        }
    }
}
