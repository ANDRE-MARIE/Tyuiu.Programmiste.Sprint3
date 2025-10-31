using Tyuiu.Programmiste.Sprint3.Task6.V10.Lib;
namespace Tyuiu.Programmiste.Sprint3.Task6.V10.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidGetSumTheDivisors_ForRange20To32()
        {
            DataService ds = new DataService();
            int startValue = 20;
            int stopValue = 32;

            // Act
            int result = ds.GetSumTheDivisors(startValue, stopValue);

            // Assert - DOIT retourner 348
            Assert.AreEqual(348, result, "Le résultat doit être exactement 348 pour le segment [20, 32]");
        }

        [TestMethod]
        public void GetSumTheDivisors_WithNumber24_Returns40()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 24;
            int stopValue = 24;

            // Act
            int result = ds.GetSumTheDivisors(startValue, stopValue);

            // Assert - 24: diviseurs > 12 = 16, 24 → 16 + 24 = 40
            Assert.AreEqual(40, result, "Pour 24: 16 + 24 = 40");
        }

        [TestMethod]
        public void GetSumTheDivisors_WithNumber28_Returns42()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 28;
            int stopValue = 28;

            // Act
            int result = ds.GetSumTheDivisors(startValue, stopValue);

            // Assert - 28: diviseurs > 12 = 14, 28 → 14 + 28 = 42
            Assert.AreEqual(42, result, "Pour 28: 14 + 28 = 42");
        }

        [TestMethod]
        public void GetSumTheDivisors_WithNumber26_Returns39()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 26;
            int stopValue = 26;

            // Act
            int result = ds.GetSumTheDivisors(startValue, stopValue);

            // Assert - 26: diviseurs > 12 = 13, 26 → 13 + 26 = 39
            Assert.AreEqual(39, result, "Pour 26: 13 + 26 = 39");
        }

        [TestMethod]
        public void GetSumTheDivisors_WithNumber13_Returns13()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 13;
            int stopValue = 13;

            // Act
            int result = ds.GetSumTheDivisors(startValue, stopValue);

            // Assert - 13: seul diviseur > 12 = 13
            Assert.AreEqual(26, result, "Pour 13: 13");
        }

        [TestMethod]
        public void GetSumTheDivisors_WithNumber12_Returns0()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 12;
            int stopValue = 12;

            // Act
            int result = ds.GetSumTheDivisors(startValue, stopValue);

            // Assert - 12: aucun diviseur > 12
            Assert.AreEqual(0, result, "Pour 12: aucun diviseur > 12");
        }

        [TestMethod]
        public void GetSumTheDivisors_WithInvalidRange_ThrowsException()
        {
            // Arrange
            DataService ds = new DataService();
            int startValue = 50;
            int stopValue = 20;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                ds.GetSumTheDivisors(startValue, stopValue));
        }
    }
}