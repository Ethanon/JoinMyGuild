using JoinMyGuild.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JoinMyGuild.ViewModels
{
    public class NewAccountDetailsModel : BaseViewModel
    {
        public Command SubmitNewAccountCommand { get; }

        public NewAccountDetailsModel()
        {
            SubmitNewAccountCommand = new Command(OnVerifyAndSubmit);
        }

        private async void OnVerifyAndSubmit(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
