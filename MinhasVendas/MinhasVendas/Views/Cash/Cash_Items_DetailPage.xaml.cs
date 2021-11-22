using MinhasVendas.ABC_Translate;
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
    public partial class Cash_Items_DetailPage : ContentPage
    {
        Cash_Items_DetailViewModel ViewModel { get; set; }

        public Cash_Items_DetailPage(Cash_ViewModel vm)
        {
            ViewModel = new Cash_Items_DetailViewModel(vm);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = ViewModel;
        }

        //Falta fazer o InitializeStringstranslate para outras classes, eu já fiz em cash e cashDetail

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Details}";

            //Labels
            this.lbl_Client.Text = $"{AppResources.Client}: ";
            this.lbl_Date.Text = $"{AppResources.Date}: ";
            this.lbl_Shopped.Text = $"{AppResources.Shopped}: ";
            this.lbl_Value_Product.Text = $"{AppResources.Value_Product}: ";
            this.lbl_Units.Text = $"{AppResources.Units}: ";
            this.lbl_Total_Value.Text = $"{AppResources.Total_Value}";

            //Buttons
            this.btn_Exclude.Text = $"{AppResources.Exclude}";
            this.btn_Edit.Text = $"{AppResources.Edit}";
        }
    }
}