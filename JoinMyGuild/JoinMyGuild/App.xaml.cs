using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JoinMyGuild.Services;
using JoinMyGuild.Views;

namespace JoinMyGuild
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            Device.SetFlags(new string[] { "RadioButton_Experimental" });
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
