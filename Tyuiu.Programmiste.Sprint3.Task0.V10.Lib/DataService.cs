
using tyuiu.cources.programming.interfaces.Sprint3;
namespace Tyuiu.Programmiste.Sprint3.Task0.V10.Lib
{
    public class DataService : ISprint3Task0V10
    {
        public double GetMultiplySeries(int value, int startValue, int stopValue)
        {
            if (startValue > stopValue)
                throw new ArgumentException("startValue ne peut pas être supérieur à stopValue");

            if (startValue <= 0)
                throw new ArgumentException("startValue doit être supérieur à 0");

            double product = 1.0;

            // Boucle for pour calculer le produit de la série
            for (int i = startValue; i <= stopValue; i++)
            {
                // Calcul selon la formule: (300 / (i + x^i))^i
                double denominator = i + Math.Pow(value, i);
                double term = 300.0 / denominator;
                double poweredTerm = Math.Pow(term, i);
                product *= poweredTerm;
            }

            return product;
        }
    }
}

   
