using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Interfaces.Views;
using Assets.Scripts.Interfaces.Controller;

namespace Assets.Scripts.UI.GamePlayPanel
{
    public class GamePlayPanelView : MonoBehaviour, IView<GamePlayPanelController>
    {
        [SerializeField]
        private Button collectChestButton;
        [SerializeField]
        private Button undoButton;
        private GamePlayPanelController gamePlayPanelController;
        private event Action OnClickCollectChestButtonEvent;

        private void OnEnable()
        {

        }

        public void SubscribeEvents()
        {
            if (gamePlayPanelController != null)
            {
                collectChestButton.onClick.AddListener(OnClickCollectChestButton);
                OnClickCollectChestButtonEvent += gamePlayPanelController.OnClickCollectChestButton;
            }
        }

        private void UnSubscribeEvents()
        {
            if (gamePlayPanelController != null)
            {
                collectChestButton.onClick.RemoveListener(OnClickCollectChestButton);
                OnClickCollectChestButtonEvent -= gamePlayPanelController.OnClickCollectChestButton;
            }
        }

        private void OnClickCollectChestButton() => OnClickCollectChestButtonEvent?.Invoke();

        public void SetController(GamePlayPanelController controller) => gamePlayPanelController = controller;

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

    }
}
