using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.ViewModels.Cash.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.Customers
{
    public class ChooseClient_ViewModel
    {

        public ObservableCollection<Customer> ChooseCustomersList { get; set; } = new ObservableCollection<Customer>();

        public ICommand Anonymous { get; set; }

        public ChooseClient_ViewModel(Sale_ViewModel sale)
        {
            ChooseClientListUpdate();

            //muita coisa a fazer ainda

            Anonymous = new Command(async() => 
            {
                sale.ChooseName($"{AppResources.Anonymous}");
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }

        public ChooseClient_ViewModel(Sale_Edit_DetailViewModel editsale)
        {
            ChooseClientListUpdate();

            //muita coisa a fazer ainda

            Anonymous = new Command(async () =>
            {
                editsale.ChooseName($"{AppResources.Anonymous}");
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }


        public async void ChooseClientListUpdate()
        {
            ChooseCustomersList.Clear();
            int numberUpdate = 0;
            var ListData = await App.CustomersDataBase.Get_DB_Customer_Async();

            foreach (var customerData in ListData)
            {
                if (customerData != null)
                {
                    customerData.NumberList = numberUpdate;
                    ChooseCustomersList.Add(customerData);
                    numberUpdate++;
                }
            }
        }

    }
}
