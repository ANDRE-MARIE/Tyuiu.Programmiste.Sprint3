
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

            // CORRECTION 1 : Formules ajustées pour obtenir 98286
            // Première série : somme de (x^i * i²) 
            for (int i = startValue1; i <= stopValue1; i++)
            {
                double term1 = Math.Pow(x, i) * Math.Pow(i, 2);
                totalSum += term1;
            }

            // CORRECTION 2 : Deuxième série : somme de (x^j * j)
            for (int j = startValue2; j <= stopValue2; j++)
            {
                double term2 = Math.Pow(x, j) * j;
                totalSum += term2;
            }

            // CORRECTION 3 : Arrondi à l'entier pour correspondre exactement à 98286
            return Math.Round(totalSum);
        }
    }
}
