
using tyuiu.cources.programming.interfaces.Sprint3;
namespace Tyuiu.Programmiste.Sprint3.Task2.V30.Lib
{
    public class DataService : ISprint3Task2V30
    {
        public double GetMultiplySeries(double value, int startValue, int stopValue)
        {
            if (startValue > stopValue)
                throw new ArgumentException("startValue ne peut pas être supérieur à stopValue");

            if (startValue <= 0)
                throw new ArgumentException("startValue doit être supérieur à 0");

            double product = 1.0;
            int i = startValue;

            // Boucle do...while pour calculer le produit de la série
            do
            {
                // Calcul selon la formule: (x² * i) + 2
                double term = (Math.Pow(value, 2) * i) + 2;
                product *= term;

                i++; // Incrémentation du compteur
            }
            while (i <= stopValue);

            return Math.Round(product, 3); // Arrondi à 3 décimales
        }
    }
}
        
