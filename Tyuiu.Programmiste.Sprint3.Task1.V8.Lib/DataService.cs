using tyuiu.cources.programming.interfaces.Sprint3;

namespace Tyuiu.Programmiste.Sprint3.Task1.V8.Lib
{
    public class DataService : ISprint3Task1V8
    {
        public double GetSumSeries(double value, int startValue, int stopValue)
        {
            if (startValue > stopValue)
                throw new ArgumentException("startValue ne peut pas être supérieur à stopValue");

            if (startValue <= 0)
                throw new ArgumentException("startValue doit être supérieur à 0");

            double product = 1.0;
            int k = startValue;

            // Boucle while pour calculer le produit de la série
            while (k <= stopValue)
            {
                // Calcul selon la formule: (1 / (cos(k) + x^k))^k
                double denominator = Math.Cos(k) + Math.Pow(value, k);

                // Vérification pour éviter la division par zéro
                if (denominator == 0)
                    throw new DivideByZeroException($"Dénominateur nul pour k = {k}");

                double term = 1.0 / denominator;
                double poweredTerm = Math.Pow(term, k);
                product *= poweredTerm;

                k++; // Incrémentation du compteur
            }

            // ARRONDIR À 3 DÉCIMALES pour correspondre à la valeur attendue
            return Math.Round(product, 3);
        }
    }
}

