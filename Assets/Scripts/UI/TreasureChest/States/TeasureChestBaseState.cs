

namespace Assets.Scripts.UI.TreasureChest.States
{
    public abstract class TeasureChestBaseState
    {
        protected TreasureChestStateMachine StateMachine { get; set; }
        protected TreasureChestController Controller { get; set; }
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}
