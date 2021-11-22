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
    public partial class StockProducts_Page : ContentPage
    {
        StockProducts_ViewModel vm;
        public StockProducts_Page()
        {
            vm = new StockProducts_ViewModel();
            InitializeComponent();
            BindingContext = vm;
        }
    }
}