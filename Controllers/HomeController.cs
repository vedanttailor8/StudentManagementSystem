
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Home Page";

            ViewBag.TotalStudents = await _context.Students.CountAsync();

            ViewBag.TotalCourses = await _context.Students
                .Select(s => s.Course)
                .Distinct()
                .CountAsync();

            ViewBag.TotalSemesters = await _context.Students
                .Select(s => s.Semester)
                .Distinct()
                .CountAsync();

            ViewBag.RecentStudents = await _context.Students
                .AsNoTracking()
                .OrderByDescending(s => s.Id)
                .Take(5)
                .ToListAsync();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }
    }
}
