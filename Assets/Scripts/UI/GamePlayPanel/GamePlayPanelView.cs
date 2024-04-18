using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Interfaces.Views;

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
        private event Action OnClickUndoButton;

        private void OnEnable()
        {

        }

        public void SubscribeEvents()
        {
            if (gamePlayPanelController != null)
            {
                collectChestButton.onClick.AddListener(OnClickCollectChestButton);
                OnClickCollectChestButtonEvent += gamePlayPanelController.OnClickCollectChestButton;

                undoButton.onClick.AddListener(OnUndoButtonClicked);
                OnClickUndoButton += gamePlayPanelController.OnClickUndoButton;
            }
        }

        public void SetController(GamePlayPanelController controller) => gamePlayPanelController = controller;

        public void ToggleUndoVisibility(bool value) => undoButton.gameObject.SetActive(value);

        private void UnSubscribeEvents()
        {
            if (gamePlayPanelController != null)
            {
                collectChestButton.onClick.RemoveListener(OnClickCollectChestButton);
                OnClickCollectChestButtonEvent -= gamePlayPanelController.OnClickCollectChestButton;

                undoButton.onClick.RemoveListener(OnUndoButtonClicked);
                OnClickUndoButton -= gamePlayPanelController.OnClickUndoButton;
            }
        }

        private void OnUndoButtonClicked() => OnClickUndoButton?.Invoke();

        private void OnClickCollectChestButton() => OnClickCollectChestButtonEvent?.Invoke();

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

    }
}
