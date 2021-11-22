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
