using JoinMyGuild.Services;
using Xamarin.Forms;

namespace JoinMyGuild.Pages
{
    public class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// The is authentication failed
        /// </summary>
        private bool _isAuthenticationFailed;

        public Command LoginCommand { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance's authentication has failed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is authentication failed; otherwise, <c>false</c>.
        /// </value>
        public bool IsAuthenticationFailed
        {
            get => _isAuthenticationFailed;
            set
            {
                SetProperty(ref _isAuthenticationFailed, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginCommand);
        }

        /// <summary>
        /// Called when [login command].
        /// </summary>
        public void OnLoginCommand()
        {
            ApplicationState.Authentication.Login(OnAuthenticationCompleted);
        }

        /// <summary>
        /// Raises the <see cref="E:AuthenticationCompleted" /> event.
        /// </summary>
        /// <param name="authenticationResponse">The <see cref="AuthenticatedUserResponseEventArgs"/> instance containing the event data.</param>
        public void OnAuthenticationCompleted(AuthenticatedUserResponseEventArgs authenticationResponse)
        {
            if (authenticationResponse.IsAuthenticated)
            {
                IsAuthenticationFailed = false;
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                IsAuthenticationFailed = true;
            }
        }
    }
}
