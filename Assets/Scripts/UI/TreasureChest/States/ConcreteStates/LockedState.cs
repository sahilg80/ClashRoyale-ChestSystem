using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest.States.ConcreteStates
{
    public class LockedState : TeasureChestBaseState
    {
        public LockedState(TreasureChestStateMachine treasureChestStateMachine, TreasureChestController treasureChestController)
        {
            Controller = treasureChestController;
            StateMachine = treasureChestStateMachine;
        }

        public override void OnEnter()
        {
            Controller.UpdateUIValues("Locked", CalculateGemsRequired(Controller.ChestScriptableObject.Timer));
        }

        public override void OnExit()
        {
            //throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            //throw new NotImplementedException();
        }


        private int CalculateGemsRequired(float timeValue)
        {
            // Calculate gems based on time value
            float gems = timeValue / Constants.TIMER_TO_GEMS_DIVISOR;

            // Round up to the nearest whole number (ceiling)
            int roundedGems = Mathf.CeilToInt(gems);

            return roundedGems;
        }
    }
}
