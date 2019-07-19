using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace NativePocProject.iOS
{
    [Register("CardView"), DesignTimeVisible(true)]
    public class CardView : UIView
    {
        private float cornerRadius;
        private UIColor shadowColor;
        private UIColor backgroundColor;
        private int shadowOffsetHeight;
        private int shadowOffsetWidth;
        private float shadowOpacity;

        [DisplayName("Shadow Opacity"), Export("shadowOpacity"), Browsable(true)]
        public float ShadowOpacity
        {
            get { return shadowOpacity; }
            set
            {
                shadowOpacity = value;
                SetNeedsDisplay();
            }
        }

        [DisplayName("Shadow Offset Width"), Export("shadowOffsetWidth"), Browsable(true)]
        public int ShadowOffsetWidth
        {
            get { return shadowOffsetWidth; }
            set
            {
                shadowOffsetWidth = value;
                SetNeedsDisplay();
            }
        }

        [DisplayName("Shadow Offset Height"), Export("shadowOffsetHeight"), Browsable(true)]
        public int ShadowOffsetHeight
        {
            get { return shadowOffsetHeight; }
            set
            {
                shadowOffsetHeight = value;
                SetNeedsDisplay();
            }
        }

        [DisplayName("Corner Radius"), Export("CornerRadius"), Browsable(true)]
        public float CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                SetNeedsDisplay();
            }
        }

        [DisplayName("Background Color"), Export("BackgroundColor"), Browsable(true)]
        public UIColor BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                SetNeedsDisplay();
            }
        }

        public CardView()
        {
            Initialize();
        }

        public CardView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        protected CardView(NSObjectFlag t) : base(t)
        {
            Initialize();
        }

        protected internal CardView(IntPtr handle) : base(handle)
        {
        }

        public CardView(CGRect frame) : base(frame)
        {
            Initialize();
        }


        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            Initialize();
        }

        private void Initialize()
        {
            backgroundColor= UIColor.FromRGB(232, 234, 237);
            CornerRadius = 10;
            ShadowOffsetHeight = 1;
            ShadowOffsetWidth = 0;
            ShadowOpacity = 0.2f;
            SetupCard();
        }

        private void SetupCard()
        {
            Layer.CornerRadius = CornerRadius;
            UIBezierPath bezierPath = UIBezierPath.FromRoundedRect(Bounds, CornerRadius);
            Layer.MasksToBounds = false;
            Layer.BackgroundColor = backgroundColor.CGColor;
            Layer.ShadowOffset = new CGSize(shadowOffsetWidth, shadowOffsetHeight);
            Layer.ShadowOpacity = shadowOpacity;
            Layer.ShadowPath = bezierPath.CGPath;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            SetupCard();
        }
    }
}
