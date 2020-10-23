
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JoinMyGuild.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Guilds : ContentPage
    {
        public Guilds()
        {
            InitializeComponent();
            BindingContext = new GuildsViewModel();
        }
    }
}