using MinhasVendas.ABC_Translate;
using MinhasVendas.Views.CompanyResources.Customers;
using MinhasVendas.Views.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.User
{
    public class User_ViewModel
    {

        public string srcImgUser { get; set; }
        public string Company_Name { get; set; }
        public string Company_Description { get; set; }

        public ICommand EditUser { get; set; }
        public ICommand EditTheme { get; set; }
        
        public ICommand StockProducts { get; set; }
        public ICommand Earnings { get; set; }
        public ICommand Customers { get; set; }

        public User_ViewModel()
        {
            InicializeUser();

            EditUser = new Command( async() =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new UserEdit_Page());
            });

            EditTheme = new Command( async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new UserEditTheme_Page());
            });

            StockProducts = new Command(/*async */() => 
            {
                //await App.Current.MainPage.Navigation.PushAsync(new StockProducts_Page());
            });

            Earnings = new Command(/*async*/ () =>
            {
                //await App.Current.MainPage.Navigation.PushAsync(new Earnings_Page());
            });

            Customers = new Command(async() => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new Customers_Page());
            });
        }

        void InicializeUser()
        {
            //Get image of MinhasVendas.Android/Resources/drawable
            srcImgUser = "User_Off.png";
            Company_Name = $"{AppResources.Name_of_my_company}";
            Company_Description = $"{AppResources.Description_of_my_company}";
        }
    }
}
