using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.Views.CompanyResources.Customers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.Customers
{
    public class Customers_ViewModel
    {
        public ObservableCollection<Customer> CustomersList { get; set; } = new ObservableCollection<Customer>();


        public ICommand NewCustomer { get; set; }

        public Customers_ViewModel()
        {
            CustomersListUpdate();

            //will implements
            NewCustomer = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddCustomers_Page(this));
            });
        }

        public async void CustomersListUpdate()
        {
            CustomersList.Clear();
            int numberUpdate = 0;
            var ListData = await App.CustomersDataBase.Get_DB_Customer_Async();

            foreach (var customerData in ListData)
            {
                if (customerData != null)
                {
                    customerData.NumberList = numberUpdate;
                    CustomersList.Add(customerData);
                    numberUpdate++;
                }
            }
        }
    }
}
