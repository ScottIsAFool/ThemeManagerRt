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
            DefaultTheme = ElementTheme.Dark;
        }

        static ThemeManager()
        {
            _themeManager = new ThemeManager();
        }

        public ElementTheme Theme { get; set; }

        public static ElementTheme DefaultTheme { get; set; }

        public static void ChangeTheme(Uri resourceUri)
        {
            var themeDict = DefaultTheme == ElementTheme.Dark ? "Dark" : "Light";
            var dicts = ((ResourceDictionary)Application.Current.Resources.ThemeDictionaries[themeDict]).MergedDictionaries;
            dicts.Clear();
            var x = new ResourceDictionary { Source = resourceUri };
            dicts.Add(x);

            if (DefaultTheme == ElementTheme.Dark)
            {
                _themeManager.Theme = ElementTheme.Light;
                _themeManager.Theme = ElementTheme.Dark;
            }
            else
            {
                _themeManager.Theme = ElementTheme.Dark;
                _themeManager.Theme = ElementTheme.Light;
            }
        }
    }
}
