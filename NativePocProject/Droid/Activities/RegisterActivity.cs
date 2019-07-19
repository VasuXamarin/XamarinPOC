
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

namespace NativePocProject.Droid.Activities
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        #region Properties
        private EditText firstname, lastname;
        #endregion

        #region Methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.userdetail);
            firstname = FindViewById<EditText>(Resource.Id.firstname);
            lastname = FindViewById<EditText>(Resource.Id.lastname);
            String value1 = Intent.GetStringExtra("FirstName");
            String value2 = Intent.GetStringExtra("LastName");
            firstname.Text = value1;
            lastname.Text = value2;
        }
        #endregion

    }
}
