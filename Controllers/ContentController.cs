﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;
using Proyect_alfabet_7._0.Repository;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Proyect_alfabet_7._0.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProgressCalculator _progressCalculator;

        public ContentController(ApplicationDbContext context, IProgressCalculator progressCalculator)
        {
            _context = context;
            _progressCalculator = progressCalculator;
        }
        public IActionResult Index(int id)
        {
            return View();
        }
        /// <summary>
        /// Acción que controla y muestra las lecciones de los módulos y actualiza el progreso del estudiante.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <param name="lesson"></param>
        /// <returns></returns>
        public async Task<IActionResult> Module(int id, int module, int lesson)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Modules");
            }
            var progress = await _context.Progress.FirstOrDefaultAsync(s => s.StudentId == id);
            if (progress != null)
            {
                progress.ModuleId = await _context.Modules
                                        .Where(m => m.Number == module)
                                        .Select(m => m.Id)
                                        .FirstOrDefaultAsync();
                progress.LessonId = await _context.Lessons
                                        .Where(l => l.Number == lesson && l.ModuleId == progress.ModuleId)
                                        .Select(l => l.Id)
                                        .FirstOrDefaultAsync();
                _context.Entry(progress).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return RedirectToAction("GetLesson", "Activities", new { @id = id, @module = module, @lesson = lesson });
        }

        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, "^[aA][a-zA-Z]*$");
        }
        //public async Task<IActionResult> Module(int module, int lesson)
        //{
        //    ViewData["module"] = module;
        //    ViewData["lesson"] = lesson;
        //    return RedirectToAction("GetLesson", "Activities", new { @module = module, @lesson = lesson });
        //}

        /// <summary>
        /// Acción para el modulo 1 lesson 18.
        /// TODO: Mejorar la función para hacerla más abstracta.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <param name="lesson"></param>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="thirdName"></param>
        /// <returns></returns>
        public IActionResult M1C18(int id, int module, int lesson, string firstName, string secondName, string thirdName)
        {
            List<string> names = new List<string>();
            firstName = firstName.ToUpper();
            secondName = secondName.ToUpper();
            thirdName = thirdName.ToUpper();
            names.Add(firstName);
            names.Add(secondName);
            names.Add(thirdName);
            char toCheck = 'A';
            return RedirectToAction("StartsWith", "Activities", new { @id = id, @module = module, @lesson = lesson, @words = names, @firstLetter = toCheck });
        }
    }
}
