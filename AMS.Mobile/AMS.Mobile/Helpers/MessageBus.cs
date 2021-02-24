using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AMS.Mobile.Helpers
{
    public class MessageBus
    {
        private static readonly Lazy<MessageBus> LazyInstance = new Lazy<MessageBus>(() => new MessageBus(), true);
        static MessageBus Instance => LazyInstance.Value;

        private MessageBus()
        {
        }

        public static void SendMessage(string message, Exception ex = null)
        {
            MessagingCenter.Send(Instance, message);
        }

        public static void SendMessage<TArgs>(string message, TArgs args, Exception ex = null)
        {
            MessagingCenter.Send(Instance, message, args);
        }
    }
}
