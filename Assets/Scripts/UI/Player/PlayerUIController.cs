using Assets.Scripts.Interfaces.Controller;

namespace Assets.Scripts.UI.Player
{
    public class PlayerUIController : IController
    {
        private PlayerUIModel playerUIModel;
        private PlayerUIScriptableObject playerSO;
        private PlayerUIView playerUIView;

        public PlayerUIController(PlayerUIScriptableObject playerSO, PlayerUIView playerUIView)
        {
            this.playerSO = playerSO;
            this.playerUIView = playerUIView;
            playerUIModel = new PlayerUIModel();
            Initialize();
        }

        ~PlayerUIController()
        {
            UnSubscribeEvents();
        }

        public void Initialize()
        {

            SetPlayerCoins(playerSO.InitialCoinsOwned);
            SetPlayerGems(playerSO.InitialGemsOwned);
            playerUIView.SetController(this);
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            GameService.Instance.EventService.OnBuyChest.AddListener(OnBuyingTreasureChest);
            GameService.Instance.EventService.OnCollectTreasureChest.AddListener(OnTreasureChestCollected);
            GameService.Instance.EventService.OnUndoBuyingTreasureChest.AddListener(UpdatePlayersGemsToPrevious);
        }

        private void UnSubscribeEvents()
        {
            GameService.Instance.EventService.OnBuyChest.RemoveListener(OnBuyingTreasureChest);
            GameService.Instance.EventService.OnCollectTreasureChest.RemoveListener(OnTreasureChestCollected);
            GameService.Instance.EventService.OnUndoBuyingTreasureChest.RemoveListener(UpdatePlayersGemsToPrevious);
        }

        private void OnBuyingTreasureChest(int gemsUsed) => SetPlayerGems(-gemsUsed);
        
        private void OnTreasureChestCollected(int coins, int gems)
        {
            SetPlayerGems(gems); 
            SetPlayerCoins(coins);
        }

        private void SetPlayerGems(int gems)
        {
            playerUIModel.SetGemsOwned(playerUIModel.CurrentGemsOwned + gems);
            playerUIView.SetRemainingGems(playerUIModel.CurrentGemsOwned.ToString());
        }

        private void SetPlayerCoins(int coins)
        {
            playerUIModel.SetCoinsOwned(playerUIModel.CurrentCoinsOwned + coins);
            playerUIView.SetRemainingCoins(playerUIModel.CurrentCoinsOwned.ToString());
        }

        private void UpdatePlayersGemsToPrevious(int gems) => SetPlayerGems(gems);

        public int GetRemainingGemsCount() => playerUIModel.CurrentGemsOwned;

    }
}
