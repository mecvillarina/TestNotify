using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace TestNotify.Shared
{
    public class NotificationResponse
    {
        public string Identifier { get; }

        public IDictionary<string, object> Data { get; }

        public NotificationCategoryType Type { get; }

        public string? Result { get; }

        public NotificationResponse(IDictionary<string, object> data, string identifier = "", NotificationCategoryType type = NotificationCategoryType.Default, string? result = null)
        {
            Identifier = identifier;
            Data = data;
            Type = type;
            Result = result;
        }
    }
}