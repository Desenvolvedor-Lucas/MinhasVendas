using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MinhasVendas.Models;
using MinhasVendas.Views.Cash.Sales;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MinhasVendas.ABC_Translate;

namespace MinhasVendas.ViewModels.Cash
{
    public class Cash_Items_DetailViewModel
    {
        public static ItemTappedEventArgs ItemTapped;
        Cash_ViewModel Cash_VM;

        //Props
        public Label Name { get; set; } = new Label();
        public Label Date { get; set; } = new Label();

        public Label Product { get; set; } = new Label();
        public Label Value { get; set; } = new Label();
        public Label Unit { get; set; } = new Label();

        public Label TotalValue { get; set; } = new Label();

        public ICommand Exclude { get; set; }
        public ICommand Edit { get; set; }

        public Cash_Items_DetailViewModel(Cash_ViewModel vm)
        {
            Cash_VM = vm;

            InicializeDetail();

            Exclude = new Command(async () => 
            {
                var ICam = await App.Current.MainPage.DisplayAlert($"{AppResources.Attention}", 
                    $"{AppResources.Do_you_really_want_to_delete_this_sale}", 
                    $"{AppResources.Yes}", 
                    $"{AppResources.No}");

                if (ICam)
                {
                    await Cash_VM.DeleteSaleAsync(ItemTapped.ItemIndex);
                    await App.Current.MainPage.Navigation.PopAsync(true);

                }
            });

            Edit = new Command( async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new Sale_Edit_DetailPage(Cash_VM), true);
            });
        }

        public void InicializeDetail()
        {
            var product = Cash_VM.SaleList[ItemTapped.ItemIndex];

            Name.Text = product.Name;
            Date.Text = product.DateSale;

            Product.Text = product.Product;
            Value.Text = product.Value.ToString("C");
            Unit.Text = product.Unit.ToString();

            TotalValue.Text = product.TotalValueProduct.ToString("C");
        }

        public static void GetProductSelected(ItemTappedEventArgs e)
        {
            ItemTapped = e;
        }

    }
}
