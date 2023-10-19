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
        /// <summary>
        /// Acción que recibe id de estudiante, número de módulo y número de lección y devuelve la vista correspondiente,
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public IActionResult GetLesson(int id, int module, int lesson)
        {
            string lessonNumber = $"/Module{module}/Lesson{lesson}";
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View($"~/Views/Activities{lessonNumber}.cshtml");
        }

        /// <summary>
        /// Acción que recibe número de módulo y número de lección y devuelve la vista correspondiente, para ser visualizado por tutores y administradores únicamente.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public IActionResult GetLessonTutor(int module, int lesson)
        {
            string lessonNumber = $"/Module{module}/Lesson{lesson}";
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            ViewData["id"] = 0;
            return View($"~/Views/Activities{lessonNumber}.cshtml");
        }

        /// <summary>
        /// Acción para corregir que las palabras en la lista Words empiecen con la letra firstLetter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <param name="lesson"></param>
        /// <param name="words"></param>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Acción que muestra una vista de respuesta correcta.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public IActionResult Right(int id, int module, int lesson)
        {
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View();
        }

        /// <summary>
        /// Acción que muestra una vista de respuesta incorrecta.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public IActionResult Wrong(int id, int module, int lesson)
        {
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View();
        }
    }
}
