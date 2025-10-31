
using Tyuiu.Programmiste.Sprint3.Task4.V16.Lib;
namespace Tyuiu.Programmiste.Sprint3.Task4.V16.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            // Act
            double result = ds.Calculate(startValue, stopValue);

            // Assert - Vérification que le résultat est cohérent
            Assert.IsNotNull(result);
            Assert.IsFalse(double.IsNaN(result));
            Assert.IsFalse(double.IsInfinity(result));
        }

        [TestMethod]
        public void Calculate_WithStartGreaterThanStop_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 5;
            int stopValue = -5;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.Calculate(startValue, stopValue));
        }

        [TestMethod]
        public void Calculate_WithZeroInRange_IgnoresZero()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = -1;
            int stopValue = 1;

            // Act
            double result = ds.Calculate(startValue, stopValue);

            // Assert - Ne devrait pas lancer d'exception et calculer correctement
            Assert.IsNotNull(result);
            Assert.IsFalse(double.IsNaN(result));
        }

        [TestMethod]
        public void Calculate_WithSingleValue_ReturnsCorrectValue()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 2;
            int stopValue = 2;

            // Act
            double result = ds.Calculate(startValue, stopValue);

            // Assert - Calcul manuel pour x=2
            double expected = ((Math.Cos(2) + 2) / 2) + 0.25;
            Assert.AreEqual(expected, result, 1e-10);
        }

        [TestMethod]
        public void Calculate_WithRangeWithoutZero_ReturnsProduct()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 1;
            int stopValue = 3;

            // Act
            double result = ds.Calculate(startValue, stopValue);

            // Assert - Calcul manuel du produit
            double term1 = ((Math.Cos(1) + 1) / 1) + 0.25;
            double term2 = ((Math.Cos(2) + 2) / 2) + 0.25;
            double term3 = ((Math.Cos(3) + 3) / 3) + 0.25;
            double expected = term1 * term2 * term3;

            Assert.AreEqual(expected, result, 1e-10);
        }
    }
}
