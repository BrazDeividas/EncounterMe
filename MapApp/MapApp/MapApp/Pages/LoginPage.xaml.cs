using EncounterMe;
using MapApp.Notification;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private Page main;
        public LoginPage()
        {
            InitializeComponent();
            main = ((App)App.Current).main;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void Login(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MainPage());
            var user = await ((App)App.Current).UserManager.Authenticate(new Credentials(Username.Text, Password.Text));
            if (user != null) 
            {
                ((App)App.Current).user = user;
                Application.Current.Properties["token"] = user.Token;
                Application.Current.MainPage = main;
            }
            else
            {
                await DisplayAlert("Error", "Incorrect username or password", "OK");
            }
        }
    }
}