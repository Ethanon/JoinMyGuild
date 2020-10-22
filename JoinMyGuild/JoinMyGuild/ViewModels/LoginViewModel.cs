﻿using JoinMyGuild.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JoinMyGuild.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public Command NewAccountCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            NewAccountCommand = new Command(OnNewAccountClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnNewAccountClicked(object obj)
        {            
            await Shell.Current.GoToAsync(nameof(CreateUserPage));
        }
    }
}
