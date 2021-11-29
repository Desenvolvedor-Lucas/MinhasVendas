using MinhasVendas.DataBase;
using MinhasVendas.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas
{
    public partial class App : Application
    {
        //Banco de dados das vendas
        static SaleDataBase saledatabase;
        public static SaleDataBase SaleDatabase
        {
            get
            {
                if (saledatabase == null)
                {
                    saledatabase = new SaleDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "SalesData.db3"));
                }
                return saledatabase;
            }
        }

        //Banco de dados dos clientes
        static CustomersDataBase customersdatabase;
        public static CustomersDataBase CustomersDataBase
        {
            get
            {
                if (customersdatabase == null)
                {
                    customersdatabase = new CustomersDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "CustomersData.db3"));
                }
                return customersdatabase;
            }
        }

        //Banco de dados dos produtos
        static ProductsDataBase productsdatabase;
        public static ProductsDataBase ProductsDataBase
        {
            get
            {
                if (productsdatabase == null)
                {
                    productsdatabase = new ProductsDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "ProductsData.db3"));
                }
                return productsdatabase;
            }
        }

        //Acho que o básico, essencial do (cash) já foi, agora começar a ver o (notes ou user)
        public App()
        {
            InitializeComponent();

            ThemeManager.LoadTheme();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
