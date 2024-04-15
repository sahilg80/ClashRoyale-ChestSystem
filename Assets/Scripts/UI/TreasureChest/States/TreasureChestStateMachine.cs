using Assets.Scripts.UI.TreasureChest.States.ConcreteStates;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest.States
{
    public class TreasureChestStateMachine
    {
        private TreasureChestController treasureChestController;
        private Dictionary<StateType, TeasureChestBaseState> states;
        private TeasureChestBaseState activeState;
        private StateType activeStateValue;
        public StateType ActiveStateValue => activeStateValue;

        public TreasureChestStateMachine(TreasureChestController treasureChestController)
        {
            this.treasureChestController = treasureChestController;
            Initialize();
        }

        public void UpdateLoop()
        {
            activeState?.OnUpdate();
        }

        public void SwitchState(StateType newState)
        {
            activeState?.OnExit();

            switch (newState)
            {
                case StateType.LOCKED:
                    Debug.Log("Switching to LOCKED state");
                    activeState = states.GetValueOrDefault(StateType.LOCKED);

                    break;
                case StateType.UNLOCKING:
                    Debug.Log("Switching to UNLOCKING state"); 
                    activeState = states.GetValueOrDefault(StateType.UNLOCKING);
                    break;
                case StateType.UNLOCKED:
                    Debug.Log("Switching to UNLOCKED state");
                    activeState = states.GetValueOrDefault(StateType.UNLOCKED);
                    break;
                case StateType.COLLECTED:
                    Debug.Log("Switching to COLLECTED state");
                    activeState = states.GetValueOrDefault(StateType.COLLECTED);
                    break;
                case StateType.DEACTIVATE:
                    Debug.Log("Switching to DEACTIVATE state");
                    activeState = states.GetValueOrDefault(StateType.DEACTIVATE);
                    break;
                default:
                    Debug.LogError("Invalid state");
                    break;
            }

            // Update current state
            activeStateValue = newState;
            activeState.OnEnter();
        }

        private void Initialize()
        {
            states = new Dictionary<StateType, TeasureChestBaseState>();
            CreateStates();
            SwitchState(StateType.DEACTIVATE);
        }

        private void CreateStates()
        {
            states.Add(StateType.LOCKED, new LockedState(this, treasureChestController));
            states.Add(StateType.UNLOCKING, new UnlockingState(this, treasureChestController));
            states.Add(StateType.UNLOCKED, new UnlockedState(this, treasureChestController));
            states.Add(StateType.COLLECTED, new CollectedState(this, treasureChestController));
            states.Add(StateType.DEACTIVATE, new DeactivateState(this, treasureChestController));
        }

    }
}
