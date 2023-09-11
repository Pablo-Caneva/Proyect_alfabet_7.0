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
        public IActionResult IndexStudent(int id)
        {
            ViewData["id"] = id;
            ViewBag.CurrentModule = _progressCalculator.CurrentModule(id);
            ViewData["module"] = _progressCalculator.CurrentModule(id);
            ViewBag.CurrentLesson = _progressCalculator.CurrentLesson(id);
            ViewData["lesson"] = _progressCalculator.CurrentLesson(id);
            ViewBag.PercentageCompleted = _progressCalculator.CalculatePercentage(id);
            
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
        public IActionResult ButtonStudent(int id)
        {
            ViewData["id"] = id;
            ViewBag.CurrentModule = _progressCalculator.CurrentModule(id);
            ViewBag.CurrentLesson = _progressCalculator.CurrentLesson(id);
            ViewBag.PercentageCompleted = _progressCalculator.CalculatePercentage(id);
            return View();
        }
        // GET: MenuController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
