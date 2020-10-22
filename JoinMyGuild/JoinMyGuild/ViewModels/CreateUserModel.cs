using JoinMyGuild.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JoinMyGuild.ViewModels
{
    public class CreateUserModel : BaseViewModel
    {
        private string _userName;
        private string _emailAddress;
        private string _password;
        private string _confirmedPassword;
        
        public Command SubmitNewAccountCommand { get; }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmedPassword
        {
            get => _confirmedPassword;
            set
            {
                _confirmedPassword = value;
                OnPropertyChanged();
            }
        }

        public CreateUserModel()
        {
            SubmitNewAccountCommand = new Command(OnVerifyAndSubmit);
        }

        private async void OnVerifyAndSubmit(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewAccountDetailsPage));
        }
    }
}
