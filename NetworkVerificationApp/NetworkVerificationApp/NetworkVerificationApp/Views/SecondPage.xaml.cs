using NetworkVerificationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetworkVerificationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            var ssid = Preferences.Get("SSID", "");
            var code = Preferences.Get("Code", "");

            var currentssid = DependencyService.Get<IGetNetworkName>().GetSSID();
            var currentcode = codeEntry.Text;

            if (ssid == currentssid && code == currentcode)
                Navigation.PushAsync(new ThirdPage());
            else
                DisplayAlert("Error", "Wrong code or network", "Ok");
        }
    }
}