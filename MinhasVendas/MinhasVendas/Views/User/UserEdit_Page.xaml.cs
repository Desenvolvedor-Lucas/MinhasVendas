using MinhasVendas.ViewModels.User;
using System;
using System.Collections.Generic;
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
            vm = new UserEdit_ViewModel();
            InitializeComponent();
            BindingContext = vm;
        }
    }
}