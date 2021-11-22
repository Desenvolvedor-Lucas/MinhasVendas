using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MinhasVendas.ViewModels.User;
using MinhasVendas.ABC_Translate;

namespace MinhasVendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class User_Page : ContentPage
    {
        User_ViewModel vm;
        public User_Page()
        {
            vm = new User_ViewModel();
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = vm;
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.User}";

            //Buttons
            this.btn_Edit_User.Text = $"{AppResources.Edit_User}";
            this.btn_Stock_Of_Products.Text = $"{AppResources.Stock_of_products}";
            this.btn_Earnings.Text = $"{AppResources.Earnings}";
            this.btn_Customers.Text = $"{AppResources.Customers}";
            this.btn_Edit_Theme.Text = $"{AppResources.Edit_Theme}";
        }

    }
}