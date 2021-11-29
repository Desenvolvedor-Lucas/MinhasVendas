using MinhasVendas.ABC_Translate;
using MinhasVendas.ViewModels.Cash.Sales;
using MinhasVendas.ViewModels.CompanyResources.StockProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas.Views.CompanyResources.StockProducts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseProduct_Page : ContentPage
    {
        bool IsSale = false;
        Sale_ViewModel Sale;
        Sale_Edit_DetailViewModel EditSale;
        ChooseProduct_ViewModel viewModel;
        public ChooseProduct_Page(Sale_ViewModel sale_ViewModel)
        {
            IsSale = true;
            Sale = sale_ViewModel;
            viewModel = new ChooseProduct_ViewModel(sale_ViewModel);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = viewModel;
        }

        public ChooseProduct_Page(Sale_Edit_DetailViewModel saleEdit_ViewModel)
        {
            IsSale = false;
            EditSale = saleEdit_ViewModel;
            viewModel = new ChooseProduct_ViewModel(saleEdit_ViewModel);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = viewModel;
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Products}";

            //Buttons
            this.btn_Unknown.Text = $"{AppResources.Unknown}";
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var answer = await DisplayAlert($"{viewModel.ChooseProductList[e.ItemIndex].ProductName}",
                $"{AppResources.Add_this_product_to_the_sale}",
                $"{AppResources.Yes}",
                $"{AppResources.No}");
            if (answer)
            {
                var value = viewModel.ChooseProductList[e.ItemIndex].ProductValue;
                if (IsSale)
                    Sale.ChooseProduct(viewModel.ChooseProductList[e.ItemIndex].ProductName,
                        viewModel.ChooseProductList[e.ItemIndex].ProductValue);
                else
                    EditSale.ChooseProduct(viewModel.ChooseProductList[e.ItemIndex].ProductName,
                        viewModel.ChooseProductList[e.ItemIndex].ProductValue);

                await Navigation.PopAsync();
            }
        }
    }
}