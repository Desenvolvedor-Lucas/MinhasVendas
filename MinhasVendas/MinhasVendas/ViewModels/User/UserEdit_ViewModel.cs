using MinhasVendas.ABC_Translate;
using MinhasVendas.Models;
using MinhasVendas.Views.User;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MinhasVendas.ViewModels.User
{
    public class UserEdit_ViewModel
    {
        public UserEdit_Page MyPage { get; set; }

        string path;

        public Label Name { get; set; } = new Label();
        public Label Description { get; set; } = new Label();


        public ICommand EditPhoto { get; set; }
        public ICommand SaveProfileCommand { get; set; }

        public UserEdit_ViewModel()
        {
            InicializeUserEdit();
            DefineCommand();
        }

        public UserEdit_ViewModel(UserEdit_Page page)
        {
            MyPage = page;

            InicializeUserEdit();
            DefineCommand();
        }

        public async void InicializeUserEdit()
        {
            var list = await App.CompanyDataBase.Get_DB_Company_Async();
            if(list.Count == 1)
            {
                var company = list[0];
                Name.Text = company.CompanyName;
                Description.Text = company.CompanyDescription;
            }
            else
            {
                Name.Text = $"{AppResources.Name_of_my_company}";
                Description.Text = $"{AppResources.Description_of_my_company}";
            }
            
        }

        private void DefineCommand()
        {
            EditPhoto = new Command(async () =>
            {
                var IsCamera = await App.Current.MainPage.DisplayAlert(
                    $"{AppResources.Edit_Photo}",
                    $"{AppResources.Choose_the_way_you_want_to_change_the_photo}", 
                    $"{AppResources.camera}", 
                    $"{AppResources.gallery}");
                if (IsCamera)
                    TakePicture();
                else
                    SelectPhoto();
            });

            SaveProfileCommand = new Command(async () =>
            {
                AddCompanyDB(path);

                await App.Current.MainPage.Navigation.PopAsync();
            });
        }


        public async void TakePicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
            {
                await App.Current.MainPage.DisplayAlert(
                    $"{AppResources.Oops}", 
                    $"{AppResources.No_camera_detected}!", 
                    $"{AppResources.Ok}");

                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Company"
                });

            if (file == null)
                return;

            path = file.Path;

            MyPage.DefinePhoto(file);
        }

        public async void AddCompanyDB(string Path)
        {
            var ListCompany = await App.CompanyDataBase.Get_DB_Company_Async();

            if (string.IsNullOrEmpty(Path))
                if (ListCompany.Count == 1)
                {
                    var item = ListCompany[0];
                    Path = item.PathFile;
                }
                else
                    Path = "User_Off.png";
                

            var company = new Company()
            {
                ID = 1,
                CompanyName = Name.Text,
                CompanyDescription = Description.Text,
                PathFile = Path
            };

            if (ListCompany.Count < 1)
                await App.CompanyDataBase.Salve_Company_Async(company);
            else if (ListCompany.Count == 1)
                await App.CompanyDataBase.Update_Company_Async(company);

            UserConfig.DefineAsync();
            
        }

        public async void SelectPhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert(
                    $"{AppResources.Oops}", 
                    $"{AppResources.Photo_gallery_not_supported}!", 
                    $"{AppResources.Ok}");

                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;


            path = file.Path;

            MyPage.DefinePhoto(file);
        }
    }
}
