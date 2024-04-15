using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.Interfaces.Views;
using Assets.Scripts.Interfaces.Controller;

namespace Assets.Scripts.UI.TreasureChest
{
    public class TreasureChestView : MonoBehaviour, IView<TreasureChestController>
    {
        [SerializeField]
        private GameObject treasureChestHolder;
        [SerializeField]
        private TextMeshProUGUI statusText;
        [SerializeField]
        private TextMeshProUGUI timerText;
        [SerializeField]
        private Button chestClickButton;
        [SerializeField]
        private TextMeshProUGUI gemsRequiredToUnlock;
        [SerializeField]
        private Animator animatorTreasureChest;
        private IController treasureChestController;

        private void OnEnable()
        {
            chestClickButton.onClick.AddListener(OnClickChestButton);
        }

        private void OnDisable()
        {
            chestClickButton.onClick.RemoveListener(OnClickChestButton);
        }

        public void SetController(TreasureChestController controller) => treasureChestController = controller;

        public void SetTeasureChestVisibility(bool value) => treasureChestHolder.SetActive(value);

        public void SetStatusInUI(string text) => statusText.SetText(text);

        public void SetGemsRequiredInUI(string text) => gemsRequiredToUnlock.SetText(text);

        private void OnClickChestButton() => GameService.Instance.UIService.GetPopupPanelUIController().SetPanelVisibility(true);
    }
}
