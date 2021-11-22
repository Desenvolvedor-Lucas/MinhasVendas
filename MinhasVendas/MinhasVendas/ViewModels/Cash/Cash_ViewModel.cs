using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.Views.Cash.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.Cash
{
    public class Cash_ViewModel
    {
        public ObservableCollection<SaleProduct> SaleList { get; set; } = new ObservableCollection<SaleProduct>();

        public Label Date { get; set; } = new Label();
        public Label TotalDay { get; set; } = new Label();

        public ICommand NewSale { get; set; }

        public Cash_ViewModel()
        {
            Date.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");

            SalesListUpdate();

            NewSale = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new Sale_Page(this), true);
            });
        }

        public async Task DeleteSaleAsync(int i)
        {
            var listData = await App.SaleDatabase.Get_DB_SaleProduct_Async();
            var product = listData[i];
            await App.SaleDatabase.Delete_DB_SaleProduct_Async(product);
            SalesListUpdate();
        }


        private void TotalDayUpdate(List<SaleProduct> listData)
        {
            decimal total = 0;

            foreach (var ValueProductTotal in listData)
                total += ValueProductTotal.TotalValueProduct;

            TotalDay.Text = total.ToString("C");
        } 

       
        public async void SalesListUpdate()
        {
            SaleList.Clear();
            int numberUpdate = 0;
            var ListData = await App.SaleDatabase.Get_DB_SaleProduct_Async();

            foreach (var SaleData in ListData)
            {
                if (SaleData != null)
                {
                    SaleData.NumberList = numberUpdate;
                    SaleData.SaleInformations = 
                        $"{AppResources.Shopped}: {SaleData.Unit} " +
                        $"{SaleData.Product} = " +
                        $"{SaleData.TotalValueProduct.ToString("C")}";
                    SaleList.Add(SaleData);

                    numberUpdate++;
                }
            }
            TotalDayUpdate(ListData);
        }
    }
}
