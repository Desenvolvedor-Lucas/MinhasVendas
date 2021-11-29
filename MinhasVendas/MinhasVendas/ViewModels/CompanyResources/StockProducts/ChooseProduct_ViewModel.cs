using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.ViewModels.Cash.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.StockProducts
{
    public class ChooseProduct_ViewModel
    {
        public ObservableCollection<Product> ChooseProductList { get; set; } = new ObservableCollection<Product>();

        public ICommand UnknownCommand { get; set; }

        public ChooseProduct_ViewModel(Sale_ViewModel sale)
        {
            ChooseProductListUpdate();

            UnknownCommand = new Command(async () =>
            {
                //editsale.ChooseName($"{AppResources.Anonymous}");
                sale.ChooseProduct($"{AppResources.Unknown}", 0); //desconhecido
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }


        public ChooseProduct_ViewModel(Sale_Edit_DetailViewModel editsale)
        {
            ChooseProductListUpdate();

            UnknownCommand = new Command(async() => 
            {
                //editsale.ChooseName($"{AppResources.Anonymous}");
                editsale.ChooseProduct($"{AppResources.Unknown}", 0); //desconhecido
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }

        public async void ChooseProductListUpdate()
        {
            ChooseProductList.Clear();
            int numberUpdate = 0;
            var ListData = await App.ProductsDataBase.Get_DB_Product_Async();

            foreach (var customerData in ListData)
            {
                if (customerData != null)
                {
                    customerData.NumberList = numberUpdate;
                    ChooseProductList.Add(customerData);
                    numberUpdate++;
                }
            }
        }
    }
}
