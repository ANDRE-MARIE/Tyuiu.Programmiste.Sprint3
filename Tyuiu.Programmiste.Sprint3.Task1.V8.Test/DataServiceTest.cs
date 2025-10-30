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

            // Assert - Vérification exacte avec la valeur attendue
            double expected = -302185.684;
            Assert.AreEqual(expected, result, 0.001); // Tolérance de 0.001
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
        public void GetSumSeries_ReturnsRoundedValue()
        {
            // Arrange
            DataService ds = new DataService();
            double x = 0.25;
            int startValue = 1;
            int stopValue = 7;

            // Act
            double result = ds.GetSumSeries(x, startValue, stopValue);

            // Assert - Vérifier que c'est bien arrondi à 3 décimales
            string resultString = result.ToString("F10");
            string decimalPart = resultString.Split(',')[1];
            Assert.IsTrue(decimalPart.Length <= 3 || decimalPart.EndsWith("000"));
        }
    }
}
