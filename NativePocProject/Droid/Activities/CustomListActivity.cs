
using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Widget;
using NativePocProject.Droid.Adapters;
using NativePocProject.Droid.Services.ApiDefinitions;
using Plugin.Connectivity;
using Refit;
using static NativePocProject.Droid.Models.DropBoxData;

namespace NativePocProject.Droid.Activities
{
    [Activity(Label = "CustomListActivity")]
    public class CustomListActivity : Activity
    {
        #region Properties
        private List<DropBoxRow> UserDataItems;
        private ListView listview;
        SwipeRefreshLayout swipeRefreshLayout;
        #endregion

        #region Methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.customlistview);
            listview = FindViewById<ListView>(Resource.Id.listView1);
            swipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeRefreshLayout);
            GetUsersData();
            swipeRefreshLayout.Refresh += SwipeRefreshLayout_Refresh;
        }

        private void SwipeRefreshLayout_Refresh(object sender, EventArgs e)
        {
            listview.Adapter = new CustomListAdapter(UserDataItems);
            swipeRefreshLayout.Refreshing = false;
        }

        private async void GetUsersData()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var dropBoxContentService = RestService.For<IDropBoxContentService>("https://dl.dropboxusercontent.com");
                    var apiData = await dropBoxContentService.GetDropBoxContent();
                    UserDataItems = apiData.DropBoxRows;
                    if (UserDataItems == null && UserDataItems.Count == 0) return;
                     listview.Adapter = new CustomListAdapter(UserDataItems);
                }
                else
                {
                   AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Alert Message");
                    alert.SetMessage("Oops.. No Internet is Connected!");
                    alert.SetButton("OK", (c, ev) =>
                    {
                    });
                    alert.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

    }
}
