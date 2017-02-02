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
        private EditText fNameET, lNameET, emailET, loginET, passwordET, confirm_passwordET;
        private Button registerBN, zakritFragmentbn;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.registrationFragment, container, false);

            registerBN = rootView.FindViewById<Button>(Resource.Id.registerBN);
            zakritFragmentbn = rootView.FindViewById<Button>(Resource.Id.zakritFragmentBn);

            fNameET = rootView.FindViewById<EditText>(Resource.Id.fNameET);
            lNameET = rootView.FindViewById<EditText>(Resource.Id.lNameET);
            emailET = rootView.FindViewById<EditText>(Resource.Id.emailET);
            loginET = rootView.FindViewById<EditText>(Resource.Id.loginET);
            passwordET = rootView.FindViewById<EditText>(Resource.Id.passwordET);
            confirm_passwordET = rootView.FindViewById<EditText>(Resource.Id.confirm_passwordET);

            registerBN.Click += registerBN_Click;
            zakritFragmentbn.Click += ZakritFragmentbn_Click;

            return rootView;
        }

        private void ZakritFragmentbn_Click(object sender, EventArgs e)
        {
            Dismiss();
        }

        private void registerBN_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(fNameET.Text) || String.IsNullOrEmpty(lNameET.Text) || String.IsNullOrEmpty(emailET.Text)
                || String.IsNullOrEmpty(loginET.Text) || String.IsNullOrEmpty(passwordET.Text))
            {
                Toast.MakeText(this.Activity, "Fill all the fields", ToastLength.Short).Show();
            }

            else
            {
                if (passwordET.Text != confirm_passwordET.Text)
                {
                    Toast.MakeText(this.Activity, "Passwords do not match", ToastLength.Short).Show();
                }
                else
                {
                    Dismiss();
                }
            }
            /*
            //Clearing EditTexts:
            eng1_ET.Text = null;
            eng2_ET.Text = null;
            eng3_ET.Text = null;
            rusEdText.Text = null;*/
        }
    }
}
