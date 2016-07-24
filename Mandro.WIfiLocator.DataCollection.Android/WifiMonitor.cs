using System;
using System.Linq;
using Android.Content;
using Android.Net.Wifi;
using System.Threading.Tasks;

namespace Mandro.WIfiLocator.DataCollection.Android
{
    public class WifiMonitor : BroadcastReceiver
    {
        public override async void OnReceive(Context context, Intent intent)
        {
            var mainActivity = (MainActivity)context;

            var wifiManager = (WifiManager)mainActivity.GetSystemService(Context.WifiService);
            mainActivity.DisplayText(string.Join("\r\n", wifiManager.ScanResults.Select(r => $"{r.Bssid} - {r.Level} dB")));

            await Task.Delay(TimeSpan.FromSeconds(1));

            wifiManager.StartScan();
        }
    }
}