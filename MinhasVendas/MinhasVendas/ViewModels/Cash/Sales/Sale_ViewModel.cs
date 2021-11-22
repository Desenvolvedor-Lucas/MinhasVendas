using MinhasVendas.Models;
using MinhasVendas.ViewModels.CompanyResources.Customers;
using MinhasVendas.Views.CompanyResources.Customers;
using MinhasVendas.Views.User.CompanyResources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.Cash.Sales
{
    public class Sale_ViewModel
    {
        public Cash_ViewModel Cash_VM { get; set; }

        public Label Name { get; set; } = new Label();

        public string Product { get; set; }

        private string _value;
        public string Value 
        {
            get { return _value; }
            set { 
                _value = value;
                if (!string.IsNullOrEmpty(Unit) && !string.IsNullOrEmpty(Value))
                    CalculationTotal = int.Parse(Unit) * decimal.Parse(Value);
                else
                    CalculationTotal = 0;
            } 
        }

        private string _unit;
        public string Unit 
        {
            get { return _unit; }
            set  {
                _unit = value;
                if (!string.IsNullOrEmpty(Unit) && !string.IsNullOrEmpty(Value))
                    CalculationTotal = int.Parse(Unit) * decimal.Parse(Value);
                else
                    CalculationTotal = 0;
            }
        }

        private decimal _calculationTotal;
        public decimal CalculationTotal 
        {
            get { return _calculationTotal; }
            set { _calculationTotal = value; TotalValue.Text = $"{CalculationTotal.ToString("C")}"; } 
        }


        public Label TotalValue { get; set; } = new Label();

        public ICommand NameCommand { get; set; }

        public ICommand SaleConclude { get; set; }

        public Sale_ViewModel(Cash_ViewModel cash)
        {
            Cash_VM = cash;

            NameCommand = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new ChooseClient_Page(this));
            });

            SaleConclude = new Command(async () =>
            {
                var Check = new CheckSale(Name.Text,
                       Product,
                       int.Parse(Unit),
                       decimal.Parse(Value));

                int NumberCheck = Check.Verification();
                bool check = Check.AlertsVerification(NumberCheck);
                if (check)
                {
                    AddSaleToDataBase();
                    await App.Current.MainPage.Navigation.PopAsync(true);
                }

            });
        }

        public void ChooseName(string name)
        {
            Name.Text = name;
        }

        public async void AddSaleToDataBase()
        {
            //Falta fazer tipo o metodo comentado aqui em baixo AddItemsproduct()
            await App.SaleDatabase.Save_DB_SaleProduct_Async(new SaleProduct
            {
                DateSale = Cash_VM.Date.Text,
                Name = this.Name.Text,
                Product = this.Product,
                Unit = int.Parse(Unit),
                Value = decimal.Parse(Value),
                TotalValueProduct = CalculationTotal
            });

            Cash_VM.SalesListUpdate();
        }

    }
}
