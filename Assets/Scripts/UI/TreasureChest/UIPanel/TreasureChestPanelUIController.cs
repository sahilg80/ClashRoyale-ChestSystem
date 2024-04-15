using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Interfaces.Controller;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.UI.TreasureChest.UIPanel
{
    public class TreasureChestPanelUIController : IController
    {
        private TreasureChestView treasureChestView;
        private Transform chestSlotHolderParent;
        private List<TreasureChestController> treasureChestList;
        private List<TreasureChestScriptableObject> treasureChestTypeList;
        private int treasureChestSlotListCount;

        public TreasureChestPanelUIController(TreasureChestView treasureChestView, Transform chestSlotHolderParent, 
            int treasureChestSlotListCount, List<TreasureChestScriptableObject> treasureChestTypeList)
        {
            this.chestSlotHolderParent = chestSlotHolderParent;
            this.treasureChestView = treasureChestView;
            this.treasureChestSlotListCount = treasureChestSlotListCount;
            this.treasureChestTypeList = treasureChestTypeList;
            Initialize();
        }

        public void Initialize()
        {
            treasureChestList = new List<TreasureChestController>();
            SubscribeEvents();
            SetupChestSlotsList();
        }

        private void SubscribeEvents()
        {
            GameService.Instance.EventService.OnClickAddChestButton.AddListener(CheckSlotAvailibity);
        }
        public void UnSubscribeEvents()
        {
            GameService.Instance.EventService.OnClickAddChestButton.RemoveListener(CheckSlotAvailibity);
        }

        private void SetupChestSlotsList()
        {
            treasureChestList.Capacity = treasureChestSlotListCount;
            for(int i=0; i< treasureChestSlotListCount; i++)
            {
                TreasureChestController controller = new TreasureChestController(treasureChestView, chestSlotHolderParent, this);
                treasureChestList.Add(controller);
            }
        }

        private void CheckSlotAvailibity()
        {
            TreasureChestController controller = treasureChestList.FirstOrDefault(t => t.IsSlotEmpty());
            
            if (controller != null)
            {
                SetupTreasureChest(controller);
            }
            else if (controller == null)
            {
                // show notofication panel
                GameService.Instance.EventService.NotifyPanelOpen.InvokeEvent(Constants.CHEST_SLOTS_NOT_AVAILABLE_TEXT);
            }
        }

        private void SetupTreasureChest(TreasureChestController controller)
        {
            controller.SetChestVisibility(true);
            TreasureChestScriptableObject treasureSO = GetRandomTreasureChestType();
            controller.SetTreasureChestType(treasureSO);
            controller.TransitionToState(States.StateType.LOCKED);
        }

        private TreasureChestScriptableObject GetRandomTreasureChestType()
        {
            // Generate a random index within the range of the list
            int randomIndex = UnityEngine.Random.Range(0, treasureChestTypeList.Count);

            // Return the scriptable object at the random index
            return treasureChestTypeList[randomIndex];
        }

        public bool IsTreasureChestAvailbleToStartUnlocking()
        {
            for (int i = 0; i < treasureChestSlotListCount; i++)
            {
                if (treasureChestList[i].GetActiveState() == States.StateType.UNLOCKING)
                    return false;
            }
            return true;
        }

    }
}
