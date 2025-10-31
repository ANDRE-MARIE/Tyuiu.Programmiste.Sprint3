using System.Text;
using tyuiu.cources.programming.interfaces.Sprint3;
namespace Tyuiu.Programmiste.Sprint3.Task3.V18.Lib
{
    public class DataService : ISprint3Task3V18
    {
        public string ReplaceNumOnChar(string value, char item)
        {

            if (string.IsNullOrEmpty(value))
                return value;

            StringBuilder result = new StringBuilder();

            // Boucle foreach pour parcourir chaque caractère
            foreach (char c in value)
            {
                // Vérifier si le caractère est un chiffre
                if (char.IsDigit(c))
                {
                    result.Append(item); // Remplacer par le caractère spécifié
                }
                else
                {
                    result.Append(c); // Garder le caractère original
                }
            }

            return result.ToString();
        }
    }
}

