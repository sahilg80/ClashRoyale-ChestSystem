using Assets.Scripts.Interfaces.Controller;
using Assets.Scripts.UI.TreasureChest;

namespace Assets.Scripts.UI.PopupPanel
{
    public class PopupPanelUIController : IController
    {
        private PopupPanelUIView popupPanelUIView;
        private TreasureChestController selectedTreasureChestController;

        public PopupPanelUIController(PopupPanelUIView popupPanelUIView)
        {
            this.popupPanelUIView = popupPanelUIView;
            Initialize();
        }

        ~PopupPanelUIController()
        {
            GameService.Instance.EventService.PopPanelDisplay.RemoveListener(SetSelectedChestPopupPanel);
        }

        public void Initialize()
        {
            popupPanelUIView.SetController(this);
            SetPanelVisibility(false);
            GameService.Instance.EventService.PopPanelDisplay.AddListener(SetSelectedChestPopupPanel);
        }

        public void SetSelectedChestPopupPanel(bool value, TreasureChestController controller)
        {
            SetPanelVisibility(true);
            ToggleTimerButtonState(value);
            selectedTreasureChestController = controller;
        }

        //public void SetSelectedChestController(TreasureChestController controller) => selectedTreasureChestController = controller;

        //public void PanelVisibilityWithTimerButtonON(bool value)
        //{
        //    SetPanelVisibility(true);
        //    ToggleTimerButtonState(value);
        //}

        public void OnClickStartTimer()
        {
            selectedTreasureChestController.TransitionToState(TreasureChest.States.StateType.UNLOCKING);
            SetPanelVisibility(false);
        }

        public void OnClickBuyButton()
        {
            selectedTreasureChestController.OnClickBuyWithGemsButton();
            SetPanelVisibility(false);
        }

        public void OnPanelDisable() => selectedTreasureChestController = null;

        private void SetPanelVisibility(bool value) => popupPanelUIView.SetPanelVisibility(value);

        private void ToggleTimerButtonState(bool value) => popupPanelUIView.ToggleTimerButtonState(value);

    }
}
