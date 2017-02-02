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








using System.Net;
using System.IO;

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
                    const String CorrectAuthText = "Авторизация прошла успешно";
                    var request = (HttpWebRequest)WebRequest.Create("http://datausers1.azurewebsites.net/PersonsClasses/Create");
                    var postData = "btn_auth=True";
                    postData += "&LastName=" + lNameET.Text;
                    postData += "&FirstName"+ fNameET.Text;
                    postData += "&Email"+ emailET.Text;
                    postData += "&login_"+ loginET.Text;
                    postData += "&password_"+ passwordET.Text;
                    var data = Encoding.ASCII.GetBytes(postData);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    { stream.Write(data, 0, data.Length); }
                    var response = (HttpWebResponse)request.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    if(responseString.Contains(CorrectAuthText))
                    {
                        Toast.MakeText(this.Activity, "Authorized!", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(this.Activity, "Authorization failed!", ToastLength.Short).Show();
                    }
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
