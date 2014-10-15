using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UISplitViewWithMultipleDetails
{
    class SettingsNavigationController : UITableViewController
    {
        public SettingsNavigationController()
            : base(UITableViewStyle.Grouped)
        {
            Title = "Einstellungen";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new SettingsNavigationItemSource();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (((UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).Delegate as SplitViewControllerDelegate).BarButtonItem != null)
                ((UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).Delegate as SplitViewControllerDelegate).BarButtonItem.Title = Title;
        }
    }

    class SettingsNavigationItemSource : UITableViewSource
    {
        const string cellIdentifier = "SettingsNavigationItemTableCell";
        readonly List<string> navigationItemList;

        public SettingsNavigationItemSource()
        {
            navigationItemList = new List<string>() { "Demo1", "Demo2" };
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            cell.TextLabel.Text = navigationItemList[indexPath.Row];
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return navigationItemList.Count;
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var barButtonItem = ((UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).Delegate as SplitViewControllerDelegate).BarButtonItem;

            switch (indexPath.Row)
            {
                case 0:
                    var demoCtrl1 = new DemoController1();

                    if (barButtonItem != null)
                        demoCtrl1.NavigationItem.SetLeftBarButtonItem(barButtonItem, false);

                    (UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).ViewControllers = new UIViewController[]{ (UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).ViewControllers[0], new UINavigationController(demoCtrl1) };
                    break;
                case 1:
                    var demoCtrl2 = new DemoController2();

                    if (barButtonItem != null)
                        demoCtrl2.NavigationItem.SetLeftBarButtonItem(barButtonItem, false);

                    (UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).ViewControllers = new UIViewController[]{ (UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).ViewControllers[0], new UINavigationController(demoCtrl2) };
                    break;
            }
        }
    }
}