using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.CompanyResources.StockProducts
{
    public class AddProducts_ViewModel
    {
        public string Product { get; set; }
        public Label ValueMoney { get; set; } = new Label();

        private decimal value;
        public decimal Value 
        {
            get { return value; }
            set { this.value = value; ValueMoney.Text = this.value.ToString("C"); }
        }

        public ICommand AddProductCommand { get; set; }

        public AddProducts_ViewModel(StockProducts_ViewModel product)
        {
            AddProductCommand = new Command(async () => 
            {
                if (!string.IsNullOrEmpty(Product) && !string.IsNullOrEmpty(Value.ToString()))
                {
                    await App.ProductsDataBase.Save_DB_Product_Async(new Product { ProductName = $"{this.Product}", ProductValue = Value});
                    product.UpdateListProducts();
                    await App.Current.MainPage.DisplayAlert($"{Product}",
                        $"{AppResources.Successfully_added}",
                        $"{AppResources.Ok}");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert($"{AppResources.Product_and_Value_empty}",
                        $"{AppResources.Please_make_sure_you_have_added_something_in_the_Product_entry}",
                        $"{AppResources.Ok}");
                }
            });
        }
    }
}
