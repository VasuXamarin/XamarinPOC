using Foundation;
using System;
using UIKit;
using static NativePocProject.iOS.Models.DropBoxData;

namespace NativePocProject.iOS
{
    public partial class CustomBoxCell : UIView
    {
        public CustomBoxCell (IntPtr handle) : base (handle)
        {
        }
        public void UpdateDropBoxData(DropBoxRow dropBoxContent)
        {

            if (dropBoxContent.Title != null)
            {
                //LblTitle.Text = $"Title: {dropBoxContent.Title}";
            }
            if (dropBoxContent.Description != null)
            {
               // LblDescription.Text = $"Description: {dropBoxContent.Description}";
            }

            //LblTitle.TextColor = UIColor.DarkTextColor;
            //LblDescription.TextColor = UIColor.DarkTextColor;
        }
    }
}