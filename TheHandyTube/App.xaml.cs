using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TheHandyTube.Services;
using TheHandyTube.Views;
using MediaManager;

namespace TheHandyTube
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();

            Device.SetFlags(new string[] { "MediaElement_Experimental" });

            DependencyService.Register<YouTubeSearchServie>();
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
