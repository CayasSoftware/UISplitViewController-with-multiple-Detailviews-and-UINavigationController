using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UISplitViewWithMultipleDetails
{
    class SplitViewControllerDelegate : UISplitViewControllerDelegate
    {
        public UIBarButtonItem BarButtonItem
        {
            get;
            private set;
        }

        public override bool ShouldHideViewController(UISplitViewController svc, UIViewController viewController, UIInterfaceOrientation inOrientation)
        {
            return inOrientation == UIInterfaceOrientation.Portrait || inOrientation == UIInterfaceOrientation.PortraitUpsideDown;
        }

        [Export("splitViewController:willHideViewController:withBarButtonItem:forPopoverController:")]
        public void WillHideViewController(UISplitViewController splitController, UIViewController viewController, UIBarButtonItem barButtonItem, UIPopoverController popoverController)
        {
            if (splitController == null)
                throw new ArgumentNullException("splitController");
            if (popoverController == null)
                throw new ArgumentNullException("popoverController");
            if (viewController == null)
                throw new ArgumentNullException("viewController");
        
            barButtonItem.Title = (viewController as UINavigationController).TopViewController.Title;

            var detailNavController = splitController.ViewControllers[1] as UINavigationController;
            var detailViewController = detailNavController.TopViewController;
            detailViewController.NavigationItem.SetLeftBarButtonItem(barButtonItem, true);

            BarButtonItem = barButtonItem;
        }

        [Export("splitViewController:willShowViewController:invalidatingBarButtonItem:")]
        public void WillShowViewController(UISplitViewController svc, UIViewController vc, UIBarButtonItem button)
        {
            if (svc == null)
                throw new ArgumentNullException("svc");
            if (vc == null)
                throw new ArgumentNullException("vc");
            if (button == null)
                throw new ArgumentNullException("button");
        
            svc.ChildViewControllers[1].ChildViewControllers[0].NavigationItem.SetLeftBarButtonItem(null, true);

            BarButtonItem = null;
        }
    }
}