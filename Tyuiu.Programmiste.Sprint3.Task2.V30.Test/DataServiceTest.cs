using Tyuiu.Programmiste.Sprint3.Task2.V30.Lib;

namespace Tyuiu.Programmiste.Sprint3.Task2.V30.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMultiplySeries()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 1;
            int stopValue = 11;

            // Act
            double result = ds.GetMultiplySeries(x, startValue, stopValue);

            // Assert - Vérification que le résultat est cohérent
            Assert.IsTrue(result > 0);
            // Le résultat devrait être un grand nombre positif
        }

        [TestMethod]
        public void GetMultiplySeries_WithStartGreaterThanStop_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 15;
            int stopValue = 11;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetMultiplySeries(x, startValue, stopValue));
        }

        [TestMethod]
        public void GetMultiplySeries_WithStartEqualToStop_ReturnsSingleTerm()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 5;
            int stopValue = 5;

            // Act
            double result = ds.GetMultiplySeries(x, startValue, stopValue);

            // Assert - Calcul manuel pour i=5
            double xSquared = Math.Pow(0.25, 2);
            double expected = (xSquared * 5) + 2;
            Assert.AreEqual(expected, result, 0.001);
        }

        [TestMethod]
        public void GetMultiplySeries_WithDifferentRanges_ReturnsDifferentValues()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;

            // Act
            double result1to5 = ds.GetMultiplySeries(x, 1, 5);
            double result1to11 = ds.GetMultiplySeries(x, 1, 11);

            // Assert - Les résultats doivent être différents
            Assert.AreNotEqual(result1to5, result1to11);
            Assert.IsTrue(result1to11 > result1to5); // Plus de termes = produit plus grand
        }

        [TestMethod]
        public void GetMultiplySeries_WithStartValueZero_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 0;
            int stopValue = 11;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetMultiplySeries(x, startValue, stopValue));
        }

        [TestMethod]
        public void GetMultiplySeries_CalculatesCorrectlyForSmallRange()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 1;
            int stopValue = 3;

            // Act
            double result = ds.GetMultiplySeries(x, startValue, stopValue);

            // Assert - Calcul manuel pour i=1 à 3
            double xSquared = Math.Pow(0.25, 2); // 0.0625
            double term1 = (xSquared * 1) + 2; // 2.0625
            double term2 = (xSquared * 2) + 2; // 2.125
            double term3 = (xSquared * 3) + 2; // 2.1875
            double expected = term1 * term2 * term3; // ≈ 9.799
            Assert.AreEqual(expected, result, 0.001);
        }
    }
}
    
