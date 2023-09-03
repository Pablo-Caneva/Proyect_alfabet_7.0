using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyect_alfabet_7._0.Data;

namespace Proyect_alfabet_7._0.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexStudent()
        {
            return View();
        }
        public IActionResult IndexTutor()
        {
            return View();
        }
        public IActionResult IndexAdmin()
        {
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
