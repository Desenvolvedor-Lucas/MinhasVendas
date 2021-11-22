using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
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
    public partial class Customers_DetailPage : ContentPage
    {
        Customer_DetailViewModel ViewModel;
        public Customers_DetailPage(Customer customer)
        {
            ViewModel = new Customer_DetailViewModel(customer);
            InitializeComponent();
            InitializeStringsTranslate();

            BindingContext = ViewModel;
        }

        private void InitializeStringsTranslate()
        {
            //contentPage
            this.Title = $"{AppResources.Details_of_Customer}";

            //labes
            this.lbl_Customer.Text = $"{AppResources.Customer}";

            //Buttons
            this.btn_View_your_sales.Text = $"{AppResources.View_your_Sales}";
            this.btn_Edit_client.Text = $"{AppResources.Edit_Customer}";
            this.btn_Exclude.Text = $"{AppResources.Exclude}";
        }
    }
}