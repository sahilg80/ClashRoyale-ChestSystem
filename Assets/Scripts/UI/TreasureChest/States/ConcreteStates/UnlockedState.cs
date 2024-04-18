
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest.States.ConcreteStates
{
    public class UnlockedState : TeasureChestBaseState
    {
        public UnlockedState(TreasureChestStateMachine treasureChestStateMachine, TreasureChestController treasureChestController)
        {
            Controller = treasureChestController;
            StateMachine = treasureChestStateMachine;
        }

        public override void OnEnter()
        {
            Controller.UpdateUIValues("Open", 0);
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate()
        {

        }
    }
}
