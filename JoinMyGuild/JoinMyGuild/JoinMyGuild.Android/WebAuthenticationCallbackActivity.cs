using Android.App;
using Android.Content;
using Android.Content.PM;

namespace JoinMyGuild.Droid
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
        Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
        DataScheme = WebAuthenticationCallbackActivity.CALLBACK_SCHEME)]
    public class WebAuthenticationCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
        private const string CALLBACK_SCHEME = "JoinMyGuild";
    }
}