using EncounterMe;
using MapApp.Notification;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            User user = ((App)App.Current).UserManager.Authenticate(Username.Text, Password.Text);
            //User user = users.FirstOrDefault(u => u.Name == Username.Text && u.CompareHashPassword(Password.Text));
            if (user == null)
            {
                //await Navigation.PushPopupAsync(new NotificationWin(0));
                await DisplayAlert("Error", "Incorrect username or password", "OK");
            } else
            {
                ((App)App.Current).user = user;
                Application.Current.Properties["username"] = user.Name;
                Application.Current.Properties["password"] = Password.Text;
                Application.Current.MainPage = main;
            }
        }
    }
}