using System;
using System.Globalization;
using Xunit;

namespace Monotio.Util.Tests
{
    public class CultureSwitcherShould
    {
        [Fact]
        public void SwitchCultureUsingCultureInfo()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");

            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);
            Assert.Equal("fr-FR", CultureInfo.CurrentUICulture.Name);

            using (new CultureSwitcher(new CultureInfo("sv-SE"), new CultureInfo("fi-FI")))
            {
                Assert.Equal("sv-SE", CultureInfo.CurrentCulture.Name);
                Assert.Equal("fi-FI", CultureInfo.CurrentUICulture.Name);
            }

            Assert.Equal("en-US", CultureInfo.CurrentCulture.Name);
            Assert.Equal("fr-FR", CultureInfo.CurrentUICulture.Name);
        }
    }
}
