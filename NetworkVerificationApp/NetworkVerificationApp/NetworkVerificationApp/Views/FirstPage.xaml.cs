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
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var ssid = DependencyService.Get<IGetNetworkName>().GetSSID();
            netwrokLabel.Text = ssid;

            Preferences.Set("SSID", ssid);
            Preferences.Set("Code", codeLabel.Text);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }
    }
}