using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.Interfaces.Views;
using Assets.Scripts.UI.TreasureChest.UIPanel;

namespace Assets.Scripts.UI.TreasureChest
{
    public class TreasureChestView : MonoBehaviour, IView<TreasureChestController>
    {
        [SerializeField]
        private GameObject treasureChestHolder;
        [SerializeField]
        private TextMeshProUGUI statusText;
        [SerializeField]
        private Button chestClickButton;
        [SerializeField]
        private TextMeshProUGUI gemsRequiredToUnlock;
        [SerializeField]
        private Animator animatorTreasureChest;
        [SerializeField]
        private GameObject requiredGemsCountHolder;
        [SerializeField]
        private TreasureChestUIIcon treasureChestUIIcon;
        private TreasureChestController treasureChestController;
        private Action OnAnimationComplete;
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        public void SubcribeEvents()
        {
            chestClickButton.onClick.AddListener(OnClickChestButton);
            treasureChestUIIcon.SubscribeEvents(OnAnimationComplete);
        }

        private void UnSubscribeEvents()
        {
            chestClickButton.onClick.RemoveListener(OnClickChestButton);
            treasureChestUIIcon.UnSubscribeEvents(OnAnimationComplete);
        }

        private void Update()
        {
            treasureChestController?.UpdateLoop();
        }
        public void SetController(TreasureChestController controller) => treasureChestController = controller;

        public void SetTeasureChestVisibility(bool value) => treasureChestHolder.SetActive(value);

        public void ToggleRequiredGemsState(bool value) => requiredGemsCountHolder.SetActive(value);

        public void SetStatusInUI(string text) => statusText.SetText(text);

        public void SetGemsRequiredInUI(string text) => gemsRequiredToUnlock.SetText(text);

        public void PlayTreasureOpenAnimation() => animatorTreasureChest.SetTrigger("Collected");

        public void SetAnimationDoneCallback(Action callback) => OnAnimationComplete = callback;

        private void OnClickChestButton() => treasureChestController.OnClickTreasureChest();
    }
}
