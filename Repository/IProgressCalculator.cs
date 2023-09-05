namespace Proyect_alfabet_7._0.Repository
{
    public interface IProgressCalculator
    {
        double CalculatePercentage(int studentId);
        int CurrentModule(int studentId);
        int CurrentLesson(int studentId);
    }
}
