using MinhasVendas.ABC_Translate;
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
    public partial class AddCustomers_Page : ContentPage
    {
        AddCustomers_ViewModel VM;

        public AddCustomers_Page(Customers_ViewModel customers)
        {
            VM = new AddCustomers_ViewModel(customers);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = VM;
        }

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Add_customer}";

            //Labels
            this.lbl_Customer.Text = $"{AppResources.Customer}";

            //entry
            this.entry_Name.Placeholder = $"{AppResources.Enter_the_customers_name}";

            //Buttons
            this.btn_Add_Customer.Text = $"{AppResources.Add_customer}";
        }
    }
}