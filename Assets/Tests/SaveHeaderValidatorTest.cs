using NUnit.Framework;
using VMGames.Core.Validation;

namespace VMGames.Core.Tests
{
    [TestFixture]
    public class SaveHeaderValidatorTests
    {
        private SaveHeaderValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new SaveHeaderValidator();
        }

        [Test]
        public void IsValidHeader_VersionLessThanOne_ReturnsFalse()
        {
            // Arrange
            int invalidVersion = 0;
            string validChecksum = "abc123hash";

            // Act
            bool result = _validator.IsValidHeader(invalidVersion, validChecksum);

            // Assert
            Assert.IsFalse(result, "Header com versão menor que 1 deve ser considerado inválido.");
        }

        [Test]
        public void IsValidHeader_ValidVersionAndChecksum_ReturnsTrue()
        {
            // Arrange
            int validVersion = 1;
            string validChecksum = "abc123hash";

            // Act
            bool result = _validator.IsValidHeader(validVersion, validChecksum);

            // Assert
            Assert.IsTrue(result, "Header com versão válida e checksum presente deve retornar true.");
        }

        // O mesmo código roda 4 vezes com entradas e expectativas diferentes
        [TestCase(-1, "checksum_ok", false)] // Versão inválida
        [TestCase(0, "checksum_ok", false)]  // Versão zero inválida
        [TestCase(1, "", false)]            // Checksum vazio
        [TestCase(1, "checksum_ok", true)]   // Header válido
        public void IsValidHeader_ValidatesMultipleScenarios(int version, string checksum, bool expectedResult)
        {            
            bool result = _validator.IsValidHeader(version, checksum);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}