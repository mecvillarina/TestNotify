using Foundation;
using System;
using TestNotify.Shared;
using UIKit;

namespace TestNotify.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            // Handle when your app starts
            CrossPushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                UIPasteboard.General.String = p.Token;
                System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
                System.Diagnostics.Debug.WriteLine($"DEVICE ID: {UIDevice.CurrentDevice.IdentifierForVendor.ToString()}");
            };

            CrossPushNotification.Current.RegisterForPushNotifications();

            if (!string.IsNullOrEmpty(CrossPushNotification.Current.Token))
            {
                System.Diagnostics.Debug.WriteLine($"{ CrossPushNotification.Current.Token}");
            }

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}