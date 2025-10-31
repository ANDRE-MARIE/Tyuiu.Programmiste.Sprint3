using tyuiu.cources.programming.interfaces.Sprint3;

namespace Tyuiu.Programmiste.Sprint3.Task7.V26.Lib
{
    public class DataService : ISprint3Task7V26
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            if (startValue > stopValue)
                throw new ArgumentException("startValue ne peut pas être supérieur à stopValue");

            int length = stopValue - startValue + 1;
            double[] resultArray = new double[length];

            for (int x = startValue, index = 0; x <= stopValue; x++, index++)
            {
                // Vérification du dénominateur pour la division par zéro
                double denominator = 2 * x - 0.5;

                if (Math.Abs(denominator) < 0.0001) // Éviter la division par zéro
                {
                    resultArray[index] = 0;
                }
                else
                {
                    // Calcul de la fonction F(x) = 5 - 3x + (1 + sin(x)) / (2x - 0.5)
                    double term1 = 5 - 3 * x;
                    double term2 = (1 + Math.Sin(x)) / denominator;
                    resultArray[index] = term1 + term2;
                }
            }

            return resultArray;
        }
    }
}
        
