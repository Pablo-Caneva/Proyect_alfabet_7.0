namespace Proyect_alfabet_7._0.Repository
{
    /// <summary>
    /// Implementación de las funciones de la interfaz IActivitiesChecker. 
    /// </summary>
    public class ActivitiesChecker : IActivitiesChecker
    {
        /// <summary>
        /// Función que determina si una lista de palabras empieza con la letra determinada.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
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
