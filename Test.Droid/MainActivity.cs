using Android.App;
using Android.Widget;
using Android.OS;

namespace Test.Droid
{
    [Activity(Label = "Test.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private FragmentManager fragmentManager;
        private fragmentClasses.registrationFragment reg;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            reg = new fragmentClasses.registrationFragment();

            reg.Show(fragmentManager, "fragmentManager");
            SetContentView(Resource.Layout.Main);
        }
    }
}

