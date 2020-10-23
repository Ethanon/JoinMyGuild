using System;
using Xamarin.Forms;

namespace JoinMyGuild.Services
{
    public class AuthenticatedUserResponseEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticatedUserResponseEventArgs"/> class.
        /// </summary>
        /// <param name="isAuthentication">if set to <c>true</c> [is authentication].</param>
        public AuthenticatedUserResponseEventArgs(bool isAuthentication)
        {
            IsAuthenticated = isAuthentication;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        public bool IsAuthenticated { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        /// <value>
        /// The profile image.
        /// </value>
        public Image ProfileImage { get; set; }
    }
}
