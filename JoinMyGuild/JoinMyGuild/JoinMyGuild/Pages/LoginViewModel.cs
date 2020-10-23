using JoinMyGuild.Services;
using Xamarin.Forms;

namespace JoinMyGuild.Pages
{
    public class LoginViewModel : ViewModelBase
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginCommand);
        }

        public void OnLoginCommand()
        {
            ApplicationState.Authentication.Login(OnAuthenticationCompleted);
        }

        public void OnAuthenticationCompleted(AuthenticatedUserResponseEventArgs authenticationResponse)
        {
            if (authenticationResponse.IsAuthenticated)
            {
                // navigate to next login screen
            }
            else
            {
                // notify user of failure to login and stay on login screen
            }
        }
    }
}
