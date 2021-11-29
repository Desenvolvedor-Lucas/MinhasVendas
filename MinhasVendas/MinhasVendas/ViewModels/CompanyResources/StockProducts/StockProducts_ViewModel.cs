using MinhasVendas.Models;
using MinhasVendas.Views.CompanyResources.StockProducts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.StockProducts
{
    public class StockProducts_ViewModel
    {
        public ObservableCollection<Product> ListProducts { get; set; } = new ObservableCollection<Product>();

        public ICommand NewProductCommand { get; set; }

        public StockProducts_ViewModel()
        {
            UpdateListProducts();

            NewProductCommand = new Command(async () => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddProducts_Page(this));
            });
        }

        public async void UpdateListProducts()
        {
            ListProducts.Clear();
            int numberUpdate = 0;
            var ListData = await App.ProductsDataBase.Get_DB_Product_Async();

            foreach (var customerData in ListData)
            {
                if (customerData != null)
                {
                    customerData.NumberList = numberUpdate;
                    ListProducts.Add(customerData);
                    numberUpdate++;
                }
            }
        }
    }
}
