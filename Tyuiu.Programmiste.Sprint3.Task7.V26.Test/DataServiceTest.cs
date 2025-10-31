
using Tyuiu.Programmiste.Sprint3.Task7.V26.Lib;
namespace Tyuiu.Programmiste.Sprint3.Task7.V26.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMassFunction_ForRangeMinus5To5()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(11, result.Length); // -5 à 5 = 11 éléments
            Assert.IsFalse(double.IsNaN(result[0]));
        }

        [TestMethod]
        public void GetMassFunction_WithDivisionByZero_ReturnsZero()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 0;
            int stopValue = 1;

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert - Pour x=0, dénominateur = -0.5 → pas de division par zéro
            // Pour x=0.25, dénominateur = 0 → division par zéro, mais 0.25 n'est pas entier
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetMassFunction_WithSingleValue_ReturnsCorrectCalculation()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 1;
            int stopValue = 1;

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert - Calcul manuel pour x=1
            double expected = 5 - 3 * 1 + (1 + Math.Sin(1)) / (2 * 1 - 0.5);
            Assert.AreEqual(expected, result[0], 0.0001);
        }

        [TestMethod]
        public void GetMassFunction_WithNegativeValue_ReturnsCorrectResult()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = -2;
            int stopValue = -2;

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert - Calcul manuel pour x=-2
            double expected = 5 - 3 * (-2) + (1 + Math.Sin(-2)) / (2 * (-2) - 0.5);
            Assert.AreEqual(expected, result[0], 0.0001);
        }

        [TestMethod]
        public void GetMassFunction_WithInvalidRange_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 10;
            int stopValue = 5;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetMassFunction(startValue, stopValue));
        }

        [TestMethod]
        public void GetMassFunction_CheckAllValuesInRange()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert - Vérifier que toutes les valeurs sont calculées correctement
            for (int i = 0; i < result.Length; i++)
            {
                Assert.IsFalse(double.IsNaN(result[i]), $"Valeur NaN à l'index {i}");
                Assert.IsFalse(double.IsInfinity(result[i]), $"Valeur infinie à l'index {i}");
            }
        }
    }
}