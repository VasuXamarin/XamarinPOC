using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using NativePocProject.Droid.Activities;
using NativePocProject.Droid.Models;
using Square.Picasso;
using static NativePocProject.Droid.Models.DropBoxData;

namespace NativePocProject.Droid.Adapters
{
    public class RecyclerViewListAdapter : RecyclerView.Adapter
    {
        #region Properties
        private RecycleViewActivity recyclerViewActivityContext;
        private List<DropBoxRow> dropBoxRows;
        #endregion


        public RecyclerViewListAdapter(RecycleViewActivity recyclerViewActivityContext, List<DropBoxRow> dropBoxRows)
        {
            this.recyclerViewActivityContext = recyclerViewActivityContext;
            this.dropBoxRows = dropBoxRows;
        }

        #region Methods
        public override int ItemCount => dropBoxRows.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            try
            {
                if (dropBoxRows == null && dropBoxRows.Count == 0) return;

                DropBoxViewHolder viewHolderData = holder as DropBoxViewHolder;

                if (dropBoxRows[position].Title != null)
                {
                    viewHolderData.Title.Text =$"Title: {dropBoxRows[position]?.Title}";
                }
                else
                {
                    viewHolderData.Title.Text = "Title: No Title Available here!";
                }
                if (dropBoxRows[position].Description != null)
                {
                    viewHolderData.Description.Text = $"Description: {dropBoxRows[position]?.Description}";
                }
                else
                {
                    viewHolderData.Description.Text = "Description: No Description Available here!";
                }
                if(dropBoxRows[position].ImageHref != null)
                {
                    Picasso.With(recyclerViewActivityContext).Load(dropBoxRows[position]?.ImageHref).Error(Resource.Mipmap.Icon).Into(viewHolderData.Imageview);
                }

            }
            catch (Exception)
            {

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCardView, parent, false);
            DropBoxViewHolder dropBoxViewHolder = new DropBoxViewHolder(itemView);
            return dropBoxViewHolder;
        }
        #endregion

    }

    public class DropBoxViewHolder : RecyclerView.ViewHolder
    {
        #region Properties
        public TextView Title { get; private set; }
        public TextView Description { get; private set; }
        public ImageView Imageview { get; private set; }
        #endregion

        #region Methods
        public DropBoxViewHolder(View itemView) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.title);
            Description = itemView.FindViewById<TextView>(Resource.Id.description);
            Imageview = itemView.FindViewById<ImageView>(Resource.Id.imageView);
        }
        #endregion

    }
}
