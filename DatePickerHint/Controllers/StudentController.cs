//DRASTI PATEL (#8839416)
//PROBLEM ANALYSIS #1
//FEBRUARY 16, 2025
//

using DatePickerHint.Data;
using DatePickerHint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DatePickerHint.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        //constructor initializes the ApplicationDbContext, which interacts with the databse.
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        //index method - retrieves and displays a list of all students with their related ProgramOfStudy
        //uses eager loading to include ProgramOfStudy data.
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.Include(s => s.ProgramOfStudy).ToListAsync(); // ensure ProgramOfStudy is loaded with students
            return View(students);     //returns the list of students to the view.
        }

        //create GET method - returns the create view and passes a list of available programs.
        public IActionResult Create()
        {
            //populate the dropdown for selectng ProgramOfStudy when creating a student.
            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList();     //get all available programs
            return View();     //returns the create view to add a new student.
        }

        //create POST method - handles form submission for creating a student.
        //if model validation passes, the student is added to database and saved.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)         //ensures that student model passes verification.
            {
                _context.Add(student);       //adds new student
                await _context.SaveChangesAsync();       //saves changes to database
                return RedirectToAction(nameof(Index));     //redirects to index page.
            } 
            //if model validation fails, program list is passed again and the student object is returned to view with errors.
            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList();
            return View(student); //returns the Create view with validation error messages.
        }

        //edit GET method - retrives a student by ID, including their associated PorgramOfStudy
        //passes data to the Edit view for displaying and editing
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students
                .Include(s => s.ProgramOfStudy)            //ensures that ProgamOfStudy is included for display
                .FirstOrDefaultAsync(s => s.Id == id);     //retrieves the student by ID.

            if (student == null)
            {
                return NotFound();    //if no student is found with given ID, return a NotFound response.
            }

            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList(); //pass available programs to view.
            return View(student);              //returns student data to Edit View.
        }

        //edit POST method - handles form submission for updating a student's details.
        //if model validation passes and ID matches, updates the student.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();        //if student ID doesn't match, return NotFound response
            }

            if (ModelState.IsValid)       //checks if model is valid
            {
                try
                {
                    _context.Update(student);                  //updates the student in database
                    await _context.SaveChangesAsync();        //saves changes in database
                }
                catch (DbUpdateConcurrencyException)         //handles concurrency issues
                {
                    if (!StudentExists(student.Id))     //if student no longer exists, return NotFound.
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;   //rethrow exception if there is any problem.
                    }
                }
                return RedirectToAction(nameof(Index));       //redirects back to list of students.
            }

            ViewBag.ProgramOfStudies = _context.ProgramOfStudies.ToList();    //pass programs again in case of validation errors.
            return View(student);         //return the edit view with validation errors.
        }

        //delete GET method - retrieves a student by ID for deletion confirmation.
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);    //finds student by ID
            if (student == null) return NotFound();           //if student isn't found, return NotFound response
            return View(student);              //returns the Delete confirmation view with student data
        }

        //delete POST method - handles actual deletion of student.
        //if confirmed, deletes student from database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]                                //prevents CSRF attacks during deletion
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);   //finds student by ID
            if (student == null) return NotFound();           //if student is not found, return NotFound

            _context.Students.Remove(student);            //removes student from database
            await _context.SaveChangesAsync();             //saves changes to database

            return RedirectToAction(nameof(Index));        //redirects index page (list of students)
        }

        //helper method to check if student exists by ID
        //this is used for concurrency  handling during updates.
        private bool StudentExists(int id)
        {
            return _context.Students.Any(s => s.Id == id);      //returns true if a student with given ID exists in database.
        }
    }
}
