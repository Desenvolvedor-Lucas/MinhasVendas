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

        //Banco de dados da empresa
        static CompanyDataBase companydatabase;
        public static CompanyDataBase CompanyDataBase
        {
            get
            {
                if (companydatabase == null)
                {
                    companydatabase = new CompanyDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "CompanyData.db3"));
                }
                return companydatabase;
            }
        }

        //continuar a fazer o EditUser, imagem, banco de dados, nome e descrição. essas coisas
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
