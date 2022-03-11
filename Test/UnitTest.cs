using Core.Common;
using Xunit;

namespace Test
{
    public class UnitTest
    {
        public UnitTest()
        {
        }

        [Fact]
        public void FetchCurrencyRatesFromTCMB_Fetch_ReturnsData()
        {
            // Act
            var list = new TCMB().FetchCurrencyRatesFromTCMB();

            Assert.NotNull(list);
        }
    }
}