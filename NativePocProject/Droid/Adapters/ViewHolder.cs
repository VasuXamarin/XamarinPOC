using Android.Widget;
using Java.Lang;

namespace NativePocProject.Droid.Adapters
{
    public class ViewHolder : Object
    {
        public TextView Title { get; set; }
        public TextView Description { get; set; }
        public ImageView Photo { get; internal set; }
    }
}