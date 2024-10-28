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
    public class StudentCompetencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentCompetencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentCompetences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentCompetence.Include(s => s.Competence).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentCompetences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCompetence = await _context.StudentCompetence
                .Include(s => s.Competence)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentCompetence == null)
            {
                return NotFound();
            }

            return View(studentCompetence);
        }

        // GET: StudentCompetences/Create
        public IActionResult Create()
        {
            ViewData["CompetenceId"] = new SelectList(_context.Competence, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name");
            return View();
        }

        // POST: StudentCompetences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CompetenceId,DateOfParticipation")] StudentCompetence studentCompetence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCompetence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetenceId"] = new SelectList(_context.Competence, "Id", "Name", studentCompetence.CompetenceId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", studentCompetence.StudentId);
            return View(studentCompetence);
        }

        // GET: StudentCompetences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCompetence = await _context.StudentCompetence.FindAsync(id);
            if (studentCompetence == null)
            {
                return NotFound();
            }
            ViewData["CompetenceId"] = new SelectList(_context.Competence, "Id", "Name", studentCompetence.CompetenceId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", studentCompetence.StudentId);
            return View(studentCompetence);
        }

        // POST: StudentCompetences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,CompetenceId,DateOfParticipation")] StudentCompetence studentCompetence)
        {
            if (id != studentCompetence.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCompetence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCompetenceExists(studentCompetence.StudentId))
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
            ViewData["CompetenceId"] = new SelectList(_context.Competence, "Id", "Name", studentCompetence.CompetenceId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", studentCompetence.StudentId);
            return View(studentCompetence);
        }

        // GET: StudentCompetences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCompetence = await _context.StudentCompetence
                .Include(s => s.Competence)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentCompetence == null)
            {
                return NotFound();
            }

            return View(studentCompetence);
        }

        // POST: StudentCompetences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCompetence = await _context.StudentCompetence.FindAsync(id);
            if (studentCompetence != null)
            {
                _context.StudentCompetence.Remove(studentCompetence);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCompetenceExists(int id)
        {
            return _context.StudentCompetence.Any(e => e.StudentId == id);
        }
    }
}
