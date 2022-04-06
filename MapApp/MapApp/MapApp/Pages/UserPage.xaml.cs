using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EncounterMe;
using MapApp.Pages;

namespace MapApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private User user = ((App)App.Current).user;
        public UserPage()
        {
            InitializeComponent();
            username.Text = user.Name;
            
            int levelNum;
            float perc;
            user.CalculateLevel(out levelNum, out perc);
            level.Text = "level " + levelNum.ToString();
            levelMeter.Progress = perc;

            locationsFound.Text = user.FoundLocationNum.ToString();
            achievements.Text = user.AchievementNum.ToString();
        }
        async void GoBack(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MainPage());
            await Navigation.PopAsync();
        }

        async void LogOut(object sender, EventArgs e)
        {
            Application.Current.Properties.Remove("token");
            await Navigation.PopAsync();
            Application.Current.MainPage = new LoginPage();
        }
    }

}
	