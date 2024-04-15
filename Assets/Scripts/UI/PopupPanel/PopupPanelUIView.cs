
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Interfaces.Views;

namespace Assets.Scripts.UI.PopupPanel
{
    public class PopupPanelUIView : MonoBehaviour, IView<PopupPanelUIController>
    {
        [SerializeField]
        private Button startTimerButton;
        [SerializeField]
        private Button buyWithGemButton;
        [SerializeField]
        private Button closePanelButton;

        private PopupPanelUIController popupController;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        public void SubscribeEvents()
        {
            startTimerButton.onClick.AddListener(OnClickStartTimerButton);
            buyWithGemButton.onClick.AddListener(OnClickBuyWithGemsButton);
            closePanelButton.onClick.AddListener(DisablePanel);
        }

        public void UnSubscribeEvents()
        {
            startTimerButton.onClick.RemoveListener(OnClickStartTimerButton);
            buyWithGemButton.onClick.RemoveListener(OnClickBuyWithGemsButton);
            closePanelButton.onClick.RemoveListener(DisablePanel);
        }

        public void SetPanelVisibility(bool value) => this.gameObject.SetActive(value);

        public void ToggleTimerButtonState(bool value) => startTimerButton.gameObject.SetActive(value);

        public void SetController(PopupPanelUIController controller) => this.popupController = controller;

        private void DisablePanel()
        {
            popupController.OnPanelDisable();
            SetPanelVisibility(false);
        }

        private void OnClickStartTimerButton() => popupController.OnClickStartTimer();

        private void OnClickBuyWithGemsButton() => popupController.OnClickBuyButton();

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

    }
}
