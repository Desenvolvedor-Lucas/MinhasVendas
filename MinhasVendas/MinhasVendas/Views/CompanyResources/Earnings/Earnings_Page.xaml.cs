using MinhasVendas.ViewModels.User.CompanyResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinhasVendas.Views.User.CompanyResources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Earnings_Page : ContentPage
    {
        Earnings_ViewModel vm;
        public Earnings_Page()
        {
            vm = new Earnings_ViewModel();
            InitializeComponent();
            BindingContext = vm;
        }
    }
}