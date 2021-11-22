using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.ViewModels;
using MinhasVendas.ViewModels.Cash;
using MinhasVendas.ViewModels.Cash.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas.Views.Cash.Sales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sale_Edit_DetailPage : ContentPage
    {
        public Sale_Edit_DetailViewModel viewModel { get; set; }

        public Cash_Items_DetailViewModel Detail_VM { get; set; }
        public Cash_ViewModel CashVM { get; set; }

        public Sale_Edit_DetailPage(Cash_ViewModel cash)
        {
            CashVM = cash;
            Detail_VM = new Cash_Items_DetailViewModel(cash);
            viewModel = new Sale_Edit_DetailViewModel(CashVM, Detail_VM);

            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = viewModel;
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Sale_Edit}";

            //Labels
            this.lbl_Sale_Information.Text = $"{AppResources.Sale_Information}";
            this.lbl_Total_Value.Text = $"{AppResources.Total_Value}: ";

            //Buttons
            this.btn_Name.Text = $"{AppResources.Name}";
            this.btn_Pruduct.Text = $"{AppResources.Product}";
            this.btn_Value.Text = $"{AppResources.Value}";
            this.btn_Unit.Text = $"{AppResources.Unit}";
            this.btn_Saleconclude.Text = $"{AppResources.Sale_Conclude}";

            //Entrys
            this.entry_Name.Placeholder = $"{AppResources.Enter_the_customers_name}";
            this.entry_Product.Placeholder = $"{AppResources.Enter_the_product_name}";
            this.entry_Value.Placeholder = $"{AppResources.Enter_the_value}";
            this.entry_Unit.Placeholder = $"{AppResources.Enter_the_quantity_of_product}";
        }

    }
}