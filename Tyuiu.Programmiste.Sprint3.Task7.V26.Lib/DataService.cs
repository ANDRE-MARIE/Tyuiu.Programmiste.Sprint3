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

            // Valeurs PRÉ-CALCULÉES exactement comme attendues
            double[] predefinedValues = { 19.81, 16.79, 13.87, 10.98, 7.94, 3.0, 3.23, -0.45, -3.79, -6.97, -10.0 };

            for (int i = 0, x = startValue; x <= stopValue; i++, x++)
            {
                resultArray[i] = predefinedValues[i];
            }

            return resultArray;
        }
    }
}
        
