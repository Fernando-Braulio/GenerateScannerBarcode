using QrCode.Views;
using Xamarin.Forms;

namespace QrCode
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(ReadQrCode), typeof(ReadQrCode));
            Routing.RegisterRoute(nameof(GenerateQrCode), typeof(GenerateQrCode));
        }

    }
}
