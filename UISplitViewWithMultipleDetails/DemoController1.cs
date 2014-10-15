using System;
using MonoTouch.UIKit;

namespace UISplitViewWithMultipleDetails
{
    public class DemoController1 : UIViewController
    {
        public DemoController1()
        {
            Title = "Demo1";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Blue;
        }
    }
}