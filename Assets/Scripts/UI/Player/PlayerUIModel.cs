

namespace Assets.Scripts.UI.Player
{
    public class PlayerUIModel
    {
        private int currentCoinsOwned;
        public int CurrentCoinsOwned => currentCoinsOwned;
        private int currentGemsOwned;
        public int CurrentGemsOwned => currentGemsOwned;

        public void SetCoinsOwned(int value) => currentCoinsOwned = value;
        public void SetGemsOwned(int value) => currentGemsOwned = value;
    }
}
