using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NetworkVerificationApp.Droid;
using NetworkVerificationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetSSIDAndroid))]
namespace NetworkVerificationApp.Droid
{
    public class GetSSIDAndroid : IGetNetworkName
    {
        public string GetSSID()
        {
            WifiManager wifiManager = (WifiManager)(Android.App.Application.Context.GetSystemService(Context.WifiService));

            if (wifiManager != null && !string.IsNullOrEmpty(wifiManager.ConnectionInfo.SSID))
            {
                return wifiManager.ConnectionInfo.SSID;
            }
            else
            {
                return "WiFiManager is NULL";
            }
        }
    }
}