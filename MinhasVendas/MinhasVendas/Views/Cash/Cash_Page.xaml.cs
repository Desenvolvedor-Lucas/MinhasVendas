using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.ViewModels;
using MinhasVendas.ViewModels.Cash;
using MinhasVendas.Views.Cash.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas.Views.Cash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cash_Page : ContentPage
    {
        Cash_ViewModel viewModel { get; set; }

        public Cash_Page()
        {
            viewModel = new Cash_ViewModel();
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = viewModel;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Cash_Items_DetailViewModel.GetProductSelected(e);
            await Navigation.PushAsync(new Cash_Items_DetailPage(viewModel), true);
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Cash}";

            //Labels
            this.lbl_Total.Text = $"{AppResources.Total}";

            //Buttons
            this.btn_NewSale.Text = $"{AppResources.New_Sale}";
        }
    }
}