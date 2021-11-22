using MinhasVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MinhasVendas.Models;
using MinhasVendas.ViewModels.Cash.Sales;
using MinhasVendas.ViewModels.Cash;
using MinhasVendas.ABC_Translate;

namespace MinhasVendas.Views.Cash.Sales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sale_Page : ContentPage
    {
        public Sale_ViewModel viewModel { get; set; }
        public Cash_ViewModel CashVM { get; set; }

        public Sale_Page(Cash_ViewModel cash)
        {
            CashVM = cash;
            viewModel = new Sale_ViewModel(CashVM);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = viewModel;
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Sale}";

            //Labels
            this.lbl_Sale_Information.Text = $"{AppResources.Sale_Information}";
            this.lbl_Total_Value.Text = $"{AppResources.Total_Value}: ";

            //Buttons
            this.btn_Name.Text = $"{AppResources.Name}";
            this.btn_Product.Text = $"{AppResources.Product}";
            this.btn_Value.Text = $"{AppResources.Value}";
            this.btn_Unit.Text = $"{AppResources.Unit}";
            this.btn_Sale_Conclude.Text = $"{AppResources.Sale_Conclude}";

            //Entrys
            this.entry_Name.Placeholder = $"{AppResources.Enter_the_customers_name}";
            this.entry_Product.Placeholder = $"{AppResources.Enter_the_product_name}";
            this.entry_Value.Placeholder = $"{AppResources.Enter_the_value}";
            this.entry_Unit.Placeholder = $"{AppResources.Enter_the_quantity_of_product}";
        }
        
    }
}