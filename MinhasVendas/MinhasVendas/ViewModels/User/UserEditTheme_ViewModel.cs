using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.User
{
    public class UserEditTheme_ViewModel
    {
        public ICommand DefaultTheme { get; set; }
        public ICommand LemonTheme { get; set; }
        public ICommand DarkTheme { get; set; }
        public ICommand AquaticTheme { get; set; }
        public ICommand FireTheme { get; set; }
        
        public UserEditTheme_ViewModel()
        {
            DefaultTheme = new Command(() => 
            {
                var DefaultTheme = ThemeManager.Themes.Default;
                ThemeManager.ChangeTheme(DefaultTheme);
            });

            LemonTheme = new Command(() =>
            {
                var LemonTheme = ThemeManager.Themes.Lemon;
                ThemeManager.ChangeTheme(LemonTheme);
            });

            DarkTheme = new Command(() =>
            {
                var DarkTheme = ThemeManager.Themes.Dark;
                ThemeManager.ChangeTheme(DarkTheme);
            });

            AquaticTheme = new Command(() =>
            {
                var AquaticTheme = ThemeManager.Themes.Aquatic;
                ThemeManager.ChangeTheme(AquaticTheme);
            });

            FireTheme = new Command(() => 
            {
                var FireTheme = ThemeManager.Themes.Fire;
                ThemeManager.ChangeTheme(FireTheme);
            });
            
        }
    }
}
