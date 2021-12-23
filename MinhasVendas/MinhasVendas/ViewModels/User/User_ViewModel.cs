using MinhasVendas.ABC_Translate;
using MinhasVendas.Views.CompanyResources.Customers;
using MinhasVendas.Views.User;
using MinhasVendas.Views.User.CompanyResources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.User
{
    public class User_ViewModel
    {
        public Label srcImgUser { get; set; } = new Label();
        public Label Company_Name { get; set; } = new Label();
        public Label Company_Description { get; set; } = new Label();

        public ICommand EditUser { get; set; }
        public ICommand EditTheme { get; set; }
        
        public ICommand StockProducts { get; set; }
        public ICommand Earnings { get; set; }
        public ICommand Customers { get; set; }

        public User_ViewModel()
        {
            var Inicialize = new UserConfig(this);
            UserConfig.DefineAsync();

            EditUser = new Command( async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new UserEdit_Page());
            });

            EditTheme = new Command( async () => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new UserEditTheme_Page());
            });

            StockProducts = new Command( async () => 
            {
                await App.Current.MainPage.Navigation.PushAsync(new StockProducts_Page());
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


        public void DefineUser(string path, string name, string description)
        {
            srcImgUser.Text = path;
            Company_Name.Text = name;
            Company_Description.Text = description;
        }

    }

    public class UserConfig 
    {
        static User_ViewModel User_vm;
        public static Label LocalImage { get; set; } = new Label();
        public static Label Name { get; set; } = new Label();
        public static Label Description { get; set; } = new Label();

        public UserConfig(User_ViewModel VM)
        {
            User_vm = VM;
        }

        public async static void DefineAsync()
        {
            var list = await App.CompanyDataBase.Get_DB_Company_Async();
            if (list.Count == 1)
            {
                var company = list[0];
                LocalImage.Text = company.PathFile;
                Name.Text = company.CompanyName;
                Description.Text = company.CompanyDescription;
            }
            else
            {
                LocalImage.Text = "User_Off.png";
                Name.Text = $"{AppResources.Name_of_my_company}";
                Description.Text = $"{AppResources.Description_of_my_company}";
            }

            User_vm.DefineUser(LocalImage.Text, Name.Text, Description.Text);
        }
    }

}
