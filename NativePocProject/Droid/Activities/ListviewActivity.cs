
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using static NativePocProject.Droid.Models.DropBoxData;

namespace NativePocProject.Droid.Activities
{
    [Activity(Label = "ListviewActivity")]
    public class ListviewActivity : Activity
    {
        #region Properties
        private List<string> Items;
        private List<DropBoxRow> UserDataItems;
        private ListView listview;
        private SwipeRefreshLayout swipeRefreshLayout;
        #endregion

        #region Methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.listviewlayout);
                listview = FindViewById<ListView>(Resource.Id.listView1);
                swipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeRefreshLayout);
                Items = new List<string>(){ "Srinivasu","Vamsi Krishna","Siva Krishna","Harvinder","Bharat", "Abdul Basha","Bhargavi","Mounika","Rajeswari","Srikanth" };
            }
            catch (Exception ex)
            {

            }

            listview.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Items);

            swipeRefreshLayout.Refresh += delegate (object sender, System.EventArgs e)
            {
                listview.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Items);
                swipeRefreshLayout.Refreshing = false;
            };
        }
        #endregion
    }
}
