using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ThemeManagerRt
{
    public static class ThemeExtensions
    {
        public static void ThemeEnableThisElement(this FrameworkElement element)
        {
            var tm = Application.Current.Resources["ThemeManager"];
            if (tm == null)
            {
                throw new InvalidOperationException("ThemeManager hasn't been created in your App.xaml with the key of 'ThemeManager'");
            }

            var binding = new Binding
            {
                Source = tm,
                Path = new PropertyPath("Theme"),
                Mode = BindingMode.OneWay
            };

            element.SetBinding(FrameworkElement.RequestedThemeProperty, binding);
        }
    }
}
