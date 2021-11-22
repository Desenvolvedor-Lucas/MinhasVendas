using MinhasVendas.ABC_Translate;
using MinhasVendas.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEditTheme_Page : ContentPage
    {
        UserEditTheme_ViewModel vm;
        public UserEditTheme_Page()
        {
            vm = new UserEditTheme_ViewModel();
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = vm;
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Edit_Theme}";

            //Labels
            this.lbl_Default_Theme.Text = $"{AppResources.Default_theme}";
            this.lbl_Lemon_Theme.Text = $"{AppResources.Lemon_theme}";
            this.lbl_Dark_Theme.Text = $"{AppResources.Dark_theme}";
            this.lbl_Aquatic_Theme.Text = $"{AppResources.Aquatic_theme}";
            this.lbl_Fire_Theme.Text = $"{AppResources.Fire_theme}";

            //Buttons
            //All Defined in style(App.xaml) = Choose_theme
        }

    }
}