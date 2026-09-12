using CatFactApp.Models;

namespace CatFactApp.Tests
{
    public class CatFactTests
    {
        [Fact]
        public void CatFact_ShouldStoreFactAndLength()
        {
            // Arrange
            CatFact catFact = new CatFact();

            // Act
            catFact.Fact = "Cats sleep a lot.";
            catFact.Length = 17;

            // Assert
            Assert.Equal("Cats sleep a lot.", catFact.Fact);
            Assert.Equal(17, catFact.Length);
        }
    }
}