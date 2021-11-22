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
    public partial class ChooseClient_Page : ContentPage
    {
        bool IsSale = false;
        Sale_ViewModel Sale;
        Sale_Edit_DetailViewModel EditSale;
        ChooseClient_ViewModel ViewModel;
        public ChooseClient_Page(Sale_ViewModel sale)
        {
            IsSale = true;
            Sale = sale;
            ViewModel = new ChooseClient_ViewModel(sale);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = ViewModel;
        }
        public ChooseClient_Page(Sale_Edit_DetailViewModel editsale)
        {
            IsSale = false;
            EditSale = editsale;
            ViewModel = new ChooseClient_ViewModel(editsale);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = ViewModel;
        }

        private void InitializeStringsTranslate()
        {
            //contentPage
            this.Title = $"{AppResources.My_customers}";

            //Buttons
            this.btn_Anonymous.Text = $"{AppResources.Anonymous}";
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var answer = await DisplayAlert($"{ViewModel.ChooseCustomersList[e.ItemIndex].CustomerName}", 
                $"{AppResources.Add_this_customer_to_the_sale}", 
                $"{AppResources.Yes}", 
                $"{AppResources.No}");
            if (answer)
            {
                if (IsSale)
                    Sale.ChooseName(ViewModel.ChooseCustomersList[e.ItemIndex].CustomerName);
                else
                    EditSale.ChooseName(ViewModel.ChooseCustomersList[e.ItemIndex].CustomerName);

                await Navigation.PopAsync();
            }
        }
    }
}