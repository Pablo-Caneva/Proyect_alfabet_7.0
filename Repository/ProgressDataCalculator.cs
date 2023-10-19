using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;

namespace Proyect_alfabet_7._0.Repository
{
    /// <summary>
    /// Calculadora para saber progreso, módulo actual y lección que debe realizar un estudiante. Implementa las funciones de IProgressCalculator
    /// </summary>
    public class ProgressDataCalculator : IProgressCalculator
    {
        private readonly ApplicationDbContext _context;
        public ProgressDataCalculator(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devuelve el % de avance en el módulo que se encuentra el estudiante
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<double> CalculatePercentage(int studentId)
        {
            double? percentageCompleted = null;
            var progress = await _context.Progress.FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (progress != null)
            {
                var module = await _context.Modules.FirstOrDefaultAsync(s => s.Id == progress.ModuleId);
                var lesson = await _context.Lessons.FirstOrDefaultAsync(s => s.Id == progress.LessonId);

                if (module != null && lesson != null)
                {
                    percentageCompleted = (Convert.ToDouble(lesson.Number) - 1) / Convert.ToDouble(module.LessonsQuantity);
                }
            }
            return percentageCompleted ?? -1.0;
        }

        /// <summary>
        /// Devuelve el módulo que se encuentra cursando el estudiante
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<int> CurrentModule(int studentId)
        {
            var progress = await _context.Progress.FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (progress != null)
            {
                var module = await _context.Modules.FirstOrDefaultAsync(s => s.Id == progress.ModuleId);
                if (module != null)
                {
                    return module.Number;
                }
            }
            return -1;
        }

        /// <summary>
        /// Devuelve la lección que debe realizar el estudiante a continuación.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<int> CurrentLesson(int studentId)
        {
            var progress = await _context.Progress.FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (progress != null)
            {
                var lesson = await _context.Lessons.FirstOrDefaultAsync(s => s.Id == progress.LessonId);
                if (lesson != null)
                {
                    return lesson.Number;
                }
            }
            return -1;
        }
    }
}
