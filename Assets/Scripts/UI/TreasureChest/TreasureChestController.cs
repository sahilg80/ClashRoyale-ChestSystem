using Assets.Scripts.Interfaces.Controller;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest
{
    public class TreasureChestController : IController
    {
        private TreasureChestView treasureChestView;
        private Transform chestSlotHolderParent;
        private bool isSlotEmpty;
        private TreasureChestScriptableObject treasureChestSO;

        public TreasureChestController(TreasureChestView treasureChestView, Transform chestSlotHolderParent)
        {
            this.chestSlotHolderParent = chestSlotHolderParent;
            this.treasureChestView = UnityEngine.Object.Instantiate(treasureChestView);
            Initialize();
        }

        public void Initialize()
        {
            treasureChestView.SetController(this);
            treasureChestView.transform.parent = chestSlotHolderParent;
            SetChestVisibility(false);
        }

        public void SetTreasureChestType(TreasureChestScriptableObject treasureChestSO) => this.treasureChestSO = treasureChestSO;
        

        public bool IsSlotEmpty() => isSlotEmpty;

        public void SetChestVisibility(bool value)
        {
            isSlotEmpty = !value;
            treasureChestView.SetTeasureChestVisibility(value);
        }

        public void UpdateUIValues(int gemsCount)
        {
            treasureChestView.SetStatusInUI("Locked");
            treasureChestView.SetGemsRequiredInUI(gemsCount.ToString());
        }
    }
}
