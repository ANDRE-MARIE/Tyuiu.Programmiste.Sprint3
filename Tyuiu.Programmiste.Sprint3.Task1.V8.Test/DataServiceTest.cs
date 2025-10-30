using Tyuiu.Programmiste.Sprint3.Task1.V8.Lib;
namespace Tyuiu.Programmiste.Sprint3.Task1.V8.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidGetSumSeries()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 1;
            int stopValue = 7;

            // Act
            double result = ds.GetSumSeries(x, startValue, stopValue);

            // Assert - Vérification que le résultat est cohérent
            Assert.IsTrue(result > 0);
            Assert.IsTrue(result < 1000); // Le résultat devrait être dans une plage raisonnable
        }

        [TestMethod]
        public void GetSumSeries_WithStartGreaterThanStop_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 10;
            int stopValue = 7;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetSumSeries(x, startValue, stopValue));
        }

        [TestMethod]
        public void GetSumSeries_WithStartEqualToStop_ReturnsSingleTerm()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 3;
            int stopValue = 3;

            // Act
            double result = ds.GetSumSeries(x, startValue, stopValue);

            // Assert - Calcul manuel pour k=3
            double denominator = Math.Cos(3) + Math.Pow(0.25, 3);
            double expected = Math.Pow(1.0 / denominator, 3);
            Assert.AreEqual(expected, result, 1e-10);
        }

        [TestMethod]
        public void GetSumSeries_WithDifferentRanges_ReturnsDifferentValues()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;

            // Act
            double result1to3 = ds.GetSumSeries(x, 1, 3);
            double result1to7 = ds.GetSumSeries(x, 1, 7);

            // Assert - Les résultats doivent être différents
            Assert.AreNotEqual(result1to3, result1to7);
        }

        [TestMethod]
        public void GetSumSeries_WithStartValueZero_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 0;
            int stopValue = 7;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetSumSeries(x, startValue, stopValue));
        }

        [TestMethod]
        public void GetSumSeries_WithNegativeValue_CalculatesCorrectly()
        {
            // Arrange
            DataService ds = new DataService();
            double x = -0.25;
            int startValue = 1;
            int stopValue = 3;

            // Act
            double result = ds.GetSumSeries(x, startValue, stopValue);

            // Assert - Le résultat doit être un nombre valide
            Assert.IsFalse(double.IsNaN(result));
            Assert.IsFalse(double.IsInfinity(result));
        }
    }
}
        
