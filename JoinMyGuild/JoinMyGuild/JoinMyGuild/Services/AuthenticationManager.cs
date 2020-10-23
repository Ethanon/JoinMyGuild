using JoinMyGuild.Pages;
using System;
using Xamarin.Forms;

namespace JoinMyGuild.Services
{
    /// <summary>
    /// Authentication manager for the application and managing a users session
    /// </summary>
    public class AuthenticationManager
    {
        private IAuthenticationSource _authenticationSource;
        private Action<AuthenticatedUserResponseEventArgs> _loginCompletedCallback;
        private volatile bool _isLoggingIn = false;

        public AuthenticationManager()
        {
        }

        public bool VerifySession()
        {
            return true;
        }

        /// <summary>
        /// Logins the specified on login completed callback.
        /// </summary>
        /// <param name="onLoginCompletedCallback">The on login completed callback.</param>
        public void Login(Action<AuthenticatedUserResponseEventArgs> onLoginCompletedCallback)
        {
            if (!_isLoggingIn || !VerifySession())
            {
                _isLoggingIn = true;
                _loginCompletedCallback = onLoginCompletedCallback;
                if (_authenticationSource != null)
                {
                    _authenticationSource.OnAuthenticationCompleted -= OnAuthenticationCompelted;
                }

                _authenticationSource = AuthenticationFactory.GetAuthenticationSource(AuthenticationType.Facebook);
                _authenticationSource.OnAuthenticationCompleted += OnAuthenticationCompelted;
                _authenticationSource.Login();
            }
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            Application.Current.MainPage = new Login();
        }

        /// <summary>
        /// Called when [authentication compelted].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AuthenticatedUserResponseEventArgs"/> instance containing the event data.</param>
        private void OnAuthenticationCompelted(object sender, AuthenticatedUserResponseEventArgs e)
        {
            _authenticationSource.OnAuthenticationCompleted -= OnAuthenticationCompelted;

            // manage user session and idle time

            _loginCompletedCallback?.Invoke(e);
        }
    }
}
