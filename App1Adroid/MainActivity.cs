using Android.App;
using Android.Widget;
using Android.OS;

namespace App1Adroid
{
    [Activity(Label = "App1Adroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var button = FindViewById<Button>(Resource.Id.button1);
            button.Click += delegate
            {
                button.Text = string.Format("这是第{0} 单击!", count++);
            };
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

        }
    }
}

