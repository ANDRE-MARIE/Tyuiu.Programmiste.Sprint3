using Tyuiu.Programmiste.Sprint3.Task3.V18.Lib;

namespace Tyuiu.Programmiste.Sprint3.Task3.V18.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void ValidReplaceNumOnChar()
        {
            // Arrange
            DataService ds = new DataService();
            string input = "4n5nvf 56 bgy";
            char replacement = 'n';

            // Act
            string result = ds.ReplaceNumOnChar(input, replacement);

            // Assert
            string expected = "nnnnvf nn bgy";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceNumOnChar_WithEmptyString_ReturnsEmpty()
        {
            // Arrange
            DataService ds = new DataService();
            string input = "";
            char replacement = 'n';

            // Act
            string result = ds.ReplaceNumOnChar(input, replacement);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ReplaceNumOnChar_WithNoDigits_ReturnsOriginal()
        {
            // Arrange
            DataService ds = new DataService();
            string input = "abcdef gh";
            char replacement = 'n';

            // Act
            string result = ds.ReplaceNumOnChar(input, replacement);

            // Assert
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void ReplaceNumOnChar_WithAllDigits_ReturnsAllReplaced()
        {
            // Arrange
            DataService ds = new DataService();
            string input = "1234567890";
            char replacement = 'x';

            // Act
            string result = ds.ReplaceNumOnChar(input, replacement);

            // Assert
            string expected = "xxxxxxxxxx";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceNumOnChar_WithSpecialCharacters_PreservesSpecials()
        {
            // Arrange
            DataService ds = new DataService();
            string input = "a1b2c3!@#$%";
            char replacement = 'n';

            // Act
            string result = ds.ReplaceNumOnChar(input, replacement);

            // Assert
            string expected = "anbncn!@#$%";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceNumOnChar_WithDifferentReplacementChar_WorksCorrectly()
        {
            // Arrange
            DataService ds = new DataService();
            string input = "4n5nvf 56 bgy";
            char replacement = 'X';

            // Act
            string result = ds.ReplaceNumOnChar(input, replacement);

            // Assert
            string expected = "XnXnvf XX bgy";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceNumOnChar_WithMixedCase_PreservesCase()
        {
            // Arrange
            DataService ds = new DataService();
            string input = "1A2b3C4d";
            char replacement = 'n';

            // Act
            string result = ds.ReplaceNumOnChar(input, replacement);

            // Assert
            string expected = "nAnbnCnd";
            Assert.AreEqual(expected, result);
        }
    }
}
