

namespace Assets.Scripts.UI.TreasureChest
{
    public class TreasureChestModel
    {
        private TreasureChestController treasureChestController;

        private bool isSlotEmpty;
        public bool IsSlotEmpty => isSlotEmpty;
        private int gemsRequiredToUnlock;
        public int GemsRequiredToUnlock => gemsRequiredToUnlock;

        public TreasureChestModel(TreasureChestController treasureChestController)
        {
            this.treasureChestController = treasureChestController;
        }

        public void UpdateGemsRequiredToUnlock(int value) => gemsRequiredToUnlock = value;
        public void UpdateSlotEmptyState(bool value) => isSlotEmpty = value;
    }
}
