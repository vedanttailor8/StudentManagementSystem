
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var students = _context.Students.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                students = students.Where(s =>
                    s.FullName.Contains(search) ||
                    s.EnrollmentNumber.Contains(search) ||
                    s.Email.Contains(search) ||
                    s.Course.Contains(search));
            }

            ViewData["Title"] = "Students";
            ViewData["Search"] = search;

            return View(await students
                .OrderBy(s => s.FullName)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Add Student";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Add Student";
                return View(student);
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Student added successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            ViewData["Title"] = "Student Details";
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            ViewData["Title"] = "Edit Student";
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, Student student)
        {
            if (id != student.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Edit Student";
                return View(student);
            }

            var existingStudent = await _context.Students
                .FindAsync(id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.EnrollmentNumber =
                student.EnrollmentNumber;
            existingStudent.FullName = student.FullName;
            existingStudent.Email = student.Email;
            existingStudent.Course = student.Course;
            existingStudent.Semester = student.Semester;
            existingStudent.DateOfBirth = student.DateOfBirth;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Student updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            ViewData["Title"] = "Delete Student";
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Student deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
