using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
            //startTimerButton.onClick.AddListener();
            //buyWithGemButton.onClick.AddListener();
            closePanelButton.onClick.AddListener(DisablePanel);
        }

        public void UnSubscribeEvents()
        {
            //startTimerButton.onClick.RemoveListener();
            //buyWithGemButton.onClick.RemoveListener();
            closePanelButton.onClick.RemoveListener(DisablePanel);
        }

        private void DisablePanel() => SetPanelVisibility(false);

        public void SetPanelVisibility(bool value) => this.gameObject.SetActive(value);
        
        public void SetController(PopupPanelUIController controller) => this.popupController = controller;

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

    }
}
