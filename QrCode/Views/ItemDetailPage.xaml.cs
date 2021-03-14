using QrCode.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace QrCode.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}