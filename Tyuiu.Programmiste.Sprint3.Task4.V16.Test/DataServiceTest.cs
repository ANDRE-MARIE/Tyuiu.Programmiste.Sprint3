
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

            // Assert - Vérification que le résultat est environ 6719
            Assert.AreEqual(6719, result, 1.0); // Tolérance de 1
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
        public void Calculate_ReturnsExpectedValue6719()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            // Act
            double result = ds.Calculate(startValue, stopValue);

            // Assert - Le résultat doit être environ 6719
            Assert.IsTrue(result >= 6718 && result <= 6720,
                $"Le résultat {result} devrait être environ 6719");
        }
    }
}
