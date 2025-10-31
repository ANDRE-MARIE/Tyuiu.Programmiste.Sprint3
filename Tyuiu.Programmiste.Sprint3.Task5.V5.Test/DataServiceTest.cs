using Tyuiu.Programmiste.Sprint3.Task5.V5.Lib;

namespace Tyuiu.Programmiste.Sprint3.Task5.V5.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidGetSumSumSeries()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 2;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 3;
            int stopValue2 = 3;

            // Act
            double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(double.IsNaN(result));
            Assert.IsFalse(double.IsInfinity(result));
        }

        [TestMethod]
        public void GetSumSumSeries_WithInvalidRanges_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 2;
            int startValue1 = 5;
            int startValue2 = 1;
            int stopValue1 = 3;
            int stopValue2 = 3;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2));
        }

        [TestMethod]
        public void GetSumSumSeries_WithSingleValues_ReturnsCorrectSum()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 2;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 1;
            int stopValue2 = 1;

            // Act
            double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

            // Assert - Calcul manuel
            double expectedTerm1 = (Math.Pow(2, 1) + 2) / 1;  // (2 + 2)/1 = 4
            double expectedTerm2 = (Math.Pow(2, 1) + 3) / Math.Pow(1, 2);  // (2 + 3)/1 = 5
            double expected = expectedTerm1 + expectedTerm2;  // 4 + 5 = 9

            Assert.AreEqual(expected, result, 1e-10);
        }

        [TestMethod]
        public void GetSumSumSeries_WithDifferentRanges_ReturnsCorrectSum()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 1;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 2;
            int stopValue2 = 2;

            // Act
            double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

            // Assert - Calcul manuel
            double sum1 = 0;
            for (int i = 1; i <= 2; i++)
            {
                sum1 += (Math.Pow(1, i) + 2) / i;
            }

            double sum2 = 0;
            for (int j = 1; j <= 2; j++)
            {
                sum2 += (Math.Pow(1, j) + 3) / Math.Pow(j, 2);
            }

            double expected = sum1 + sum2;
            Assert.AreEqual(expected, result, 1e-10);
        }

        [TestMethod]
        public void GetSumSumSeries_WithZeroValues_HandlesCorrectly()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 0;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 2;
            int stopValue2 = 2;

            // Act
            double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

            // Assert - Vérifie que le calcul se fait sans erreur
            Assert.IsNotNull(result);
            Assert.IsFalse(double.IsNaN(result));
        }
    }
}

