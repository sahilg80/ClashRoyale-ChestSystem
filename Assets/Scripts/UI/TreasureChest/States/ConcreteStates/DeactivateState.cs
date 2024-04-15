

namespace Assets.Scripts.UI.TreasureChest.States.ConcreteStates
{
    public class DeactivateState : TeasureChestBaseState
    {
        public DeactivateState(TreasureChestStateMachine treasureChestStateMachine, TreasureChestController treasureChestController)
        {
            Controller = treasureChestController;
            StateMachine = treasureChestStateMachine;
        }

        public override void OnEnter()
        {
            //play animation
            Controller.SetChestVisibility(false);
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate()
        {

        }
    }
}
