using RollingBalls.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RollingBalls.Views
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