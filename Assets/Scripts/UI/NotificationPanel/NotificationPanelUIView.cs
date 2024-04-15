using Assets.Scripts.Interfaces.Views;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.UI.NotificationPanel
{
    public class NotificationPanelUIView : MonoBehaviour, IView<NotificationPanelUIController>
    {

        [SerializeField]
        private TextMeshProUGUI statusText;
        [SerializeField]
        private Button closePanelButton;
        private NotificationPanelUIController notificationPanelUIController;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            closePanelButton.onClick.AddListener(DisablePanel);
        }

        private void UnSubscribeEvents()
        {
            closePanelButton.onClick.RemoveListener(DisablePanel);
        }

        private void DisablePanel() => SetPanelVisibility(false);

        public void SetPanelVisibility(bool value) => this.gameObject.SetActive(value);

        public void SetNotificationText(string value) => statusText.SetText(value);

        public void SetController(NotificationPanelUIController controller) => notificationPanelUIController = controller;
    }
}
