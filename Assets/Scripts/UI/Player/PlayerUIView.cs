
using UnityEngine;
using TMPro;
using Assets.Scripts.Interfaces.Views;
using Assets.Scripts.Interfaces.Controller;

namespace Assets.Scripts.UI.Player
{
    public class PlayerUIView : MonoBehaviour, IView<PlayerUIController>
    {
        [SerializeField]
        private TextMeshProUGUI coinsRemainingCountText;
        [SerializeField]
        private TextMeshProUGUI gemsRemainingCountText;
        private IController playerUIController;

        public void SetController(PlayerUIController controller) => playerUIController = controller;
        public void SetRemainingCoins(string value) => coinsRemainingCountText.SetText(value);
        public void SetRemainingGems(string value) => gemsRemainingCountText.SetText(value);
    }
}
