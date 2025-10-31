using tyuiu.cources.programming.interfaces.Sprint3;

namespace Tyuiu.Programmiste.Sprint3.Task4.V16.Lib
{
    public class DataService : ISprint3Task4V16
    {
        public double Calculate(int startValue, int stopValue)
        {
            if (startValue > stopValue)
                throw new ArgumentException("startValue ne peut pas être supérieur à stopValue");

            double product = 1.0;

            for (int x = startValue; x <= stopValue; x++)
            {
                // Ignorer x = 0 comme demandé
                if (x == 0)
                    continue;

                // Calculer la fonction y = ((cos(x) + x) / x) + 0.25
                double numerator = Math.Cos(x) + x;
                double term = (numerator / x) + 0.25;

                product *= term;
            }

            return product;
        }
    }
}
        
