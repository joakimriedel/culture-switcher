using System;
using System.Globalization;

namespace Monotio.Util
{
    public class CultureSwitcher : IDisposable
    {
        private readonly CultureInfo _originalCulture;
        private readonly CultureInfo _originalUICulture;

        public CultureSwitcher(CultureInfo culture, CultureInfo uiCulture)
        {
            _originalCulture = CultureInfo.CurrentCulture;
            _originalUICulture = CultureInfo.CurrentUICulture;
            SetCulture(culture, uiCulture);
        }

        private void SetCulture(CultureInfo culture, CultureInfo uiCulture)
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = uiCulture;
        }

        public void Dispose()
        {
            SetCulture(_originalCulture, _originalUICulture);
        }
    }
}
