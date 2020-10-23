using JoinMyGuild.Utilities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xamarin.Auth;

namespace JoinMyGuild.Services.AuthenticationSources
{
    /// <summary>
    /// Facebook authenication source, used to authenticate users based on facebook accounts
    /// </summary>
    /// <seealso cref="JoinMyGuild.Services.AuthenticationSources.AuthenticationSourceBase" />
    public class FacebookAuthenticationSource : AuthenticationSourceBase
    {
        /// <summary>
        /// Facebook Authentication Source
        /// </summary>
        public FacebookAuthenticationSource()
        {
            ClientId = "2829963783901536";
            Scope = "email";
            RedirectUri = new Uri("https://www.facebook.com/connect/login_success.html");
            AuthorizationUri = new Uri("https://www.facebook.com/dialog/oauth/");
            AccessTokenUrl = "https://www.facebook.com/connect/login_success.html";
            UserInfoUrl = "https://graph.facebook.com/me?fields=id,email,name,picture&access_token={0}";
        }

        /// <summary>
        /// Facebook on authentication completed callback handler
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">authentication copmpleted event args</param>
        protected override async void OnAuthenticationCompletedCallback(object sender, AuthenticatorCompletedEventArgs e)
        {
            var response = new AuthenticatedUserResponseEventArgs(false);
            if (e.IsAuthenticated)
            {
                try
                {
                    // inspect access token and verify permissions were granted
                    var accessToken = e.Account.Properties["access_token"];

                    // store access token for session management

                    HttpClient client = new HttpClient();
                    var userProfileReponse = await client.GetStringAsync(UserInfoUrl.Format(accessToken));
                    var userProfile = JsonConvert.DeserializeObject<FacebookProfile>(userProfileReponse);

                    response.IsAuthenticated = true;
                    response.UserId = userProfile.Id;
                    response.Email = userProfile.Email;
                    response.Name = userProfile.Name;
                    response.ProfileImage = new Xamarin.Forms.Image() { Source = new Uri(userProfile.Picture.Data.Url) };
                }
                catch (Exception)
                {
                    response.IsAuthenticated = false;
                }
            }

            NotifyOnCompletedEvent(response);
        }

        /// <summary>
        /// Class used to deserialize Facebook JSON profile
        /// </summary>
        public class FacebookProfile
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public Picture Picture { get; set; }
            public string Email { get; set; }
        }

        /// <summary>
        /// Class used to deserialize Facebook JSON picture
        /// </summary>
        public class Picture
        {
            public Data Data { get; set; }
        }

        /// <summary>
        /// Class used to deserialize Facebook JSON picture data
        /// </summary>
        public class Data
        {
            public bool IsSilhouette { get; set; }
            public string Url { get; set; }
        }
    }
}
