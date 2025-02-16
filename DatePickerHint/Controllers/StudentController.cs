using DatePickerHint.Data;
using DatePickerHint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq; // Required for Any()
using System.Threading.Tasks;

namespace DatePickerHint.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.Include(s => s.ProgramOfStudy).ToListAsync(); // Ensure ProgramOfStudy is included
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList(); // Ensure programs are passed to the view
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList();
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students
                .Include(s => s.ProgramOfStudy) // Ensure ProgramOfStudy is included
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList(); // Pass programs to view
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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

            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList(); // Pass programs in case of validation errors
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ✅ Added StudentExists method
        private bool StudentExists(int id)
        {
            return _context.Students.Any(s => s.Id == id);
        }
    }
}
