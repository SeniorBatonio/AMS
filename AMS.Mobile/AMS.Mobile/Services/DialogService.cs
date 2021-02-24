using Acr.UserDialogs;
using AMS.Mobile.Helpers;
using Prism.Ioc;
using Prism.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AMS.Mobile.Services
{
    public class DialogService
    {
        private static readonly Lazy<DialogService> LazyInstance = new Lazy<DialogService>(() => new DialogService(), true);
        private Application _app;
        private IDeviceService _deviceService;
        private IPageDialogService _pageDialogService;

        private DialogService()
        {
            MessagingCenter.Subscribe<MessageBus, DialogAlertInfo>(this, DialogMessages.DialogAlertMessage, DialogAlertCallback);

            MessagingCenter.Subscribe<MessageBus, string>(this, DialogMessages.DialogShowLoadingMessage, DialogShowLoadingCallback);
            MessagingCenter.Subscribe<MessageBus>(this, DialogMessages.DialogHideLoadingMessage, DialogHideLoadingCallback);
        }

        public static void Init(Application app)
        {
            LazyInstance.Value.SetApp(app);
            LazyInstance.Value.InitPrismServices();
        }

        protected void SetApp(Application app)
        {
            _app = app;
        }

        protected void InitPrismServices()
        {
            _deviceService = App.Current.Container.Resolve<IDeviceService>();
            _pageDialogService = App.Current.Container.Resolve<IPageDialogService>();
        }

        public static void SubscribeAlertMessages(DialogService dialogService, params KeyValuePair<string, DialogAlertInfo>[] pairs)
        {
            foreach (var pair in pairs)
            {
                MessagingCenter.Subscribe<MessageBus>(dialogService, pair.Key, (messageBus) =>
                {
                    dialogService.DialogAlertCallback(messageBus, pair.Value);
                });
            }
        }


        protected void DialogAlertCallback(MessageBus bus, DialogAlertInfo alertInfo)
        {
            if (alertInfo == null)
            {
                throw new ArgumentNullException(nameof(alertInfo));
            }

            if (_app?.MainPage == null)
            {
                throw new FieldAccessException(@"App property not set or App Main Page is not set. Use Init() before using dialogs");
            }

            _deviceService.BeginInvokeOnMainThread(async () =>
            {
                await _pageDialogService.DisplayAlertAsync(alertInfo.Title, alertInfo.Message, alertInfo.Cancel);
                alertInfo.OnCompleted?.Invoke();
            });
        }

        
        protected void DialogHideLoadingCallback(MessageBus bus)
        {
            _deviceService.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading());
        }

        protected void DialogShowLoadingCallback(MessageBus bus, string message)
        {
            _deviceService.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading(message, MaskType.Black));
        }
    }

    public static class DialogMessages
    {
        public const string DialogAlertMessage = @"DialogAlertMessage";

        public const string DialogShowLoadingMessage = @"DialogShowLoadingMessage";
        public const string DialogHideLoadingMessage = @"DialogHideLoadingMessage";
    }

    public class DialogAlertInfo
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Cancel { get; set; }
        public Action OnCompleted { get; set; }
    }
}