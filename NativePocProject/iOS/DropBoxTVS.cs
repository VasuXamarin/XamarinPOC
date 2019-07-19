using System;
using System.Collections.Generic;
using Foundation;
using NativePocProject.iOS.Models;
using UIKit;
using static NativePocProject.iOS.Models.DropBoxData;

namespace NativePocProject.iOS
{
    internal class DropBoxTVS : UITableViewSource
    {
        private List<DropBoxRow> data;

        public DropBoxTVS(List<DropBoxRow> data)
        {
            this.data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

                var cell = (DropBoxCell)tableView.DequeueReusableCell("Cellid", indexPath);

                var dropBoxContent = data[indexPath.Row];

                cell.UpdateDropBoxData(dropBoxContent);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }
    }
}