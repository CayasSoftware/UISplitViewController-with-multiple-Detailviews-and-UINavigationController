using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace UISplitViewWithMultipleDetails
{
    public class MainNavigationController : UITableViewController
    {
        public MainNavigationController()
            : base(UITableViewStyle.Grouped)
        {
            Title = "Hauptmenü";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.Source = new MainNavigationItemSource(this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (((UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).Delegate as SplitViewControllerDelegate).BarButtonItem != null)
                ((UIApplication.SharedApplication.KeyWindow.RootViewController as UISplitViewController).Delegate as SplitViewControllerDelegate).BarButtonItem.Title = Title;
        }
    }

    public class MainNavigationItemSource : UITableViewSource
    {
        const string cellIdentifier = "MainNavigationItemTableCell";

        readonly MainNavigationController parentController;
        readonly List<string> navigationItemList;

        public MainNavigationItemSource(MainNavigationController parent)
        {
            parentController = parent;
            navigationItemList = new List<string>(){ "Eintrag1", "Eintrag2" };
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
            switch (indexPath.Row)
            {
                case 1:
                    parentController.NavigationController.PushViewController(new SettingsNavigationController(), true);
                    break;
                
            }
        }
    }
}