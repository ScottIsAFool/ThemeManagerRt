using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ThemeManagerRt
{
    public class ThemeEnabledPage : Page
    {
        public ThemeEnabledPage()
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
            SetBinding(RequestedThemeProperty, binding);
        }
    }
}
