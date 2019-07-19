using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Square.Picasso;
using static NativePocProject.Droid.Models.DropBoxData;

namespace NativePocProject.Droid.Adapters
{
    public class CustomListAdapter : BaseAdapter<DropBoxRow>
    {
        #region Properties
        private List<DropBoxRow> dropBoxRowItems;
        #endregion

        #region Ctor
        public CustomListAdapter(List<DropBoxRow> dropBoxRowItems)
        {
            this.dropBoxRowItems = dropBoxRowItems;
        }
        #endregion

        #region Methods
        public override DropBoxRow this[int position] => dropBoxRowItems[position];

        public override int Count => dropBoxRowItems.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                try
                {
                    view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custommisedlistview, parent, false);

                    TextView name = view.FindViewById<TextView>(Resource.Id.firstname);
                    TextView department = view.FindViewById<TextView>(Resource.Id.lastname);
                    var photo = view.FindViewById<ImageView>(Resource.Id.imageView1);

                    view.Tag = new ViewHolder() { Title = name, Description = department, Photo = photo };

                    var holder = (ViewHolder)view.Tag;

                    holder.Title.Text = $" Title : {dropBoxRowItems[position].Title}";
                    holder.Description.Text = $" Description : {dropBoxRowItems[position].Description}";
                   
                    // holder.Photo.SetImageURI((Android.Net.Uri)dropBoxRowItems[position]?.ImageHref);
                    Picasso.With(parent.Context).Load(dropBoxRowItems[position]?.ImageHref).Error(Resource.Mipmap.Icon).Into(holder.Photo);
                
                }
                catch (System.Exception ex)
                {

                }
            }
            return view;
        }
        #endregion

    }
}
