using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstProgressProyect.Models;

namespace FirstProgressProyect.Controllers
{
    public class CompetencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Competences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Competence.Include(c => c.Admin).Include(c => c.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Competences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competence = await _context.Competence
                .Include(c => c.Admin)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competence == null)
            {
                return NotFound();
            }

            return View(competence);
        }

        // GET: Competences/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Type");
            return View();
        }

        // POST: Competences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CategoryId,AdminId,NumParticipants,MaxNumParticipants,MinNumParticipants,Date,MaxDateOfIncription")] Competence competence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Name", competence.AdminId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Type", competence.CategoryId);
            return View(competence);
        }

        // GET: Competences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competence = await _context.Competence.FindAsync(id);
            if (competence == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Name", competence.AdminId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Type", competence.CategoryId);
            return View(competence);
        }

        // POST: Competences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CategoryId,AdminId,NumParticipants,MaxNumParticipants,MinNumParticipants,Date,MaxDateOfIncription")] Competence competence)
        {
            if (id != competence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenceExists(competence.Id))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "Id", "Name", competence.AdminId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Type", competence.CategoryId);
            return View(competence);
        }

        // GET: Competences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competence = await _context.Competence
                .Include(c => c.Admin)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competence == null)
            {
                return NotFound();
            }

            return View(competence);
        }

        // POST: Competences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competence = await _context.Competence.FindAsync(id);
            if (competence != null)
            {
                _context.Competence.Remove(competence);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenceExists(int id)
        {
            return _context.Competence.Any(e => e.Id == id);
        }
    }
}
