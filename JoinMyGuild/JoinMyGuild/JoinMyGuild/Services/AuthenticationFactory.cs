using JoinMyGuild.Services.AuthenticationSources;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoinMyGuild.Services
{
    public static class AuthenticationFactory
    {
        /// <summary>
        /// Gets the authentication source based on the authentication type
        /// </summary>
        /// <param name="authenticationType">authentication type</param>
        public static IAuthenticationSource GetAuthenticationSource(AuthenticationType authenticationType)
        {
            switch(authenticationType)
            {
                case AuthenticationType.Facebook :
                    return new FacebookAuthenticationSource();
            }

            return null;
        }
    }
}
