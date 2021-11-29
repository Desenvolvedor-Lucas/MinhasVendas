using MinhasVendas.ABC_Translate;
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
    public partial class AddProducts_Page : ContentPage
    {
        AddProducts_ViewModel ViewModel;
        public AddProducts_Page(StockProducts_ViewModel products_ViewModel)
        {
            ViewModel = new AddProducts_ViewModel(products_ViewModel);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = ViewModel;
        }

        private void InitializeStringsTranslate()
        {
            //contentPage
            this.Title = $"{AppResources.New_Product}";

            //Labels
            this.lbl_Product.Text = $"{AppResources.Product}";
            this.lbl_Value.Text = $"{AppResources.Value}";

            //entrys
            this.entry_Product.Placeholder = $"{AppResources.Enter_the_product_name}";
            this.entry_Value.Placeholder = $"{AppResources.Enter_the_value}";

            //buttons
            this.btn_Add_Product.Text = $"{AppResources.Add_Product}";
        }
    }
}