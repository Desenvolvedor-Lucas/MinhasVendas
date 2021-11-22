using MinhasVendas.ViewModels;
using MinhasVendas.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MinhasVendas
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(Menu_FlyoutPage), typeof(Menu_FlyoutPage));
            //Routing.RegisterRoute(nameof(Menu_FlyoutPageDetail), typeof(Menu_FlyoutPageDetail));
        }

    }
}
