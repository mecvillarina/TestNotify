﻿using System.Collections.Generic;

namespace TestNotify.Shared
{
    public interface IPushNotificationHandler
    {
        //Method triggered when an error occurs
        void OnError(string error);
        //Method triggered when a notification is opened by tapping an action
        void OnAction(NotificationResponse response);
        //Method triggered when a notification is opened
        void OnOpened(NotificationResponse response);
        //Method triggered when a notification is received
        void OnReceived(IDictionary<string, object> parameters);
    }
}