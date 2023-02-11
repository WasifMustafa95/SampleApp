using Foundation;
using NetworkVerificationApp.Interfaces;
using NetworkVerificationApp.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemConfiguration;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetSSIDiOS))]
namespace NetworkVerificationApp.iOS
{
    public class GetSSIDiOS : IGetNetworkName
    {
        string ssid;
        public string GetSSID()
        {
            if (CaptiveNetwork.TryGetSupportedInterfaces(out string[] supportedInterfaces) == StatusCode.OK)
            {
                foreach (var item in supportedInterfaces)
                {
                    if (CaptiveNetwork.TryCopyCurrentNetworkInfo(item, out NSDictionary info) == StatusCode.OK)
                    {
                        ssid = info[CaptiveNetwork.NetworkInfoKeySSID].ToString();
                    }
                }
            }

            return ssid;
        }
    }
}