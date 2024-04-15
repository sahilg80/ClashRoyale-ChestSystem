using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.UI.TreasureChest
{
    public class TreasureChestService
    {
        private TreasureChestView treasureChestView;
        private Transform chestSlotHolderParent;
        private List<TreasureChestController> treasureChestList;
        private List<TreasureChestScriptableObject> treasureChestTypeList;
        private int treasureChestSlotListCount;

        public TreasureChestService(TreasureChestView treasureChestView, Transform chestSlotHolderParent, 
            int treasureChestSlotListCount, List<TreasureChestScriptableObject> treasureChestTypeList)
        {
            this.chestSlotHolderParent = chestSlotHolderParent;
            this.treasureChestView = treasureChestView;
            this.treasureChestSlotListCount = treasureChestSlotListCount;
            this.treasureChestTypeList = treasureChestTypeList;
            Initialize();
        }

        private void Initialize()
        {
            treasureChestList = new List<TreasureChestController>();
            SubscribeEvents();
            SetupChestSlotsList();
        }

        private void SubscribeEvents()
        {
            GameService.Instance.EventService.OnClickCollectChestButton.AddListener(CheckSlotAvailibity);
        }
        public void UnSubscribeEvents()
        {
            GameService.Instance.EventService.OnClickCollectChestButton.RemoveListener(CheckSlotAvailibity);
        }

        private void SetupChestSlotsList()
        {
            treasureChestList.Capacity = treasureChestSlotListCount;
            for(int i=0; i< treasureChestSlotListCount; i++)
            {
                TreasureChestController controller = new TreasureChestController(treasureChestView, chestSlotHolderParent);
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
                GameService.Instance.EventService.NotifyPanelOpen.InvokeEvent("All slots full");
            }
        }

        private void SetupTreasureChest(TreasureChestController controller)
        {
            controller.SetChestVisibility(true);
            TreasureChestScriptableObject treasureSO = GetRandomTreasureChestType();
            controller.SetTreasureChestType(treasureSO);
            controller.UpdateUIValues(CalculateGemsRequired(treasureSO.Timer));
        }

        private TreasureChestScriptableObject GetRandomTreasureChestType()
        {
            // Generate a random index within the range of the list
            int randomIndex = UnityEngine.Random.Range(0, treasureChestTypeList.Count);

            // Return the scriptable object at the random index
            return treasureChestTypeList[randomIndex];
        }

        private int CalculateGemsRequired(float timeValue)
        {
            // Calculate gems based on time value
            float gems = timeValue / 10.0f;

            // Round up to the nearest whole number (ceiling)
            int roundedGems = Mathf.CeilToInt(gems);

            return roundedGems;
        }

    }
}
