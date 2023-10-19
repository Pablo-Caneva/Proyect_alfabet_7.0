namespace Proyect_alfabet_7._0.Models
{
    /// <summary>
    /// Modelo que agrupa módulos y clases para su visualización.
    /// </summary>
    public class ModuleViewModel
    {
        public List<Module> modules { get; set; }
        public List<List<Lesson>> lessonsList { get; set; }
        public ModuleViewModel() { }

    }
}
