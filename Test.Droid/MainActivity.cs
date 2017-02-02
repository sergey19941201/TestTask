using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Test.Droid
{
    [Activity(Label = "Test.Droid", MainLauncher = true, Theme = "@android:style/Theme.Black.NoTitleBar", Icon = "@drawable/icon")]
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

            var registerBN = FindViewById<Button>(Resource.Id.registerBN);
            registerBN.Click += MainActivity_Click;
        }

        private void MainActivity_Click(object sender, EventArgs e)
        {
            reg.Show(fragmentManager, "fragmentManager");
        }
    }
}

