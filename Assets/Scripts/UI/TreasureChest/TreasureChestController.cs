using Assets.Scripts.Interfaces.Controller;
using Assets.Scripts.UI.TreasureChest.States;
using Assets.Scripts.UI.TreasureChest.UIPanel;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.UI.TreasureChest
{
    public class TreasureChestController : IController
    {
        private TreasureChestView treasureChestView;
        private Transform chestSlotHolderParent;
        private TreasureChestScriptableObject treasureChestSO;
        public TreasureChestScriptableObject ChestScriptableObject => treasureChestSO;
        private TreasureChestStateMachine treasureChestStateMachine;
        private TreasureChestPanelUIController treasureChestPanelUIController;
        private TreasureChestModel treasureChestModel;

        public TreasureChestController(TreasureChestView treasureChestView, Transform chestSlotHolderParent, 
            TreasureChestPanelUIController treasureChestPanelUIController)
        {
            this.chestSlotHolderParent = chestSlotHolderParent;
            this.treasureChestView = UnityEngine.Object.Instantiate(treasureChestView);
            this.treasureChestPanelUIController = treasureChestPanelUIController;
            Initialize();
        }

        public void Initialize()
        {
            treasureChestView.SetController(this);
            treasureChestModel = new TreasureChestModel(this);
            treasureChestStateMachine = new TreasureChestStateMachine(this);
            treasureChestView.transform.parent = chestSlotHolderParent;
            treasureChestView.SetAnimationDoneCallback(OnAnimationDone);
            treasureChestView.SubcribeEvents();
        }

        public void SetTreasureChestType(TreasureChestScriptableObject treasureChestSO) => this.treasureChestSO = treasureChestSO;
        
        public bool IsSlotEmpty() => treasureChestModel.IsSlotEmpty;

        public void SetChestVisibility(bool value)
        {
            treasureChestModel.UpdateSlotEmptyState(!value);
            treasureChestView.SetTeasureChestVisibility(value);
        }

        public void UpdateUIValues(string statusText, int gemsCount)
        {
            treasureChestView.SetStatusInUI(statusText);
            if (gemsCount == 0) { 
                treasureChestView.ToggleRequiredGemsState(false); 
                return;
            }

            treasureChestView.ToggleRequiredGemsState(true);
            treasureChestModel.UpdateGemsRequiredToUnlock(gemsCount);
            treasureChestView.SetGemsRequiredInUI(gemsCount.ToString());
        }

        public void TransitionToState(StateType newState)
        {
            treasureChestStateMachine.SwitchState(newState);
        }

        public StateType GetActiveState() => treasureChestStateMachine.ActiveStateValue;

        public void UpdateLoop() => treasureChestStateMachine?.UpdateLoop();

        public void OnClickBuyWithGemsButton()
        {
            int gemsAvailable = GameService.Instance.UIService.GetPlayerUIController().GetRemainingGemsCount();
            
            if (gemsAvailable < treasureChestModel.GemsRequiredToUnlock)
            {
                GameService.Instance.EventService.NotifyPanelOpen.InvokeEvent(Constants.GEMS_NOT_SUFFICIENT_TEXT);
                return;
            }

            GameService.Instance.EventService.OnBuyChest.InvokeEvent(treasureChestModel.GemsRequiredToUnlock);
            treasureChestStateMachine.SwitchState(StateType.UNLOCKED);
        }

        public void CollectTreasureChest() => treasureChestView.PlayTreasureOpenAnimation();
        
        private void OnAnimationDone()
        {
            GameService.Instance.EventService.NotifyPanelOpen.InvokeEvent("Collected "+ treasureChestSO.Type+ " type chest with " + treasureChestSO.CoinsRewardCount + " coins & " + treasureChestSO.GemsRewardCount + " gems.");
            GameService.Instance.EventService.OnCollectTreasureChest.InvokeEvent(treasureChestSO.CoinsRewardCount, treasureChestSO.GemsRewardCount);
            TransitionToState(StateType.DEACTIVATE);
        }

        public void OnClickTreasureChest()
        {
            if (GetActiveState() == StateType.LOCKED && !treasureChestPanelUIController.IsTreasureChestAvailbleToStartUnlocking())
            {
                return;
            }

            CheckStatusOfClickedChest(GetActiveState());
        }

        private void CheckStatusOfClickedChest(StateType state)
        {
            switch (state)
            {
                case StateType.LOCKED:
                    GameService.Instance.EventService.PopPanelDisplay.InvokeEvent(true, this);
                    break;
                case StateType.UNLOCKING:
                    GameService.Instance.EventService.PopPanelDisplay.InvokeEvent(false, this);
                    break;
                case StateType.UNLOCKED:
                    treasureChestStateMachine.SwitchState(StateType.COLLECTED);
                    break;
                case StateType.COLLECTED:
                    treasureChestStateMachine.SwitchState(StateType.DEACTIVATE);
                    break;
                default:
                    Debug.LogError("Invalid state");
                    break;
            }
        }

    }
}
