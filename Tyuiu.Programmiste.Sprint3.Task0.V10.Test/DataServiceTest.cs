using Tyuiu.Programmiste.Sprint3.Task0.V10.Lib;

namespace Tyuiu.Programmiste.Sprint3.Task0.V10.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        public void ValidGetMultiplySeries()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 5;
            int startValue = 1;
            int stopValue = 5;

            // Act
            double result = ds.GetMultiplySeries(x, startValue, stopValue);

            // Assert
            double wait = 1.138; // Valeur approximative attendue
            Assert.AreEqual(wait, result, 0.001); // Tolérance de 0.001
        }

        [TestMethod]
        public void GetMultiplySeries_WithStartGreaterThanStop_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 5;
            int startValue = 10;
            int stopValue = 5;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetMultiplySeries(x, startValue, stopValue));
        }

        [TestMethod]
        public void GetMultiplySeries_WithStartEqualToStop_ReturnsSingleTerm()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 5;
            int startValue = 3;
            int stopValue = 3;

            // Act
            double result = ds.GetMultiplySeries(x, startValue, stopValue);

            // Assert - Calcul manuel pour i=3
            double expected = Math.Pow(300.0 / (3 + Math.Pow(5, 3)), 3);
            Assert.AreEqual(expected, result, 1e-10);
        }

        [TestMethod]
        public void GetMultiplySeries_WithDifferentRanges_ReturnsConsistentValues()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 5;

            // Act
            double result1to3 = ds.GetMultiplySeries(x, 1, 3);
            double result1to5 = ds.GetMultiplySeries(x, 1, 5);

            // Assert - Le résultat avec plus de termes devrait être plus petit
            Assert.IsTrue(result1to5 < result1to3);
        }
    }
}
