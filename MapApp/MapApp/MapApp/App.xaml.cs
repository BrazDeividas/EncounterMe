using EncounterMe;
using EncounterMe.Functions;
using MapApp.Pages;
using System;
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
            UserManager = new UserManager();
            //MainPage = new NavigationPage(new MainPage());

        }



        protected override void OnStart()
        {
            if (Properties.ContainsKey("username") && Properties.ContainsKey("password"))
            {
                user = UserManager.Authenticate(Properties["username"].ToString(), Properties["password"].ToString());
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

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
