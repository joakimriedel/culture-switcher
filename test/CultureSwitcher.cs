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
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);
            Assert.Equal("en-US", CultureInfo.CurrentUICulture.Name);

            using (new CultureSwitcher("sv-SE"))
            {
                Assert.Equal("sv-SE", CultureInfo.CurrentCulture.Name);
                Assert.Equal("sv-SE", CultureInfo.CurrentUICulture.Name);
            }

            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);
            Assert.Equal("en-US", CultureInfo.CurrentUICulture.Name);
        }

        [Fact]
        public void ThrowIfUICultureAndCultureDiffers()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("sv-SE");

            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);
            Assert.Equal("sv-SE", CultureInfo.CurrentUICulture.Name);

            Assert.Throws<InvalidOperationException>(() => new CultureSwitcher("de-DE"));
        }
    }
}
