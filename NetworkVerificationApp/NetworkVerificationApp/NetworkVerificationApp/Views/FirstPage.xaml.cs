using NetworkVerificationApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Codes> Codes { get; set; }
        public FirstPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var code = GetCode();
            codeLabel.Text = code.name;

            var ssid = DependencyService.Get<IGetNetworkName>().GetSSID();
            netwrokLabel.Text = ssid;

            Preferences.Set("SSID", ssid);
            Preferences.Set("Code", codeLabel.Text);
        }

        private Codes GetCode()
        {
            var assembly = typeof(FirstPage).Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                if (res.Contains("code.json"))
                {
                    Stream stream = assembly.GetManifestResourceStream(res);
                    using (var reader = new StreamReader(stream))
                    {
                        var jsonData = reader.ReadToEnd();
                        Codes = JsonConvert.DeserializeObject<List<Codes>>(jsonData);
                        //CountryName = CodeList.Select(x => x.name).ToList();
                    }
                }
            }
            return Codes.FirstOrDefault();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }
    }

    public class Codes
    {
        public string name { get; set; }
    }
}