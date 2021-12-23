using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.ViewModels.User;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEdit_Page : ContentPage
    {
        UserEdit_ViewModel vm;
        public UserEdit_Page()
        {
            vm = new UserEdit_ViewModel(this);
            InitializeComponent();
            InitializeStringsTranslate();
            BindingContext = vm;

            StartPhotoCompany();

        }

        public async void StartPhotoCompany()
        {
            var ListCompany = await App.CompanyDataBase.Get_DB_Company_Async();

            if (ListCompany.Count == 1)
            {
                var company = ListCompany[0];
                Image.Source = ImageSource.FromFile(company.PathFile);
            } 
            else
                Image.Source = ImageSource.FromFile("User_Off.png");

        }

        public void DefinePhoto(MediaFile file)
        {
            Image.Source = ImageSource.FromFile(file.Path.ToString());
            file.Dispose();
        }


        private void InitializeStringsTranslate()
        {
            //ContenPage
            this.Title = $"{AppResources.Edit_User}";

            //Labels
            this.lbl_Name.Text = $"{AppResources.Name}";
            this.lbl_Description.Text = $"{AppResources.Description}";

            //Buttons
            this.btn_Edit_Image.Text = $"{AppResources.Edit_Image}";
            this.btn_Save_Profile.Text = $"{AppResources.Save_Profile}";

        }
    }
}