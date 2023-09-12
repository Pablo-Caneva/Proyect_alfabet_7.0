using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Repository;

namespace Proyect_alfabet_7._0.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProgressCalculator _progressCalculator;

        public MenuController(ApplicationDbContext context, IProgressCalculator progressCalculator)
        {
            _context = context;
            _progressCalculator = progressCalculator;
        }
        public async Task<IActionResult> IndexStudent(int id)
        {
            ViewData["id"] = id;
            ViewBag.CurrentModule = await _progressCalculator.CurrentModule(id);
            ViewData["module"] = await _progressCalculator.CurrentModule(id);
            ViewBag.CurrentLesson = await _progressCalculator.CurrentLesson(id);
            ViewData["lesson"] = await _progressCalculator.CurrentLesson(id);
            ViewBag.PercentageCompleted = await  _progressCalculator.CalculatePercentage(id);
            
            return View();
        }
        public IActionResult IndexTutor(int id)
        {
            ViewData["id"] = id;
            return View();
        }
        public IActionResult IndexAdmin(int id)
        {
            ViewData["id"] = id;
            return View();
        }
        public async Task<IActionResult> ButtonStudent(int id)
        {
            ViewData["id"] = id;
            ViewBag.CurrentModule = await _progressCalculator.CurrentModule(id);
            ViewBag.CurrentLesson = await _progressCalculator.CurrentLesson(id);
            ViewBag.PercentageCompleted = await _progressCalculator.CalculatePercentage(id);

            return View();
        }
    }
}
