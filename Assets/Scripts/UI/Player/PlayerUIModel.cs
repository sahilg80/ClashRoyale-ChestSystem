using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.Player
{
    public class PlayerUIModel
    {
        private int currentCoinsOwned;
        public int CurrentCoinsOwned => currentCoinsOwned;
        private int currentGemsOwned;
        public int CurrentGemsOwned => currentGemsOwned;

        public void UpdateCoinsOwned(int value) => currentCoinsOwned -= value;
        public void UpdateGemsOwned(int value) => currentGemsOwned -= value;
        public void SetCoinsOwned(int value) => currentCoinsOwned = value;
        public void SetGemsOwned(int value) => currentGemsOwned = value;
    }
}
