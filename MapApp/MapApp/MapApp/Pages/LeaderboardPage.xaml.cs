using System;
using System.Collections.Generic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EncounterMe;
using MapApp.Pages;
using System.Xml.Serialization;

namespace MapApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardPage : ContentPage
    {
        public LeaderboardPage()
        {
            InitializeComponent();
        }

        async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}