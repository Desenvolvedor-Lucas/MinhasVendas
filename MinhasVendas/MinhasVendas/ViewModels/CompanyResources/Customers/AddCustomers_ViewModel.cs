using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.Customers
{
    public class AddCustomers_ViewModel
    {
        Customers_ViewModel customers_VM;
        public string Name { get; set; }
        public ICommand AddCustomer { get; set; }

        public AddCustomers_ViewModel(Customers_ViewModel customers)
        {
            customers_VM = customers;
            AddCustomer = new Command( async() => 
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    await App.CustomersDataBase.Save_DB_Customer_Async(new Customer { CustomerName = $"{this.Name}" });
                    customers.CustomersListUpdate();
                    await App.Current.MainPage.DisplayAlert($"{Name}", 
                        $"{AppResources.Successfully_added}", 
                        $"{AppResources.Ok}");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert($"{AppResources.Name_empty}", 
                        $"{AppResources.Please_make_sure_you_have_added_something_in_the_Name_entry}",
                        $"{AppResources.Ok}");
                }
            });
        }
    }
}
