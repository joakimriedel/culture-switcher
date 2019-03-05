using System;
using System.Globalization;
using Xunit;

namespace Monotio.Util.Tests
{
    public class CultureSwitcherShould
    {
        [Fact]
        public void SwitchCulture()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);

            using (new CultureSwitcher("sv-SE"))
            {
                Assert.Equal("sv-SE", CultureInfo.CurrentCulture.Name);
            }

            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);
        }
    }
}
