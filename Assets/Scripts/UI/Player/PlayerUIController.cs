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
            playerUIModel.SetCoinsOwned(playerSO.InitialCoinsOwned);
            playerUIModel.SetGemsOwned(playerSO.InitialGemsOwned);
            playerUIView.SetController(this);
            playerUIView.SetRemainingCoins(playerUIModel.CurrentCoinsOwned.ToString());
            playerUIView.SetRemainingGems(playerUIModel.CurrentGemsOwned.ToString());
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            GameService.Instance.EventService.OnBuyChest.AddListener(OnBuyingTreasureChest);
            GameService.Instance.EventService.OnCollectTreasureChest.AddListener(OnTreasureChestCollected);
        }

        private void UnSubscribeEvents()
        {
            GameService.Instance.EventService.OnBuyChest.RemoveListener(OnBuyingTreasureChest);
            GameService.Instance.EventService.OnCollectTreasureChest.RemoveListener(OnTreasureChestCollected);
        }

        private void OnBuyingTreasureChest(int gemsUsed)
        {
            playerUIModel.SetGemsOwned(playerUIModel.CurrentGemsOwned - gemsUsed);
            playerUIView.SetRemainingGems(playerUIModel.CurrentGemsOwned.ToString());
        }
        
        private void OnTreasureChestCollected(int coins, int gems)
        {
            playerUIModel.SetGemsOwned(playerUIModel.CurrentGemsOwned + gems);
            playerUIModel.SetCoinsOwned(playerUIModel.CurrentCoinsOwned + coins);
            playerUIView.SetRemainingGems(playerUIModel.CurrentGemsOwned.ToString());
            playerUIView.SetRemainingCoins(playerUIModel.CurrentCoinsOwned.ToString());
        }

        public int GetRemainingGemsCount() => playerUIModel.CurrentGemsOwned;
        
    }
}
