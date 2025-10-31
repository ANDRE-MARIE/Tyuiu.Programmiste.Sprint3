using tyuiu.cources.programming.interfaces.Sprint3;
using static System.Net.Mime.MediaTypeNames;

namespace Tyuiu.Programmiste.Sprint3.Task6.V10.Lib
{
    public class DataService : ISprint3Task6V10
    {
        public int GetSumTheDivisors(int startValue, int stopValue)
        {
            if (startValue > stopValue)
                throw new ArgumentException("Start doit être inférieur ou égal à stop.");

            int totalSum = 0;

            for (int num = startValue; num <= stopValue; num++)
            {
                totalSum += SumDivisorsGreaterThan12(num);
            }

            return totalSum;
        }

        private int SumDivisorsGreaterThan12(int number)
        {
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0 && i > 12)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
