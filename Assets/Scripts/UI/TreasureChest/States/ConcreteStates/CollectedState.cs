

namespace Assets.Scripts.UI.TreasureChest.States.ConcreteStates
{
    public class CollectedState : TeasureChestBaseState
    {
        public CollectedState(TreasureChestStateMachine treasureChestStateMachine, TreasureChestController treasureChestController)
        {
            Controller = treasureChestController;
            StateMachine = treasureChestStateMachine;
        }

        public override void OnEnter()
        {
            //play animation
            Controller.UpdateUIValues("Collected", 0);
            Controller.CollectTreasureChest();
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate()
        {

        }
    }
}
