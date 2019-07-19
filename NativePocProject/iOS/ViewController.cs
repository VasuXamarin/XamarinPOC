using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NativePocProject.iOS.Services.ApiDefinitions;
using Plugin.Connectivity;
using Refit;
using UIKit;
using static NativePocProject.iOS.Models.DropBoxData;

namespace NativePocProject.iOS
{
    public partial class ViewController : UIViewController
    {
        #region Properties
        private List<DropBoxRow> Data;
        bool useRefreshControl = false;
        UIRefreshControl RefreshControl;
        #endregion

        #region Ctor
        public ViewController(IntPtr handle) : base(handle)
        {

        }
        #endregion

        #region ViewDidLoad
        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoadDropBoxContent();
            await RefreshAsync();
            AddRefreshControl();
            DropBoxTableView.Add(RefreshControl);
        }
        #endregion

        #region ServiceCalling
        private async void LoadDropBoxContent()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://dl.dropboxusercontent.com");
                    var dropBoxContentService = RestService.For<IDropBoxContent>(httpClient);
                    var apiData = await dropBoxContentService.GetDropBoxContent();
                    Data = new List<DropBoxRow>();
                    Data = apiData.DropBoxRows;
                    if (Data == null && Data.Count == 0) return;
                    DropBoxTableView.Source =new DropBoxTVS(Data);
                    DropBoxTableView.ReloadData();

                }
                else
                {
                    var okAlertController = UIAlertController.Create("Alert Message", "Opps..Internet is Connected!!", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region PullToRefresh
        private async Task RefreshAsync()
        {
            if (useRefreshControl)
                RefreshControl.BeginRefreshing();

            if (useRefreshControl)
                RefreshControl.EndRefreshing();

            DropBoxTableView.ReloadData();
        }

        private void AddRefreshControl()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(6, 0))
            {
                RefreshControl = new UIRefreshControl();
                RefreshControl.ValueChanged += async (sender, e) =>
                {
                    await RefreshAsync();
                };
                useRefreshControl = true;
            }
        }
        #endregion

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.     
        }
    }
}
