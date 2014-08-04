using System;
using Windows.UI.Xaml;
using PropertyChanged;

namespace ThemeManagerRt
{
    [ImplementPropertyChanged]
    public class ThemeManager
    {
        private static ThemeManager _themeManager;
        public ThemeManager()
        {
            _themeManager = this;
        }

        public ElementTheme Theme { get; set; }

        public static void ChangeTheme(Uri resourceUri)
        {
            var dicts = ((ResourceDictionary)Application.Current.Resources.ThemeDictionaries["Dark"]).MergedDictionaries;
            dicts.Clear();
            var x = new ResourceDictionary { Source = resourceUri };
            dicts.Add(x);

            _themeManager.Theme = ElementTheme.Light;
            _themeManager.Theme = ElementTheme.Dark;
        }
    }
}
