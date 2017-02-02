using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Test.Droid.fragmentClasses
{
    class registrationFragment : DialogFragment
    {
        private EditText eng1_ET, eng2_ET, eng3_ET;
        private EditText rusEdText;
        private Button dobavitBn, zakritFragmentbn;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.registrationFragment, container, false);

            dobavitBn = rootView.FindViewById<Button>(Resource.Id.dobavitBn);
            zakritFragmentbn = rootView.FindViewById<Button>(Resource.Id.zakritFragmentBn);

            eng1_ET = rootView.FindViewById<EditText>(Resource.Id.eng1_ET);
            eng2_ET = rootView.FindViewById<EditText>(Resource.Id.eng2_ET);
            eng3_ET = rootView.FindViewById<EditText>(Resource.Id.eng3_ET);
            rusEdText = rootView.FindViewById<EditText>(Resource.Id.rusEditText);

            dobavitBn.Click += DobavitBn_Click;
            zakritFragmentbn.Click += ZakritFragmentbn_Click;

            return rootView;
        }

        private void ZakritFragmentbn_Click(object sender, EventArgs e)
        {
            Dismiss();
        }

        private void DobavitBn_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(eng1_ET.Text) || String.IsNullOrEmpty(eng2_ET.Text) || String.IsNullOrEmpty(eng3_ET.Text) || String.IsNullOrEmpty(rusEdText.Text))
            {
                Toast.MakeText(this.Activity, "Çàïîëíèòå âñå ïîëÿ", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this.Activity, "Êàðòà äîáàâëåíà", ToastLength.Short).Show();

                //Clearing EditTexts:
                eng1_ET.Text = null;
                eng2_ET.Text = null;
                eng3_ET.Text = null;
                rusEdText.Text = null;

                Dismiss();
            }
        }
    }
}