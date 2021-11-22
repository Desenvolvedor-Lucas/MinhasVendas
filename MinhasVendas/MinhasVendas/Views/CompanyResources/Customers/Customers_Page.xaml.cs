using MinhasVendas.ABC_Translate;
using MinhasVendas.ViewModels.Cash.Sales;
using MinhasVendas.ViewModels.CompanyResources.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas.Views.CompanyResources.Customers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customers_Page : ContentPage
    {
        Customers_ViewModel vm;
        public Customers_Page()
        {
            vm = new Customers_ViewModel();
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = vm;
        }

        private void InitializeStringsTranslate()
        {
            this.Title = $"{AppResources.Customers}";
            this.btn_New_Customer.Text = $"{AppResources.New_Customer}";
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = await App.CustomersDataBase.Get_DB_Customer_Async();
            Models.Customer customer = list[e.ItemIndex];
            await Navigation.PushAsync(new Customers_DetailPage(customer));
        }
    }
}