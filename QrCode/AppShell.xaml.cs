using QrCode.ViewModels;
using QrCode.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QrCode
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            Routing.RegisterRoute(nameof(ReadQrCode), typeof(ReadQrCode));
            Routing.RegisterRoute(nameof(GenerateQrCode), typeof(GenerateQrCode));
        }

    }
}
