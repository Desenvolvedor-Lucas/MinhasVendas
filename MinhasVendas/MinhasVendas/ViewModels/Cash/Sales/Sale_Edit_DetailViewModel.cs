using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MinhasVendas.Models;
using System.Globalization;
using System.Threading.Tasks;
using MinhasVendas.Views.Cash;
using MinhasVendas.Views.CompanyResources.Customers;
using MinhasVendas.Views.CompanyResources.StockProducts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinhasVendas.ViewModels.Cash.Sales
{
    public class Sale_Edit_DetailViewModel : INotifyPropertyChanged
    {
        int index;

        public Cash_Items_DetailViewModel Cash_Detail_VM { get; set; }
        public Label TotalValueEdit { get; set; } = new Label();
        public Cash_ViewModel Cash_VM { get; set; }

        public Label NameEdit { get; set; } = new Label();
        public Label ProductEdit { get; set; } = new Label();
        public Label ValueMoney { get; set; } = new Label();



        private decimal _value;
        public decimal ValueEdit
        {
            get { return _value; }
            set 
            { 
                _value = value;
                //OnPropertyChanged();
                ValueMoney.Text = ValueEdit.ToString("C");
                CalculationTotal = UnitEdit * ValueEdit;
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
        public int UnitEdit
        {
            get { return _unit; }
            set 
            { 
                _unit = value;
                CalculationTotal = UnitEdit * ValueEdit;
            }
        }

        decimal _calculationTotal;
        decimal CalculationTotal
        {
            get { return _calculationTotal; }
            set { _calculationTotal = value; TotalValueEdit.Text = $"{CalculationTotal.ToString("C")}"; }
        }

        public ICommand EditNameCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand SaleConcludeEdit { get; set; }
        

        public Sale_Edit_DetailViewModel(Cash_ViewModel cash, Cash_Items_DetailViewModel detail)
        {
            index = Cash_Items_DetailViewModel.ItemTapped.ItemIndex;

            Cash_Detail_VM = detail;
            Cash_VM = cash;

            Inicialize_SaleEdit(index);

            EditNameCommand = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new ChooseClient_Page(this));
            });

            EditProductCommand = new Command(async () => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new ChooseProduct_Page(this));
            });

            SaleConcludeEdit = new Command(async () =>
            {
                var Check = new CheckSale(NameEdit.Text,
                        ProductEdit.Text,
                        UnitEdit,
                        ValueEdit);

                int NumberCheck = Check.Verification();
                bool check = Check.AlertsVerification(NumberCheck);
                if (check)
                {
                    await EditSaleToDataBase(index);

                    await App.Current.MainPage.Navigation.PopToRootAsync(true);

                    await App.Current.MainPage.Navigation.PushAsync(new Cash_Items_DetailPage(cash), false);

                    cash.SalesListUpdate();
                }

            });
        }


        private void Inicialize_SaleEdit(int i)
        {
            var item = Cash_VM.SaleList[i];

            NameEdit.Text = item.Name;
            ProductEdit.Text = item.Product;
            ValueEdit = item.Value;
            UnitEdit = item.Unit;

        }

        public async Task<int> EditSaleToDataBase(int i)
        {
            var data = await App.SaleDatabase.Get_DB_SaleProduct_Async();
            var product = data[i];

            product.Name = NameEdit.Text;
            product.DateSale = Cash_VM.Date.Text;

            product.Product = ProductEdit.Text;
            product.Value = ValueEdit;
            product.Unit = UnitEdit;

            product.TotalValueProduct = CalculationTotal;

            await App.SaleDatabase.Update_DB_SaleProduct_Asysnc(product);

            Cash_VM.SalesListUpdate();

            return product.ID;
        }

        public void ChooseName(string name)
        {
            NameEdit.Text = name;
        }
        public void ChooseProduct(string product, decimal value)
        {
            ProductEdit.Text = product;
            ValueEdit = value;
        }
    }
}
