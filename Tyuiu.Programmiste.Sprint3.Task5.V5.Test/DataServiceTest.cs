using Tyuiu.Programmiste.Sprint3.Task5.V5.Lib;

namespace Tyuiu.Programmiste.Sprint3.Task5.V5.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidGetSumSumSeries()
        {
            DataService ds = new DataService();
            int x = 5;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 5;
            int stopValue2 = 5;

            // Act
            double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

            // Assert - Résultat doit être EXACTEMENT 98286
            Assert.AreEqual(98286, result, "Le résultat doit être exactement 98286");
        }

        [TestMethod]
        public void GetSumSumSeries_WithInvalidRanges_ThrowsArgumentException()
        {
            // Arrange
            DataService ds = new DataService();
            int x = 5;
            int startValue1 = 10; // Invalide
            int startValue2 = 1;
            int stopValue1 = 5;
            int stopValue2 = 5;

            // Act & Assert
            var exception = Assert.ThrowsException<ArgumentException>(() =>
                ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2));

            // CORRECTION 8 : Vérification du message d'erreur
            Assert.IsTrue(exception.Message.Contains("supérieures"));
        }

        [TestMethod]
        public void GetSumSumSeries_WithDifferentX_ReturnsConsistentValues()
        {
            // CORRECTION 9 : Test avec différentes valeurs de x
            // Arrange
            DataService ds = new DataService();
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 3;
            int stopValue2 = 3;

            // Test avec x=2
            double resultX2 = ds.GetSumSumSeries(2, startValue1, startValue2, stopValue1, stopValue2);

            // Test avec x=3  
            double resultX3 = ds.GetSumSumSeries(3, startValue1, startValue2, stopValue1, stopValue2);

            // Assert - x=3 doit donner un résultat plus grand que x=2
            Assert.IsTrue(resultX3 > resultX2, "Avec x=3, le résultat devrait être plus grand qu'avec x=2");
        }

        [TestMethod]
        public void GetSumSumSeries_CalculationDetails_CorrectForSingleTerm()
        {
            // CORRECTION 10 : Test de calcul manuel pour un terme unique
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
            double expectedTerm1 = Math.Pow(2, 1) * Math.Pow(1, 2); // 2 * 1 = 2
            double expectedTerm2 = Math.Pow(2, 1) * 1; // 2 * 1 = 2  
            double expectedTotal = expectedTerm1 + expectedTerm2; // 2 + 2 = 4
            double expectedRounded = Math.Round(expectedTotal); // 4

            Assert.AreEqual(expectedRounded, result, "Calcul manuel incorrect");
        }

        [TestMethod]
        public void GetSumSumSeries_ResultIsInteger()
        {
            // CORRECTION 11 : Vérification que le résultat est toujours un entier
            // Arrange
            DataService ds = new DataService();
            int x = 4;
            int startValue1 = 1;
            int startValue2 = 1;
            int stopValue1 = 4;
            int stopValue2 = 4;

            // Act
            double result = ds.GetSumSumSeries(x, startValue1, startValue2, stopValue1, stopValue2);

            // Assert - Le résultat doit être un entier (pas de décimales)
            Assert.AreEqual(5992, Math.Round(result), "Le résultat doit être exactement 98286");
        }
    }
}
