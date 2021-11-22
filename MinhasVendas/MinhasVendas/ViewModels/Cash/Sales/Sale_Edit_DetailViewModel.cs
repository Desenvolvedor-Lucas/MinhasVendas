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

namespace MinhasVendas.ViewModels.Cash.Sales
{
    public class Sale_Edit_DetailViewModel
    {
        int index;

        public Cash_Items_DetailViewModel Cash_Detail_VM { get; set; }
        public Label TotalValueEdit { get; set; } = new Label();
        public Cash_ViewModel Cash_VM { get; set; }

        public Label NameEdit { get; set; } = new Label();
        public string ProductEdit { get; set; }
        

        private string _value;
        public string ValueEdit
        {
            get { return _value; }
            set 
            { 
                _value = value;
                if (!string.IsNullOrEmpty(UnitEdit) && !string.IsNullOrEmpty(ValueEdit))
                    CalculationTotal = int.Parse(UnitEdit) * decimal.Parse(ValueEdit);
                else
                    CalculationTotal = 0;
            }
        }

        private string _unit;
        public string UnitEdit
        {
            get { return _unit; }
            set 
            { 
                _unit = value;
                if (!string.IsNullOrEmpty(UnitEdit) && !string.IsNullOrEmpty(ValueEdit))
                    CalculationTotal = int.Parse(UnitEdit) * decimal.Parse(ValueEdit);
                else
                    CalculationTotal = 0;
            }
        }

        decimal _calculationTotal;
        decimal CalculationTotal
        {
            get { return _calculationTotal; }
            set { _calculationTotal = value; TotalValueEdit.Text = $"{CalculationTotal.ToString("C")}"; }
        }

        public ICommand EditNameCommand { get; set; }
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

            SaleConcludeEdit = new Command(async () =>
            {
                var Check = new CheckSale(NameEdit.Text,
                        ProductEdit,
                        int.Parse(UnitEdit),
                        decimal.Parse(ValueEdit));

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
            ProductEdit = item.Product;
            ValueEdit = item.Value.ToString();
            UnitEdit = item.Unit.ToString();

        }

        public async Task<int> EditSaleToDataBase(int i)
        {
            var data = await App.SaleDatabase.Get_DB_SaleProduct_Async();
            var product = data[i];

            product.Name = NameEdit.Text;
            product.DateSale = Cash_VM.Date.Text;

            product.Product = ProductEdit;
            product.Value = decimal.Parse(ValueEdit);
            product.Unit = int.Parse(UnitEdit);

            product.TotalValueProduct = CalculationTotal;

            await App.SaleDatabase.Update_DB_SaleProduct_Asysnc(product);

            Cash_VM.SalesListUpdate();

            return product.ID;
        }

        public void ChooseName(string name)
        {
            NameEdit.Text = name;
        }
    }
}
