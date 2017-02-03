using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using Android.Content;

namespace Test.Droid
{
    [Activity(Label = "Test.Droid", MainLauncher = true, Theme = "@android:style/Theme.Black.NoTitleBar", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private FragmentManager fragmentManager;
        private fragmentClasses.registrationFragment reg;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            //Initializing fragment manager for registration
            fragmentManager = this.FragmentManager;
            reg = new fragmentClasses.registrationFragment();
            //Initializing fragment manager for registration ENDED

            SetContentView(Resource.Layout.Main);

            var registerBn = FindViewById<Button>(Resource.Id.registerBn);
            var loginBn = FindViewById<Button>(Resource.Id.loginBn);

            registerBn.Click += MainActivity_Click;
            loginBn.Click += LoginBn_Click;
        }

        private void LoginBn_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(videoRecord)));
        }

        private void MainActivity_Click(object sender, EventArgs e)
        {
            reg.Show(fragmentManager, "fragmentManager");
        }
    }
}

