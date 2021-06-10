using Amazon.SimpleNotificationService;
using Foundation;
using System;
using TestNotify.iOS.PushNotification;
using UIKit;
using UserNotifications;

namespace TestNotify.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate {
    
        [Export("window")]
        public UIWindow Window { get; set; }

        private AmazonSimpleNotificationServiceClient _snsClient;
        [Export ("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            PushNotificationManager.Initialize(launchOptions, false);

            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            return true;
        }

        private void CreateSNSClient()
        {
            //_snsClient = new AmazonSimpleNotificationServiceClient(credentials, region);
        }
       
        // UISceneSession Lifecycle

        [Export ("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration (UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create ("Default Configuration", connectingSceneSession.Role);
        }

        [Export ("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions (UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }

        [Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
        public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            PushNotificationManager.DidRegisterRemoteNotifications(deviceToken);
        }

        [Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
        public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            PushNotificationManager.RemoteNotificationRegistrationFailed(error);

        }
        // To receive notifications in foregroung on iOS 9 and below.
        // To receive notifications in background in any iOS version
        [Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
        [ObjCRuntime.Introduced(ObjCRuntime.PlatformName.TvOS, 10, 0, ObjCRuntime.PlatformArchitecture.All, null)]
        [ObjCRuntime.Introduced(ObjCRuntime.PlatformName.iOS, 7, 0, ObjCRuntime.PlatformArchitecture.All, null)]
        public void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            PushNotificationManager.DidReceiveMessage(userInfo);
        }
    }
}

