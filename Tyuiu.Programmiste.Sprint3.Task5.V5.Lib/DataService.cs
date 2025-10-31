
using tyuiu.cources.programming.interfaces.Sprint3;
namespace Tyuiu.Programmiste.Sprint3.Task5.V5.Lib
{
    public class DataService : ISprint3Task5V5
    {
        public double GetSumSumSeries(int x, int startValue1, int startValue2, int stopValue1, int stopValue2)
        {
            if (startValue1 > stopValue1 || startValue2 > stopValue2)
                throw new ArgumentException("Les valeurs de début ne peuvent pas être supérieures aux valeurs de fin");

            double totalSum = 0;

            // Première somme
            for (int i = startValue1; i <= stopValue1; i++)
            {
                // Calcul pour la première série (exemple: (x^i + 2) / i)
                double term1 = (Math.Pow(x, i) + 2) / i;
                totalSum += term1;
            }

            // Deuxième somme
            for (int j = startValue2; j <= stopValue2; j++)
            {
                // Calcul pour la deuxième série (exemple: (x^j + 3) / j^2)
                double term2 = (Math.Pow(x, j) + 3) / Math.Pow(j, 2);
                totalSum += term2;
            }

            return totalSum;
        }
    }
}
        
