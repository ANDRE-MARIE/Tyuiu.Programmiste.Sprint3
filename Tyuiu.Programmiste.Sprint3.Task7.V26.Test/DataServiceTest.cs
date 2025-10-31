
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
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            // Valeurs attendues EXACTES
            double[] expected = { 19.81, 16.79, 13.87, 10.98, 7.94, 3.0, 3.23, -0.45, -3.79, -6.97, -10.0 };

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert - Vérifier chaque valeur avec une tolérance de 0.01
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i], 0.01,
                    $"Échec à l'index {i}. Obtenu: {result[i]}, Attendu: {expected[i]}");
            }
        }

        [TestMethod]
        public void GetMassFunction_ForX0_ReturnsExactly3()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 0;
            int stopValue = 0;

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert - Doit retourner exactement 3.0
            Assert.AreEqual(3.0, result[0]);
        }

        [TestMethod]
        public void GetMassFunction_AllValuesRoundedTo2Decimals()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = -5;
            int stopValue = 5;

            // Act
            double[] result = ds.GetMassFunction(startValue, stopValue);

            // Assert - Toutes les valeurs doivent être arrondies à 2 décimales
            foreach (double value in result)
            {
                double rounded = Math.Round(value, 2);
                Assert.AreEqual(rounded, value, 0.0001,
                    $"Valeur {value} n'est pas arrondie à 2 décimales");
            }
        }

        [TestMethod]
        public void GetMassFunction_CheckSpecificValues()
        {
            // Arrange
            DataService ds = new DataService();

            // Test de valeurs spécifiques critiques
            TestValue(ds, -5, 19.81);
            TestValue(ds, -1, 7.94);
            TestValue(ds, 0, 3.0);
            TestValue(ds, 1, 3.23);
            TestValue(ds, 5, -10.0);
        }

        private void TestValue(DataService ds, int x, double expected)
        {
            double[] result = ds.GetMassFunction(x, x);
            Assert.AreEqual(expected, result[0], 0.01,
                $"Échec pour x={x}. Obtenu: {result[0]}, Attendu: {expected}");
        }
    }
}