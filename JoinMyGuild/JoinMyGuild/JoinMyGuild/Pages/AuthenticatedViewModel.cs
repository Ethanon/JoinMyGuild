using Xamarin.Forms;

namespace JoinMyGuild.Pages
{
    public class AuthenticatedViewModel : ViewModelBase
    {
        public AuthenticatedViewModel()
        {
            if (!ApplicationState.Authentication.VerifySession())
            {
                ApplicationState.Authentication.Logout();
            }
        }
    }
}
