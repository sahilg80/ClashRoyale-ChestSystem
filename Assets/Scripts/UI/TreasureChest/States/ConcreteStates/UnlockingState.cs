using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest.States.ConcreteStates
{
    public class UnlockingState : TeasureChestBaseState
    {
        private float currentTimerValue;

        public UnlockingState(TreasureChestStateMachine treasureChestStateMachine, TreasureChestController treasureChestController)
        {
            Controller = treasureChestController;
            StateMachine = treasureChestStateMachine;
        }

        public override void OnEnter()
        {
            if (currentTimerValue == 0)
            {
                currentTimerValue = Controller.ChestScriptableObject.Timer * Constants.SECONDS_VALUE; // Convert minutes to seconds
            }
            UpdateTimerUI();
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate()
        {
            currentTimerValue -= Time.deltaTime;

            // Update UI text
            UpdateTimerUI();

            // Check if timer reached zero
            if (currentTimerValue <= 0)
            {
                TimerExpired();
            }
        }

        private void UpdateTimerUI()
        {
            int minutes = Mathf.FloorToInt(currentTimerValue / Constants.SECONDS_VALUE);
            int seconds = Mathf.FloorToInt(currentTimerValue % Constants.SECONDS_VALUE);
            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
            if(seconds != 0)
            {
                minutes += 1;
            }
            int gemsRequired = CalculateGemsRequired(minutes);
            Controller.UpdateUIValues(timerString, gemsRequired);
        }

        private int CalculateGemsRequired(float timeValue)
        {
            // Calculate gems based on time value
            float gems = timeValue / Constants.TIMER_TO_GEMS_DIVISOR;

            // Round up to the nearest whole number (ceiling)
            int roundedGems = Mathf.CeilToInt(gems);

            return roundedGems;
        }


        private void TimerExpired()
        {
            StateMachine.SwitchState(StateType.UNLOCKED);
        }
    }
}
