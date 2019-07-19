using Android.App;
using Android.Widget;
using Android.OS;
using NativePocProject.Droid.Activities;
using Android.Content;
using Refit;
using NativePocProject.Droid.Services.ApiDefinitions;
using System.Net.Http;
using System;
using Plugin.Connectivity;

namespace NativePocProject.Droid
{
    [Activity(Label = "PocProject", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        #region Properties
        private EditText firstname, lastname;
        private Button passIntentDataBtn, displayListBtn, displayCustomListBtn, displayRecyclerViewBtn;
        #endregion

        #region Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            firstname = FindViewById<EditText>(Resource.Id.firstname);
            lastname = FindViewById<EditText>(Resource.Id.lastname);
            passIntentDataBtn = FindViewById<Button>(Resource.Id.passIntentAsMessageBtn);
            displayListBtn = FindViewById<Button>(Resource.Id.displayListBtn);
            displayCustomListBtn = FindViewById<Button>(Resource.Id.displayCustomList);
            displayRecyclerViewBtn = FindViewById<Button>(Resource.Id.displayRecyclerViewBtn);
            passIntentDataBtn.Click += PassIntentAsMessage;
            displayListBtn.Click += DisplayNormalListView;
            displayCustomListBtn.Click += DisplayCustomListView;
            displayRecyclerViewBtn.Click += DisplayListUsingRecyclerView;
        }

        #region PassIntentAsMessage
        private void PassIntentAsMessage(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("FirstName", firstname.Text);
            intent.PutExtra("LastName", lastname.Text);
            StartActivity(intent);
        }
        #endregion

        #region DisplayNormalListView
        private void DisplayNormalListView(object sender, System.EventArgs e)
        {
            StartActivity(typeof(ListviewActivity));
        }
        #endregion

        #region DisplayCustomListView
        private void DisplayCustomListView(object sender, System.EventArgs e)
        {
            StartActivity(typeof(CustomListActivity));
        }
        #endregion

        #region DisplayListUsingRecyclerView
        private void DisplayListUsingRecyclerView(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RecycleViewActivity));
            StartActivity(intent);
        }
        #endregion

        #endregion
    }
}

