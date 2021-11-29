using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.Views.User.CompanyResources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.StockProducts
{
    public class Products_DetailViewModel
    {
        public string Product { get; set; }

        public string ProductMoney { get; set; }

        public ICommand ExcludeCommand { get; set; }

        public Products_DetailViewModel(Product product)
        {
            Product = product.ProductName;
            ProductMoney = product.ProductMoney;

            ExcludeCommand = new Command(async() => 
            {
                var answer = await App.Current.MainPage.DisplayAlert($"{AppResources.Attention}",
                   $"{AppResources.Do_you_really_want_to_delete_this_customer}",
                   $"{AppResources.Yes}",
                   $"{AppResources.No}");
                if (answer)
                {
                    await App.ProductsDataBase.Delete_DB_Product_Async(product);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                    await App.Current.MainPage.Navigation.PushAsync(new StockProducts_Page()); //Arrumar os namespaces
                }
            });
        }
    }
}
