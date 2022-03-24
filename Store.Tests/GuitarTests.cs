using Xunit;

namespace Store.Tests
{
    public class GuitarTests
    {
        [Fact]
        public void IsModelNumber_WithNull_ReturnFalse()
        {
            bool actual = Guitar.IsModelNumber("NUM 12");

            Assert.False(actual);
        }

        [Fact]
        public void IsModelNumber_WithNum10_ReturnFalse()
        {
            bool actual = Guitar.IsModelNumber("NUM 12-32 132-123");

            Assert.True(actual);
        }
    }
}