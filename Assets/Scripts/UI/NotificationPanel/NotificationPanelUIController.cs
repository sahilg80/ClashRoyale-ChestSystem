using Assets.Scripts.Interfaces.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.NotificationPanel
{
    public class NotificationPanelUIController : IController
    {
        private NotificationPanelUIView notificationPanelUIView;

        public NotificationPanelUIController(NotificationPanelUIView notificationPanelUIView)
        {
            this.notificationPanelUIView = notificationPanelUIView;
            Initialize();
        }

        ~NotificationPanelUIController()
        {
            UnSubscribeEvents();
        }

        public void Initialize()
        {
            notificationPanelUIView.SetController(this);
            SubscribeEvents();
            SetPanelVisibility(false);
        }

        private void SubscribeEvents()
        {
            GameService.Instance.EventService.NotifyPanelOpen.AddListener(SetNotificationText);
        }

        private void UnSubscribeEvents()
        {
            GameService.Instance.EventService.NotifyPanelOpen.RemoveListener(SetNotificationText);
        }

        private void SetPanelVisibility(bool value) => notificationPanelUIView.SetPanelVisibility(value);

        private void SetNotificationText(string value)
        {
            SetPanelVisibility(true);
            notificationPanelUIView.SetNotificationText(value);
        }
    }
}
