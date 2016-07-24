using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Net.Wifi;

namespace Mandro.WIfiLocator.DataCollection.Android
{
    [Activity(Label = "Wifi Monitor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public void DisplayText(string text)
        {
            FindViewById<TextView>(Resource.Id.txtScanResults).Text = "Wifi networks: \r\n" + text;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Wifi);

            RegisterReceiver(new WifiMonitor(), new IntentFilter(WifiManager.ScanResultsAvailableAction));

            ((WifiManager)GetSystemService(WifiService)).StartScan();
        }
    }
}

