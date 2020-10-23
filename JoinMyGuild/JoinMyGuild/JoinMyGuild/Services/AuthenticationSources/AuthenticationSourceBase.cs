using System;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;

namespace JoinMyGuild.Services.AuthenticationSources
{
    /// <summary>
    /// base class for OAuth authentication in XAMARIN
    /// </summary>
    /// <seealso cref="JoinMyGuild.Services.IAuthenticationSource" />
    public abstract class AuthenticationSourceBase : IAuthenticationSource
    {
        /// <summary>
        /// The authenticator
        /// </summary>
        private OAuth2Authenticator _authenticator;

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
        public string Scope { get; set; }
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        /// <value>
        /// The redirect URI.
        /// </value>
        public Uri RedirectUri { get; set; }
        /// <summary>
        /// Gets or sets the authorization URI.
        /// </summary>
        /// <value>
        /// The authorization URI.
        /// </value>
        public Uri AuthorizationUri { get; set; }
        /// <summary>
        /// Gets or sets the access token URL.
        /// </summary>
        /// <value>
        /// The access token URL.
        /// </value>
        public string AccessTokenUrl { get; set; }
        /// <summary>
        /// Gets or sets the user information URL.
        /// </summary>
        /// <value>
        /// The user information URL.
        /// </value>
        public string UserInfoUrl { get; set; }

        /// <summary>
        /// Occurs when [on authentication completed].
        /// </summary>
        public event EventHandler<AuthenticatedUserResponseEventArgs> OnAuthenticationCompleted;

        /// <summary>
        /// Logins this instance.
        /// </summary>
        public void Login()
        {
            try
            {
                _authenticator = new OAuth2Authenticator(ClientId, Scope, AuthorizationUri, RedirectUri);
                _authenticator.Completed += OnAuthenticationCompletedCallback;
                var presenter = new OAuthLoginPresenter();
                presenter.Login(_authenticator);
            }
            catch (Exception)
            {
                _authenticator.Completed -= OnAuthenticationCompletedCallback;
                NotifyOnCompletedEvent(new AuthenticatedUserResponseEventArgs(false));
            }
        }

        /// <summary>
        /// Called when [authentication completed callback].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AuthenticatorCompletedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnAuthenticationCompletedCallback(object sender, AuthenticatorCompletedEventArgs e)
        {
            NotifyOnCompletedEvent(new AuthenticatedUserResponseEventArgs(false));
        }

        /// <summary>
        /// Notifies the on completed event.
        /// </summary>
        /// <param name="authenticatedUserResponse">The <see cref="AuthenticatedUserResponseEventArgs"/> instance containing the event data.</param>
        protected void NotifyOnCompletedEvent(AuthenticatedUserResponseEventArgs authenticatedUserResponse)
        {
            _authenticator.Completed -= OnAuthenticationCompletedCallback;
            OnAuthenticationCompleted?.Invoke(this, authenticatedUserResponse);
        }
    }
}
