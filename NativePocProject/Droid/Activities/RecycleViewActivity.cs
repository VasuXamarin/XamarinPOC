
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using NativePocProject.Droid.Adapters;
using NativePocProject.Droid.Models;
using NativePocProject.Droid.Services.ApiDefinitions;
using Plugin.Connectivity;
using Refit;
using Xamarin.Essentials;
using static NativePocProject.Droid.Models.DropBoxData;

namespace NativePocProject.Droid.Activities
{
    [Activity(Label = "RecycleViewActivity")]
    public class RecycleViewActivity : Activity
    {
        #region Properties
        private SwipeRefreshLayout mSwipeRefreshLayout;
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerViewListAdapter mRecyclerViewListAdapter;
        private DropBoxData apiData;
        private List<DropBoxRow> UserDataItems { get; set; }
        public DropBoxData UserDisplayData { get;  set; }
        #endregion

        #region Methods

        #region OnCreate CallBack
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.recyclelist);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            mSwipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeRefreshLayout);

            mSwipeRefreshLayout.Refresh += SwipeRefreshLayout_Refresh;

            UserDisplayData= await LoadRecyclerViewData();

            CalculatePlatformRunning();

            mRecyclerView.SetLayoutManager(mLayoutManager);

            mRecyclerViewListAdapter = new RecyclerViewListAdapter(this,UserDisplayData.DropBoxRows);
           
            mRecyclerView.SetAdapter(mRecyclerViewListAdapter);
        }
        #endregion

        #region CalculatePlatformRunning
        private void CalculatePlatformRunning()
        {
            var idiom = DeviceInfo.Idiom;
            if (idiom == DeviceIdiom.Phone)
            {
                mLayoutManager = new LinearLayoutManager(this);
            }
            else
            {
                mLayoutManager = new GridLayoutManager(this, 2, LinearLayoutManager.Vertical, false);
            }
        }
        #endregion

        #region LoadRecyclerViewData
        private async Task<DropBoxData> LoadRecyclerViewData()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    //await Task.Run(async () => 
                    //{
                        var dropBoxContentService = RestService.For<IDropBoxContentService>("https://dl.dropboxusercontent.com");
                        apiData = await dropBoxContentService.GetDropBoxContent();
                        UserDataItems = apiData.DropBoxRows;
                    //});
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
            catch (Exception)
            {
                
            }
            return apiData;
        }
        #endregion

        #region PullToRefresh Functionality
        private void SwipeRefreshLayout_Refresh(object sender, EventArgs e)
        {
            mRecyclerViewListAdapter = new RecyclerViewListAdapter(this, UserDisplayData.DropBoxRows);
            mRecyclerView.SetAdapter(mRecyclerViewListAdapter);
            mSwipeRefreshLayout.Refreshing = false;
        }
        #endregion

        #region Permission for Essential Packages
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        #endregion

        #endregion

    }
}
