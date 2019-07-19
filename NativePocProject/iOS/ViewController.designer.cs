// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace NativePocProject.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DropBoxTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DropBoxTableView != null) {
                DropBoxTableView.Dispose ();
                DropBoxTableView = null;
            }
        }
    }
}