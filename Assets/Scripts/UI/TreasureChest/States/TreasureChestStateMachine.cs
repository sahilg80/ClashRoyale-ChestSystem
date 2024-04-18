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
        private StateType previousActiveState;
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
            previousActiveState = activeStateValue;
            activeState?.OnExit();

            switch (newState)
            {
                case StateType.LOCKED:
                    activeState = states.GetValueOrDefault(StateType.LOCKED);

                    break;
                case StateType.UNLOCKING:
                    activeState = states.GetValueOrDefault(StateType.UNLOCKING);
                    break;
                case StateType.UNLOCKED:
                    activeState = states.GetValueOrDefault(StateType.UNLOCKED);
                    break;
                case StateType.COLLECTED:
                    activeState = states.GetValueOrDefault(StateType.COLLECTED);
                    break;
                case StateType.DEACTIVATE:
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

        public void SwitchToPreviousState() => SwitchState(previousActiveState);

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
