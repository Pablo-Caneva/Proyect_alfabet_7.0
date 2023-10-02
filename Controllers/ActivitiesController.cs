using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;
using Proyect_alfabet_7._0.Repository;

namespace Proyect_alfabet_7._0.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IActivitiesChecker _activitiesChecker;
        public ActivitiesController(ApplicationDbContext context, IActivitiesChecker activitiesChecker)
        {
            _context = context;
            _activitiesChecker = activitiesChecker;
        }

        public IActionResult GetLesson(int id, int module, int lesson)
        {
            string lessonNumber = $"/Module{module}/Lesson{lesson}";
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View($"~/Views/Activities{lessonNumber}.cshtml");
        }

        public IActionResult StartsWith(int id, int module, int lesson, List<string> words, char firstLetter)
        {
            if (_activitiesChecker.StartsWith(words, firstLetter)) {
                return RedirectToAction("Right", "Activities", new { @id = id, @module = module, @lesson = lesson + 1 });
            }
            else
            {
                return RedirectToAction("Wrong", "Activities", new { @id = id, @module = module, @lesson = lesson });
            }
        }
        public IActionResult Right(int id, int module, int lesson)
        {
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View();
        }
        public IActionResult Wrong(int id, int module, int lesson)
        {
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View();
        }
    }
}
