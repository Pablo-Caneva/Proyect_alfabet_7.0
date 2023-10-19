namespace Proyect_alfabet_7._0.Repository
{
    /// <summary>
    /// Interfaz que determina las funciones que calculan el progreso de un estudiante.
    /// </summary>
    public interface IProgressCalculator
    {
        Task<double> CalculatePercentage(int studentId);
        Task<int> CurrentModule(int studentId);
        Task<int> CurrentLesson(int studentId);
    }
}