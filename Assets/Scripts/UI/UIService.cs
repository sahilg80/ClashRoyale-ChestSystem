using Assets.Scripts.UI.GamePlayPanel;
using Assets.Scripts.UI.NotificationPanel;
using Assets.Scripts.UI.Player;
using Assets.Scripts.UI.PopupPanel;
using Assets.Scripts.UI.TreasureChest;
using Assets.Scripts.UI.TreasureChest.UIPanel;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIService : MonoBehaviour
    {
        [Header("TreasureChest")]
        [SerializeField]
        private TreasureChestView treasureChestView;
        [SerializeField]
        private Transform chestSlotHolderParent;
        [SerializeField]
        private List<TreasureChestScriptableObject> treasureChestTypeList;
        private TreasureChestPanelUIController treasureChestPanelUIController;

        [Header("GamePlayPanel")]
        [SerializeField]
        private GamePlayPanelView gamePlayPanelView;
        private GamePlayPanelController gamePlayPanelController;

        [Header("Player")]
        [SerializeField]
        private PlayerUIScriptableObject playerSO;
        [SerializeField]
        private PlayerUIView playerUIView;
        private PlayerUIController playerUIController;

        [Header("Notification")]
        [SerializeField]
        private NotificationPanelUIView notificationPanelUIView;
        private NotificationPanelUIController notificationPanelUIController;

        [Header("PopUpPanel")]
        [SerializeField]
        private PopupPanelUIView popupPanelUIView;
        private PopupPanelUIController popupPanelUIController;

        private void OnDisable()
        {
            treasureChestPanelUIController.UnSubscribeEvents();
        }

        public void Initialize()
        {
            treasureChestPanelUIController = new TreasureChestPanelUIController(treasureChestView, chestSlotHolderParent, 
                playerSO.ChestSlotsCount, treasureChestTypeList);
            gamePlayPanelController = new GamePlayPanelController(gamePlayPanelView);
            playerUIController = new PlayerUIController(playerSO, playerUIView);
            popupPanelUIController = new PopupPanelUIController(popupPanelUIView);
            notificationPanelUIController = new NotificationPanelUIController(notificationPanelUIView);
        }

        public PlayerUIController GetPlayerUIController() => playerUIController;

        public PopupPanelUIController GetPopupPanelUIController() => popupPanelUIController;

    }
}
