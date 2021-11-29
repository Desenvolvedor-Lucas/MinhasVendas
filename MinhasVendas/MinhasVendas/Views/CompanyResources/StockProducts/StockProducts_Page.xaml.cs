using MinhasVendas.ABC_Translate;
using MinhasVendas.ViewModels.CompanyResources.StockProducts;
using MinhasVendas.ViewModels.User.CompanyResources;
using MinhasVendas.Views.CompanyResources.StockProducts;
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
            InitializeStringsTranslate();
            BindingContext = vm;
        }

        //INotifyPropertyChanged

        //continuar a arrumar a parte de produtos pra ficar certinho, ok
        //tambem dar uma arrumada no cliente
        //corrigir bugs e melhorar o app que já tenho :), ok contiuar mais;)
        //só depois fazer coisas novas no app tipo a segunda pagina da venda entre muitas outras coisas!

        private void InitializeStringsTranslate()
        {
            //ContentPage
            this.Title = $"{AppResources.Stock_of_products}";

            //Buttons
            this.btn_NewProduct.Text = $"{AppResources.New_Product}";
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = await App.ProductsDataBase.Get_DB_Product_Async();
            Models.Product product = list[e.ItemIndex];
            await Navigation.PushAsync(new Products_DetailPage(product));
        }

    }
}