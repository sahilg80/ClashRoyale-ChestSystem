

using Assets.Scripts.UI.TreasureChest;

namespace Assets.Scripts.Event
{
    public class EventService
    {
        public EventController OnPlayerUIInitialized { get; private set; }
        public EventController OnClickAddChestButton { get; private set; }
        public EventController<string> NotifyPanelOpen { get; private set; }
        public EventController<int> OnBuyChest { get; private set; }
        public EventController<int, int> OnCollectTreasureChest { get; private set; }
        public EventController<bool, TreasureChestController> PopPanelDisplay { get; private set;}
        public EventController<int> OnUndoBuyingTreasureChest { get; private set; }
        public EventService()
        {
            OnPlayerUIInitialized = new EventController();
            OnClickAddChestButton = new EventController();
            NotifyPanelOpen = new EventController<string>();
            OnBuyChest = new EventController<int>();
            OnCollectTreasureChest = new EventController<int, int>();
            PopPanelDisplay = new EventController<bool, TreasureChestController>();
            OnUndoBuyingTreasureChest = new EventController<int>();
        }
    }
}
