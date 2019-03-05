using System;
using System.Globalization;

namespace Monotio.Util
{
    public class CultureSwitcher : IDisposable
    {
        private readonly CultureInfo _originalCulture;

        public CultureSwitcher(string culture)
        {
            _originalCulture = CultureInfo.CurrentCulture;
            var cultureInfo = String.IsNullOrEmpty(culture) ? CultureInfo.CurrentCulture : new CultureInfo(culture);
            
            SetCulture(cultureInfo);
        }

        private void SetCulture(CultureInfo cultureInfo)
        {
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }

        public void Dispose()
        {
            SetCulture(_originalCulture);
        }
    }
}
