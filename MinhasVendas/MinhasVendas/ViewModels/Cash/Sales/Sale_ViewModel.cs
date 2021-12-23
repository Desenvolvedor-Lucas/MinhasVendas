using MinhasVendas.Models;
using MinhasVendas.ViewModels.CompanyResources.Customers;
using MinhasVendas.Views.CompanyResources.Customers;
using MinhasVendas.Views.CompanyResources.StockProducts;
using MinhasVendas.Views.User.CompanyResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.Cash.Sales
{
    public class Sale_ViewModel : INotifyPropertyChanged
    {
        public Cash_ViewModel Cash_VM { get; set; }

        public Label Name { get; set; } = new Label();

        public Label Product { get; set; } = new Label();

        private decimal _value;
        public decimal Value 
        {
            get { return _value; }
            set { 
                _value = value;
                //OnPropertyChanged();
                CalculationTotal = Unit * Value;
                ValueMoney.Text = Value.ToString("C");
                //erro da vircula acontece quando chega no OnPropertyChanged, falta arrumar
                //Acho que nem precisa de OnPropertyChanged, sei lá
            }
        }

        //
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //

        private int _unit;
        public int Unit 
        {
            get { return _unit; }
            set  {
                _unit = value;
                    CalculationTotal = Unit * Value;
            }
        }

        private decimal _calculationTotal;
        public decimal CalculationTotal 
        {
            get { return _calculationTotal; }
            set { _calculationTotal = value; TotalValue.Text = $"{CalculationTotal.ToString("C")}"; } 
        }


        public Label TotalValue { get; set; } = new Label();
        public Label ValueMoney { get; set; } = new Label();

        public ICommand NameCommand { get; set; }

        public ICommand ProductCommand { get; set; }

        public ICommand SaleConclude { get; set; }

        public Sale_ViewModel(Cash_ViewModel cash)
        {
            Cash_VM = cash;
            Unit = 1;

            NameCommand = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new ChooseClient_Page(this));
            });

            ProductCommand = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new ChooseProduct_Page(this));
            });

            SaleConclude = new Command(async () =>
            {
                var Check = new CheckSale(Name.Text,
                       Product.Text,
                       Unit,
                       Value);

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

        public void ChooseProduct(string product, decimal value)
        {
            Product.Text = product;
            Value = value;
        }

        public async void AddSaleToDataBase()
        {
            //Falta fazer tipo o metodo comentado aqui em baixo AddItemsproduct()
            await App.SaleDatabase.Save_DB_SaleProduct_Async(new SaleProduct
            {
                DateSale = Cash_VM.Date.Text,
                Name = this.Name.Text,
                Product = this.Product.Text,
                Unit = Unit,
                Value = Value,
                TotalValueProduct = CalculationTotal
            });

            Cash_VM.SalesListUpdate();
        }

    }
}
