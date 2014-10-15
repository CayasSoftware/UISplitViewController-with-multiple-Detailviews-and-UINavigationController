using System;
using MonoTouch.UIKit;

namespace UISplitViewWithMultipleDetails
{
    public class DemoController2 : UIViewController
    {
        public DemoController2()
        {
            Title = "Demo2";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.DarkGray;
        }
    }
}