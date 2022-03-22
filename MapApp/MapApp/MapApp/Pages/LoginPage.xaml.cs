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
        private MainPage main;
        private List<User> users = new List<User>();
        public LoginPage(MainPage mainPage)
        {
            InitializeComponent();
            main = mainPage;

            users.Add(new User("Hamster", "mrhamster@gmail.com", "ilovehamsters"));
            users[0].LevelPoints = 8520;
            users[0].AchievementNum = 10;
            users[0].FoundLocationNum = 23;

            users.Add(new User("Camster", "mrcamster@gmail.com", "ilovehamsters"));
            users[1].LevelPoints = 8520;
            users[1].AchievementNum = 10;
            users[1].FoundLocationNum = 23;

        }
        async void Login(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MainPage());
            User user = users.FirstOrDefault(u => u.Name == Username.Text && u.CompareHashPassword(Password.Text));
            if (user == null)
            {
                await Navigation.PushPopupAsync(new NotificationWin(0));
            } else
            {
                main.user = user;
                await Navigation.PopAsync();
            }
        }
    }
}