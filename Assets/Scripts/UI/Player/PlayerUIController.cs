using Assets.Scripts.Interfaces.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Initialize()
        {
            playerUIModel.SetCoinsOwned(playerSO.InitialCoinsOwned);
            playerUIModel.SetGemsOwned(playerSO.InitialGemsOwned);
            playerUIView.SetController(this);
            playerUIView.SetRemainingCoins(playerUIModel.CurrentCoinsOwned.ToString());
            playerUIView.SetRemainingGems(playerUIModel.CurrentGemsOwned.ToString());
        }
    }
}
