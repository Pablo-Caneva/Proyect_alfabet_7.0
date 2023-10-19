namespace Proyect_alfabet_7._0.Repository
{
    /// <summary>
    /// Interfaz para determinar las funciones que revisan actividades.
    /// </summary>
    public interface IActivitiesChecker
    {
        public bool StartsWith(List<string> words, char firstLetter);
    }
}
