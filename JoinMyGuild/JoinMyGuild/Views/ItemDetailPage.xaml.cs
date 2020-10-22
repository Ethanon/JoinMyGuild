using System.ComponentModel;
using Xamarin.Forms;
using JoinMyGuild.ViewModels;

namespace JoinMyGuild.Views
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