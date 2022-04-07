using EncounterMe;
using EncounterMe.Functions;
using MapApp.Pages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapApp
{
    public partial class App : Application
    {
        public UserManager UserManager { get; set; }

        public Page main = new NavigationPage(new MainPage());
        public User user { get; set; }
        public App()
        {
            InitializeComponent();
            UserManager = new UserManager(new HttpClient() { BaseAddress = new Uri("http://10.0.2.2:32332") }); ;
            //MainPage = new NavigationPage(new MainPage());

        }



        protected override void OnStart()
        {
            using (HttpClient client = new HttpClient())
            {
                if (Current.Properties.ContainsKey("token"))
                { 
                    user = UserManager.CurrentUser(Current.Properties["token"].ToString());
                }
                if (user == null)
                {
                    Application.Current.MainPage = new LoginPage();
                }
                else
                {
                    Application.Current.MainPage = main;
                }
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
