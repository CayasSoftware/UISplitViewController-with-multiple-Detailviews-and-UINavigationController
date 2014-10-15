using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UISplitViewWithMultipleDetails
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var splitViewController = new UISplitViewController();
            splitViewController.Delegate = new SplitViewControllerDelegate();

            var detailViewController = new UIViewController();
            var navigationRootController = new MainNavigationController();

            splitViewController.ViewControllers = new UIViewController[]{ new UINavigationController(navigationRootController), new UINavigationController(detailViewController) };

            window = new UIWindow(UIScreen.MainScreen.Bounds);
            window.RootViewController = splitViewController;
            window.MakeKeyAndVisible();

            return true;
        }
    }
}