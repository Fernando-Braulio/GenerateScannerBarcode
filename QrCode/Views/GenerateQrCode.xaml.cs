using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateQrCode : ContentPage
    {
        public GenerateQrCode()
        {
            InitializeComponent();
        }

        private async void OnClickedGenerater(object sender, EventArgs e) => await GenerateScan();

        private async Task GenerateScan()
        {
            try
            {
                var BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;

                if (picker.SelectedItem == null || string.IsNullOrEmpty(picker.SelectedItem.ToString()))
                {
                    await DisplayAlert("Error", "Favor selecione um método", "OK");
                    return;
                }

                switch (picker.SelectedItem)
                {
                    case "AZTEC":
                        BarcodeFormat = ZXing.BarcodeFormat.AZTEC;
                        break;
                    case "CODE 39":
                        BarcodeFormat = ZXing.BarcodeFormat.CODE_39;
                        break;
                    case "CODE 128":
                        BarcodeFormat = ZXing.BarcodeFormat.CODE_128;
                        break;
                    case "EAN 8":
                        BarcodeFormat = ZXing.BarcodeFormat.EAN_8;
                        break;
                    case "EAN 13":
                        BarcodeFormat = ZXing.BarcodeFormat.EAN_13;
                        break;
                    case "QR CODE":
                        BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                        break;
                    default:
                        BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                        break;
                }

                QrCodeView.BarcodeFormat = BarcodeFormat;
                QrCodeView.BarcodeValue = TextEntry.Text;
                QrCodeView.IsVisible = true;
            }
            catch (Exception ex)
            {
                QrCodeView.IsVisible = false;
                await DisplayAlert("Error", ex.Message, "OK");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}