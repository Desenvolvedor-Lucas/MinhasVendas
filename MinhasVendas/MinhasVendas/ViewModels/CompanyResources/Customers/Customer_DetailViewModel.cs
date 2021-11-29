using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.Views.CompanyResources.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.Customers
{
    public class Customer_DetailViewModel
    {
        public string Customer { get; set; }

        public ICommand ExcludeCommand { get; set; }

        public Customer_DetailViewModel(Customer customer)
        {
            Customer = customer.CustomerName;

            ExcludeCommand = new Command(async() => 
            {
                var answer = await App.Current.MainPage.DisplayAlert($"{AppResources.Attention}",
                    $"{AppResources.Do_you_really_want_to_delete_this_customer}",
                    $"{AppResources.Yes}",
                    $"{AppResources.No}");
                if (answer)
                {
                    await App.CustomersDataBase.Delete_DB_Customer_Async(customer);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                    await App.Current.MainPage.Navigation.PushAsync(new Customers_Page());
                }
                    
            });
        }
    }
}
