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

        //De pouco em pouco esta indo, veja o app e continue melhorando
        //falta terminar as algumas das coisas do /customer(s)
        //outras coisa a fazer depois é o Sale e EditSale DB na parte do
        //estoque de produtos como fiz com o nome do cliente
        //mais antes é preciso arrumar as entradas de valor e unidade do produto,
        //arrumar bugs e melhorar para o usuário na questão do valor e unidade.

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
