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
    public class RealizadorController : Controller
    {
        private readonly EventoDbContext _context;

        public RealizadorController(EventoDbContext context)
        {
            _context = context;
        }

        // GET: Realizador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Realizadores.ToListAsync());
        }

        // GET: Realizador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizador = await _context.Realizadores
                .FirstOrDefaultAsync(m => m.RealizadorId == id);
            if (realizador == null)
            {
                return NotFound();
            }

            return View(realizador);
        }

        // GET: Realizador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Realizador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RealizadorId,Nome,Telefone,Email")] Realizador realizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realizador);
        }

        // GET: Realizador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizador = await _context.Realizadores.FindAsync(id);
            if (realizador == null)
            {
                return NotFound();
            }
            return View(realizador);
        }

        // POST: Realizador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RealizadorId,Nome,Telefone,Email")] Realizador realizador)
        {
            if (id != realizador.RealizadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealizadorExists(realizador.RealizadorId))
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
            return View(realizador);
        }

        // GET: Realizador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizador = await _context.Realizadores
                .FirstOrDefaultAsync(m => m.RealizadorId == id);
            if (realizador == null)
            {
                return NotFound();
            }

            return View(realizador);
        }

        // POST: Realizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realizador = await _context.Realizadores.FindAsync(id);
            _context.Realizadores.Remove(realizador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealizadorExists(int id)
        {
            return _context.Realizadores.Any(e => e.RealizadorId == id);
        }
    }
}
