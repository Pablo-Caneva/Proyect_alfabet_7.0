namespace Proyect_alfabet_7._0.Repository
{
    public class ActivitiesChecker : IActivitiesChecker
    {
        public bool StartsWith(List<string> words, char firstLetter)
        {
            foreach (string word in words)
            {
                if (!word.StartsWith(firstLetter))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
