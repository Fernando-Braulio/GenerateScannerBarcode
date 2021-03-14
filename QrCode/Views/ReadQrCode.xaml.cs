using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadQrCode : ContentPage
    {
        public ReadQrCode()
        {
            InitializeComponent();
        }

        private async void OnClickedScanner(object sender, EventArgs e) => await OpenScan();

        private async Task OpenScan()
        {
            var openNavegator = false;
            var result = string.Empty;
            try
            {
                var scanner = DependencyService.Get<Services.IQrCodeScanningService>();
                result = await scanner.ScanAsync();
                if (!string.IsNullOrEmpty(result))
                {
                    openNavegator = await DisplayAlert("Deseja abrir texto lido no navegador?", result, "Sim", "Não");

                    if (openNavegator)
                        await Browser.OpenAsync(result, BrowserLaunchMode.SystemPreferred);
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;

                if (openNavegator)
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        var textoPesquisar = $"https://www.google.com/search?q={result}";
                        await Browser.OpenAsync(textoPesquisar, BrowserLaunchMode.SystemPreferred);
                    }
                }
            }
        }
    }
}