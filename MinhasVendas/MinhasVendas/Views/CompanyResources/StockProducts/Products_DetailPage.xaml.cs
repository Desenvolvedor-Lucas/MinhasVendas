using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
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
    public partial class Products_DetailPage : ContentPage
    {
        Products_DetailViewModel viewModel;
        public Products_DetailPage(Product product)
        {
            viewModel = new Products_DetailViewModel(product);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = viewModel;
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Details_of_Product}";

            //Labels
            this.lbl_Product.Text = $"{AppResources.Product}";
            this.lbl_Value.Text = $"{AppResources.Value}";

            //Buttons 
            this.btn_Edit_Product.Text = $"{AppResources.Edit_Product}";
            this.btn_Exclude.Text = $"{AppResources.Exclude}";
        }
    }
}