using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;
using Proyect_alfabet_7._0.Repository;

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

        public IActionResult Module1(int id, int module, int lesson)
        {
            var progress = _context.Progress.FirstOrDefault(s => s.StudentId == id);
            if (progress != null)
            {
                progress.ModuleId = _context.Modules
                                        .Where(m => m.Number == module)
                                        .Select(m => m.Id)
                                        .FirstOrDefault();
                progress.LessonId = _context.Lessons
                                        .Where(l => l.Number == lesson && l.ModuleId == progress.ModuleId)
                                        .Select(l => l.Id)
                                        .FirstOrDefault();
                _context.Entry(progress).State = EntityState.Modified;
                _context.SaveChanges();
            }
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View();
        }

        public IActionResult Module2(int id, int module, int lesson)
        {
            var progress = _context.Progress.FirstOrDefault(s => s.StudentId == id);
            if (progress != null)
            {
                progress.ModuleId = _context.Modules
                                        .Where(m => m.Number == module)
                                        .Select(m => m.Id)
                                        .FirstOrDefault();
                progress.LessonId = _context.Lessons
                                        .Where(l => l.Number == lesson && l.ModuleId == progress.ModuleId)
                                        .Select(l => l.Id)
                                        .FirstOrDefault();
                _context.Entry(progress).State = EntityState.Modified;
                _context.SaveChanges();
            }
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View();
        }

        public IActionResult Module3(int id, int module, int lesson)
        {
            var progress = _context.Progress.FirstOrDefault(s => s.StudentId == id);
            if (progress != null)
            {
                progress.ModuleId = _context.Modules
                                        .Where(m => m.Number == module)
                                        .Select(m => m.Id)
                                        .FirstOrDefault();
                progress.LessonId = _context.Lessons
                                        .Where(l => l.Number == lesson && l.ModuleId == progress.ModuleId)
                                        .Select(l => l.Id)
                                        .FirstOrDefault();
                _context.Entry(progress).State = EntityState.Modified;
                _context.SaveChanges();
            }
            ViewData["id"] = id;
            ViewData["module"] = module;
            ViewData["lesson"] = lesson;
            return View();
        }

        //public IActionResult Module1(int id, bool isDone = false)
        //{
        //    var progress = _context.Progress.FirstOrDefault(s => s.StudentId == id);
        //    int currentLesson = 0;
        //    if (progress != null)
        //    {
        //        var module = _context.Modules.FirstOrDefault(s => s.Id == progress.ModuleId);
        //        var lesson = _context.Lessons.FirstOrDefault(s => s.Id == progress.LessonId);
        //        if (module != null && lesson != null)
        //        {
        //            currentLesson = lesson.Number;
        //            if (isDone)
        //            {
        //                progress.LessonId = _context.Lessons
        //                    .Where(l => l.ModuleId == module.Id && l.Number == (lesson.Number + 1))
        //                    .Select(l => l.Id)
        //                    .FirstOrDefault();
        //                var lessonaux = _context.Lessons.FirstOrDefault(s => s.Id == progress.LessonId);
        //                if (lessonaux != null)
        //                {
        //                    currentLesson = lessonaux.Number;
        //                    if (lessonaux.isLast)
        //                    {
        //                        var module2 = _context.Modules.FirstOrDefault(m => m.Number == 2);
        //                        var lesson2 = _context.Lessons.FirstOrDefault(l => l.Number == 1);
        //                        if (module2 != null && lesson2 != null)
        //                        {
        //                            progress.ModuleId = module2.Id;
        //                            progress.LessonId = lesson2.Id;
        //                            return RedirectToAction("Module2", "Content", new { @id = id });
        //                        }
        //                    }
        //                }
        //            }
        //            _context.Entry(progress).State = EntityState.Modified;
        //            _context.SaveChanges();
        //        }
        //    }
        //    ViewData["currentLesson"] = currentLesson;
        //    return View();
        //}
        //public IActionResult Module2(int id, bool isDone = false)
        //{
        //    var progress = _context.Progress.FirstOrDefault(s => s.StudentId == id);
        //    int currentLesson = 0;
        //    if (progress != null)
        //    {
        //        var module = _context.Modules.FirstOrDefault(s => s.Id == progress.ModuleId);
        //        var lesson = _context.Lessons.FirstOrDefault(s => s.Id == progress.LessonId);
        //        if (isDone && module != null && lesson != null)
        //        {
        //            currentLesson = lesson.Number;
        //            progress.LessonId = _context.Lessons
        //                .Where(l => l.ModuleId == module.Id && l.Number == (lesson.Number + 1))
        //                .Select(l => l.Id)
        //                .FirstOrDefault();
        //            var lessonaux = _context.Lessons.FirstOrDefault(s => s.Id == progress.LessonId);
        //            if (lessonaux != null)
        //            {
        //                currentLesson = lessonaux.Number;
        //                if (lessonaux.isLast)
        //                {
        //                    var module3 = _context.Modules.FirstOrDefault(m => m.Number == 3);
        //                    var lesson2 = _context.Lessons.FirstOrDefault(l => l.Number == 1);
        //                    if (module3 != null && lesson2 != null)
        //                    {
        //                        progress.ModuleId = module3.Id;
        //                        progress.LessonId = lesson2.Id;
        //                    }
        //                }
        //            }
        //            _context.Entry(progress).State = EntityState.Modified;
        //            _context.SaveChanges();
        //        }
        //    }
        //    ViewData["currentLesson"] = currentLesson;
        //    return View();
        //}
    }
}
