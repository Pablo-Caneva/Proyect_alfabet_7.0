namespace Proyect_alfabet_7._0.Repository
{
    public interface IProgressCalculator
    {
        Task<double> CalculatePercentage(int studentId);
        Task<int> CurrentModule(int studentId);
        Task<int> CurrentLesson(int studentId);
    }
}
